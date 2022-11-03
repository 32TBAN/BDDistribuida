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
                            instancias.Add(new Instancia(dr[1].ToString()));
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
                            baseDatos.Add(new Instancia(dr["name"].ToString()));
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
    }
}
