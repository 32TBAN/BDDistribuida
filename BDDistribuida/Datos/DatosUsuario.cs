using BDDistribuida.Entidades;
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
    public class DatosInstancia
    {
        public static List<Instancia> DevolverListaInstancias()
        {
			try
			{
                List<Instancia> instancias = new List<Instancia>();

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
                                instancias.Add(new Instancia("Kevin"));
                            }
                            else if (dr[1].ToString() != "SITIOC")
                            {
                                instancias.Add(new Instancia(dr[1].ToString()));
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

        public static List<Instancia> DevolverBD(string nombre)
        {
            try
            {
                List<Instancia> baseDatos = new List<Instancia>();
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
                                baseDatos.Add(new Instancia(dr["name"].ToString()));
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

        public static List<Instancia> DevolverTablas(string bd, string instancia)
        {
            try
            {
                List<Instancia> tablas = new List<Instancia>();
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
                            tablas.Add(new Instancia(dr["TABLE_NAME"].ToString()));
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

        public static List<Instancia> DevolverColumnas(Instancia instancia)
        {
            try
            {
                List<Instancia> tablas = new List<Instancia>();
                if (instancia.Nombre != "Kevin")
                {
                    instancia.Nombre = "Kevin\\" + instancia.Nombre;
                }
                using (SqlConnection connection = new SqlConnection("Data Source=" + instancia.Nombre + ";Initial Catalog=Master;Integrated Security=True"))
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
                            tablas.Add(new Instancia(dr["COLUMN_NAME"].ToString()));
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
    }
}
