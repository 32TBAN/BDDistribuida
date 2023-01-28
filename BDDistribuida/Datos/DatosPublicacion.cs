using BDDistribuida.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Microsoft.SqlServer.Dts.Runtime;
using Microsoft.SqlServer.Dts.Pipeline.Wrapper;
using System.IO;

namespace BDDistribuida.Datos
{
    public class DatosPublicacion
    {
        public static List<Publicacion> DevolverListaInstancias()
        {
            try
            {
                List<Publicacion> instancias = new List<Publicacion>();

                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionBD))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conexion;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"EXECUTE xp_regread
                                      @rootkey = 'HKEY_LOCAL_MACHINE',
                                      @key = 'SOFTWARE\Microsoft\Microsoft SQL Server',
                                      @value_name = 'InstalledInstances'";
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (dr[1].ToString() == "MSSQLSERVER")
                            {
                                instancias.Add(new Publicacion("KEVIN"));
                            }
                            else if (dr[1].ToString() != "SITIOC")
                            {
                                instancias.Add(new Publicacion(dr[1].ToString()));
                            }
                        }
                    }
                }

                return instancias;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Publicacion> DevolverBD(string nombre)
        {
            try
            {
                List<Publicacion> baseDatos = new List<Publicacion>();
                if (nombre != Environment.MachineName)
                {
                    nombre = Environment.MachineName + "\\" + nombre;
                }
                using (SqlConnection connection = new SqlConnection("Data Source=" + nombre + ";Initial Catalog=Master;Integrated Security=True"))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT name  
                                       FROM sys.databases;";
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (dr["name"].ToString() != "tempdb" && dr["name"].ToString() != "model"
                                && dr["name"].ToString() != "msdb" && dr["name"].ToString() != "distribution"
                                && dr["name"].ToString() != "master")
                            {
                                baseDatos.Add(new Publicacion(dr["name"].ToString()));
                            }
                        }
                    }
                }

                return baseDatos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Publicacion> DevolverTablas(string bd, string instancia)
        {
            try
            {
                List<Publicacion> tablas = new List<Publicacion>();
                if (instancia != Environment.MachineName)
                {
                    instancia = Environment.MachineName + "\\" + instancia;
                }
                using (SqlConnection connection = new SqlConnection("Data Source=" + instancia + ";Initial Catalog=Master;Integrated Security=True"))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"use [" + bd + "] SELECT * FROM INFORMATION_SCHEMA.TABLES " +
                        "where TABLE_NAME not like 'sys%' AND TABLE_NAME not like 'MS%' AND TABLE_NAME not like 'syn%';";
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            tablas.Add(new Publicacion(dr["TABLE_NAME"].ToString()));
                        }
                    }
                }

                return tablas;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Publicacion> DevolverColumnas(Publicacion instancia)
        {
            try
            {
                List<Publicacion> tablas = new List<Publicacion>();
                if (instancia.NombreInstancia != Environment.MachineName)
                {
                    instancia.NombreInstancia = Environment.MachineName + "\\" + instancia.NombreInstancia;
                }
                using (SqlConnection connection = new SqlConnection("Data Source=" + instancia.NombreInstancia + ";Initial Catalog=Master;Integrated Security=True"))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"use[" + instancia.BaseDatos + "] select t.COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS t where t.TABLE_CATALOG = N'" + instancia.BaseDatos + "' and t.TABLE_NAME = N'" + instancia.Tabla + "';";
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            tablas.Add(new Publicacion(dr["COLUMN_NAME"].ToString()));
                        }
                    }
                }

                return tablas;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool PublicarReplicaSinFiltro(Publicacion publicacion)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=" + publicacion.NombreInstancia +
                ";Initial Catalog=Master;Integrated Security=True"))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"use [" + publicacion.BaseDatos + @"]
                                        exec sp_replicationdboption @dbname = N'" + publicacion.BaseDatos + @"', @optname = N'publish', @value = N'true'
                                        
                                        use [" + publicacion.BaseDatos + @"]
                                        exec [" + publicacion.BaseDatos + @"].sys.sp_addlogreader_agent @job_login = N'Kevin\Esteban', 
                                        @job_password = N'" + publicacion.Contraseña + @"',@publisher_security_mode = 1, @job_name = null

                                        use [" + publicacion.BaseDatos + @"]
                                        exec sp_addpublication @publication = N'" + publicacion.NombrePub + @"', 
                                        @description = N'Transactional publication of database ''" + publicacion.BaseDatos + @"'' from Publisher ''KEVIN''.', 
                                        @sync_method = N'concurrent', @retention = 0, @allow_push = N'true', @allow_pull = N'true', @allow_anonymous = N'true', 
                                        @enabled_for_internet = N'false', @snapshot_in_defaultfolder = N'true', @compress_snapshot = N'false', @ftp_port = 21, 
                                        @ftp_login = N'anonymous', @allow_subscription_copy = N'false', @add_to_active_directory = N'false', @repl_freq = N'continuous', 
                                        @status = N'active', @independent_agent = N'true', @immediate_sync = N'true', @allow_sync_tran = N'true', 
                                        @autogen_sync_procs = N'false',@allow_queued_tran = N'false', @allow_dts = N'false', @replicate_ddl = 1, 
                                        @allow_initialize_from_backup = N'false', @enabled_for_p2p = N'false', @enabled_for_het_sub = N'false'

                                        exec sp_addpublication_snapshot @publication = N'" + publicacion.NombrePub + @"', @frequency_type = 1, @frequency_interval = 0, 
                                        @frequency_relative_interval = 0, @frequency_recurrence_factor = 0, @frequency_subday = 0, @frequency_subday_interval = 0,
                                        @active_start_time_of_day = 0,@active_end_time_of_day = 235959, @active_start_date = 0, @active_end_date = 0, 
                                        @job_login = N'Kevin\Esteban', @job_password = N'" + publicacion.Contraseña + @"', @publisher_security_mode = 1

                                        use [" + publicacion.BaseDatos + @"]
                                        exec sp_addarticle @publication = N'" + publicacion.NombrePub + @"', @article = N'" + publicacion.Tabla + @"', @source_owner = N'dbo', 
                                        @source_object = N'" + publicacion.Tabla + @"', @type = N'logbased', @description = null, @creation_script = null, @pre_creation_cmd = N'drop', 
                                        @schema_option = 0x000000000803509F, @identityrangemanagementoption = N'manual', @destination_table = N'" + publicacion.Tabla + @"',
                                        @destination_owner = N'dbo', @vertical_partition = N'false', @ins_cmd = N'CALL sp_MSins_dbo" + publicacion.Tabla + @"', 
                                        @del_cmd = N'CALL sp_MSdel_dbo" + publicacion.Tabla + @"', @upd_cmd = N'SCALL sp_MSupd_dbo" + publicacion.Tabla + @"'";
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void RealizarSuscripcion(Publicacion publicacion, List<Suscripcion> datosSuscripcion)
        {
            try
            {
                foreach (var item in datosSuscripcion)
                {
                    if (item.NombreIntanciaS == "Kevin")
                    {
                        item.NombreIntanciaS = "Esteban";
                    }
                    using (SqlConnection connection = new SqlConnection("Data Source=" + publicacion.NombreInstancia +
                        ";Initial Catalog=Master;Integrated Security=True"))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = @"use [" + publicacion.BaseDatos + @"]
                                            exec sp_addsubscription @publication = N'" + publicacion.NombrePub + @"', 
                                            @subscriber = N'" + publicacion.NombreInstancia + "\\" + item.NombreIntanciaS + @"', 
                                            @destination_db = N'" + item.NombreBDS + @"', @subscription_type = N'Push',
                                            @sync_type = N'automatic', @article = N'all', @update_mode = N'sync tran', @subscriber_type = 0
                                            exec sp_addpushsubscription_agent @publication = N'" + publicacion.NombrePub + @"',
                                            @subscriber = N'" + publicacion.NombreInstancia + "\\" + item.NombreIntanciaS + @"', 
                                            @subscriber_db = N'" + item.NombreBDS + @"',
                                            @job_login = N'" + publicacion.NombreInstancia + @"', @job_password = N'" + publicacion.Contraseña + @"', 
                                            @subscriber_security_mode = 1, @frequency_type = 64, @frequency_interval = 0,
                                            @frequency_relative_interval = 0, @frequency_recurrence_factor = 0, @frequency_subday = 0, @frequency_subday_interval = 0, 
                                            @active_start_time_of_day = 0, @active_end_time_of_day = 235959, @active_start_date = 20230115, @active_end_date = 99991231, 
                                            @enabled_for_syncmgr = N'False', @dts_package_location = N'Distributor'";
                        cmd.ExecuteNonQuery();

                        connection.Close();
                    }


                    using (SqlConnection connection = new SqlConnection("Data Source=" + publicacion.NombreInstancia + "\\" + item.NombreIntanciaS +
                      ";Initial Catalog=Master;Integrated Security=True"))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = @"use [" + item.NombreBDS + @"]
                                            exec sp_link_publication @publisher = N'KEVIN', @publisher_db = N'" + publicacion.BaseDatos + @"', 
                                            @publication = N'" + publicacion.NombrePub + @"', @distributor = N'KEVIN',
                                            @security_mode = 0, @login = N'sa', @password = N'" + publicacion.Contraseña + @"'";
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<Publicacion> DevolverOracleDB()
        {
            try
            {
                List<Publicacion> usuariosOracle = new List<Publicacion>();
                using (OracleConnection oracleConnection = new OracleConnection("Data Source=XE;User Id=system;Password=MI3deenero;"))
                {
                    oracleConnection.Open();
                    OracleCommand cmd = new OracleCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT USERNAME FROM DBA_USERS 
                                        WHERE USERNAME NOT IN ('APEX_PUBLIC_USER', 'SYS', 'SYSTEM', 'DBSNMP', 'OUTLN', 'EXFSYS','ANONYMOUS','FLOWS_FILES',
                                        'APEX_040000','XS$NULL','DIP','ORACLE_OCM','APPQOSSYS','MDSYS','CTXSYS','XDB','HR')";

                    using (OracleCommand oracleCommand = new OracleCommand(cmd.CommandText, oracleConnection))
                    {
                        using (OracleDataReader oracleDataReader = oracleCommand.ExecuteReader())
                        {
                            while (oracleDataReader.Read())
                            {
                                usuariosOracle.Add(new Publicacion(oracleDataReader["USERNAME"].ToString()));
                                Console.WriteLine(oracleDataReader["USERNAME"]);
                            }
                        }
                    }
                }
                return usuariosOracle;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ReplicarOracle(Publicacion publicacion,OracleEntidad oracleEntidad)
        {
            // Crear una nueva instancia del paquete de integración
            Package replicationPackage = new Package();

            // Crear una nueva tarea de Data Flow
            Executable dataFlowTask = replicationPackage.Executables.Add("STOCK:PipelineTask");
            TaskHost dataFlowTaskHost = dataFlowTask as TaskHost;
            MainPipe dataFlowTaskPipe = dataFlowTaskHost.InnerObject as MainPipe;

            // Crear una nueva fuente de datos de SQL Server
            IDTSComponentMetaData100 sqlServerSource = dataFlowTaskPipe.ComponentMetaDataCollection.New();
            sqlServerSource.Name = "SQL Server Source";
            sqlServerSource.ComponentClassID = "DTSAdapter.OleDbSource";
            CManagedComponentWrapper sqlServerSourceInstance = sqlServerSource.Instantiate();
            sqlServerSourceInstance.ProvideComponentProperties();
            sqlServerSourceInstance.SetComponentProperty("ConnectionString", "Data Source=" + publicacion.NombreInstancia + ";Initial Catalog=Master;Integrated Security=True");
            sqlServerSourceInstance.SetComponentProperty("SqlCommand", "SELECT * FROM "+publicacion.Tabla+" ;");

            // Crear una nueva fuente de datos de Oracle
            IDTSComponentMetaData100 oracleDestination = dataFlowTaskPipe.ComponentMetaDataCollection.New();
            oracleDestination.Name = "Oracle Destination";
            oracleDestination.ComponentClassID = "DTSAdapter.OracleDestination";
            CManagedComponentWrapper oracleDestinationInstance = oracleDestination.Instantiate();
            oracleDestinationInstance.ProvideComponentProperties();
            oracleDestinationInstance.SetComponentProperty("ConnectionString", "Data Source=XE;User Id="+oracleEntidad.user+";Password="+oracleEntidad.contrasena+";");
            // Conectar las fuentes de datos a la tarea de Data Flow
            IDTSPath100 path = dataFlowTaskPipe.PathCollection.New();
            path.AttachPathAndPropagateNotifications(sqlServerSource.OutputCollection[0], oracleDestination.InputCollection[0]);

            // Ejecutar el paquete de integración
            DTSExecResult result = replicationPackage.Execute();
            if (result == DTSExecResult.Failure)
            {
                // Mostrar el mensaje de error si la tarea falla
                Console.WriteLine("Error: " + replicationPackage.Errors[0].Description);
            }
        }
    }
}
