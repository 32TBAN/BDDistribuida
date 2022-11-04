﻿using BDDistribuida.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

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
                            if (dr[1].ToString()== "MSSQLSERVER")
                            {
                                instancias.Add(new Publicacion("Kevin"));
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
                if (nombre != "Kevin")
                {
                    nombre = "Kevin\\"+nombre;
                }
                using (SqlConnection connection = new SqlConnection("Data Source="+nombre+";Initial Catalog=Master;Integrated Security=True"))
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
                if (instancia != "Kevin")
                {
                    instancia = "Kevin\\" + instancia;
                }
                using (SqlConnection connection = new SqlConnection("Data Source=" + instancia + ";Initial Catalog=Master;Integrated Security=True"))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"use ["+bd+ "] SELECT * FROM INFORMATION_SCHEMA.TABLES " +
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
                if (instancia.NombreInstancia != "Kevin")
                {
                    instancia.NombreInstancia = "Kevin\\" + instancia.NombreInstancia;
                }
                using (SqlConnection connection = new SqlConnection("Data Source=" + instancia.NombreInstancia + ";Initial Catalog=Master;Integrated Security=True"))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"use["+instancia.BaseDatos+"] select t.COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS t where t.TABLE_CATALOG = N'"+instancia.BaseDatos+"' and t.TABLE_NAME = N'"+instancia.Tabla+"';";
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
                List<Publicacion> tablas = new List<Publicacion>();

                using (SqlConnection connection = new SqlConnection("Data Source=" + publicacion.NombreInstancia +
                    ";Initial Catalog=Master;Integrated Security=True"))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $"use master\r\n" +
                                      $"exec sp_replicationdboption @dbname = N'{publicacion.BaseDatos}', @optname = N'publish',@value = N'true'\r\n"+ 
                                      $"use [{publicacion.BaseDatos}]\r\n" +
                                      $"exec sp_addpublication @publication = N'{publicacion.NombrePub}'," +
                                      $"@description = N'Snapshot publication of database ''{publicacion.BaseDatos}'' from Publisher ''KEVIN''.'," +
                                      $"@sync_method = N'native', @retention = 0, @allow_push = N'true', @allow_pull = N'true'," +
                                      $"@allow_anonymous = N'true', @enabled_for_internet = N'false', @snapshot_in_defaultfolder = N'true'," +
                                      $"@compress_snapshot = N'false', @ftp_port = 21, @ftp_login = N'anonymous', @allow_subscription_copy = N'false'," +
                                      $"@add_to_active_directory = N'false', @repl_freq = N'snapshot',@status = N'active', @independent_agent = N'true', " +
                                      $"@immediate_sync = N'true',@allow_sync_tran = N'false', @autogen_sync_procs = N'false', " +
                                      $"@allow_queued_tran = N'false', @allow_dts = N'false', @replicate_ddl = 1 \r\n " +
                                      $"exec sp_addpublication_snapshot @publication = N'{publicacion.NombrePub}', @frequency_type = 1, @frequency_interval = 0," +
                                      $"@frequency_relative_interval = 0,@frequency_recurrence_factor = 0, @frequency_subday = 0, @frequency_subday_interval = 0," +
                                      $"@active_start_time_of_day = 0, @active_end_time_of_day = 235959,@active_start_date = 0,@active_end_date = 0, " +
                                      $"@job_login = N'{publicacion.NombreInstancia}', @job_password = {publicacion.Contraseña}, @publisher_security_mode = 1 \r\n" +
                                      $"use [{publicacion.BaseDatos}] \r\n" +
                                      $"exec sp_addarticle @publication = N'{publicacion.NombrePub}', @article = N'{publicacion.Tabla}', " +
                                      $"@source_owner = N'dbo',@source_object = N'{publicacion.Tabla}', @type = N'logbased', @description = null, " +
                                      $"@creation_script = null, @pre_creation_cmd = N'drop', @schema_option = 0x000000000803509D, " +
                                      $"@identityrangemanagementoption = N'manual', @destination_table = N'{publicacion.Tabla}', @destination_owner = N'dbo', " +
                                      $"@vertical_partition = N'false'";
                    cmd.ExecuteNonQuery();
                    //Todo: Intentar con @
                }
                return true;
            }
            catch (Exception)
            {
                throw;
                return false;
            }
        }
            public static bool PublicarReplicaConFiltro(Publicacion publicacion)
            {
                try
                {
                    List<Publicacion> tablas = new List<Publicacion>();

                    using (SqlConnection connection = new SqlConnection("Data Source=" + publicacion.NombreInstancia +
                        ";Initial Catalog=Master;Integrated Security=True"))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = $"use master" +
                                          $"exec sp_replicationdboption @dbname = N'{publicacion.BaseDatos}', @optname = N'publish'," +
                                          $"@value = N'true'" +
                                          $"GO" +
                                          $"use [{publicacion.BaseDatos}]" +
                                          $"exec sp_addpublication @publication = N'{publicacion.NombrePub}'," +
                                          $"@description = N'Snapshot publication of database ''{publicacion.BaseDatos}'' from Publisher ''KEVIN''.'," +
                                          $"@sync_method = N'native', @retention = 0, @allow_push = N'true', @allow_pull = N'true'," +
                                          $"@allow_anonymous = N'true', @enabled_for_internet = N'false', @snapshot_in_defaultfolder = N'true'," +
                                          $"@compress_snapshot = N'false', @ftp_port = 21, @ftp_login = N'anonymous', @allow_subscription_copy = N'false'," +
                                          $"@add_to_active_directory = N'false', @repl_freq = N'snapshot',@status = N'active', @independent_agent = N'true', " +
                                          $"@immediate_sync = N'true',@allow_sync_tran = N'false', @autogen_sync_procs = N'false', " +
                                          $"@allow_queued_tran = N'false', @allow_dts = N'false', @replicate_ddl = 1 GO";
                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                tablas.Add(new Publicacion(dr["COLUMN_NAME"].ToString()));
                            }
                        }
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        
    }
}
