using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;

namespace webAPI.Models
{
    public class ApuestaRepository
    {
        /*
        private MySqlConnection conexion()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=placemybet;SslMode=none";
            MySqlConnection conexion = new MySqlConnection(connectionString);
            return conexion;
        }
            */

        internal List<Apuesta> retrieve()
        {
            /*
            MySqlConnection conectar = conexion();
            MySqlCommand command = conectar.CreateCommand();
            command.CommandText = "SELECT * FROM apuesta";

            try
            {
                conectar.Open();
                MySqlDataReader reader = command.ExecuteReader();
                List<Apuesta> apuesta = new List<Apuesta>();

                while (reader.Read())
                {
                    Apuesta e = new Apuesta(reader.GetInt32(0), reader.GetDouble(1), reader.GetDouble(2), reader.GetDouble(3), reader.GetString(4), reader.GetInt32(5), reader.GetString(6), reader.GetString(7));
                    apuesta.Add(e);

                }
                conectar.Close();
                return apuesta;


                }
                catch (MySqlException e)
                {
                    Debug.WriteLine("Error al conectar a la base de datos. ");
                    return null;
                }*/
            return null;
        }

        internal List<ApuestaDTO> retrieveDTO()
        {
            /*
                MySqlConnection conectar = conexion();
                MySqlCommand command = conectar.CreateCommand();
                command.CommandText = "SELECT email,tipo_Mercado,cuota,tipo_Cuota,dinero,fecha FROM apuesta;";

                try
                {
                    conectar.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    List<ApuestaDTO> apuesta = new List<ApuestaDTO>();

                    while (reader.Read())
                    {
                        ApuestaDTO e = new ApuestaDTO(reader.GetString(0), reader.GetDouble(1), reader.GetDouble(2), reader.GetString(3), reader.GetDouble(4), reader.GetString(5));
                        apuesta.Add(e);

                    }
                    conectar.Close();
                    return apuesta;
                }
                catch (MySqlException e)
                {
                    Debug.WriteLine("Error al conectar a la base de datos. ");
                    return null;
                }*/
            return null;
        }

        internal void Save(Apuesta ap)
        {
            /*
                MySqlConnection conectar = conexion();
                MySqlCommand command = conectar.CreateCommand();
                CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");

                culInfo.NumberFormat.NumberDecimalSeparator = ".";

                culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
                culInfo.NumberFormat.PercentDecimalSeparator = ".";
                culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
                System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;

                command.CommandText = "select * from mercado where id_Mercado=" + ap.Id_Mercado + ";";
                try
                {
                    conectar.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    Mercado mer = new Mercado(reader.GetInt32(0), reader.GetDouble(1), reader.GetDouble(2), reader.GetDouble(3), reader.GetDouble(4), reader.GetDouble(5), reader.GetInt32(6));

                    double dineroOver = 0;
                    double dineroUnder = 0;
                    if (ap.Tipo_Cuota == "over")
                    {
                        dineroOver = ap.Dinero + mer.Dinero_Over;
                        dineroUnder = mer.Dinero_Under;
                    }
                    else
                    {
                        dineroOver = mer.Dinero_Over;
                        dineroUnder = ap.Dinero + mer.Dinero_Under;
                    }

                    double cuotaOver = dineroOver / (dineroOver + dineroUnder);
                    cuotaOver = (1 / cuotaOver) * 0.95;
                    double cuotaUnder = dineroUnder / (dineroUnder + dineroOver);
                    cuotaUnder = (1 / cuotaUnder) * 0.95;
                    reader.Close();
                    conectar.Close();
                    command.CommandText = "update mercado set cuota_Over=" + Math.Round(cuotaOver, 2) + ", cuota_Under=" + Math.Round(cuotaUnder, 2) + ", dinero_Over=" + dineroOver + ", dinero_Under=" + dineroUnder + " where id_Mercado=" + ap.Id_Mercado + ";";
                    try
                    {
                        conectar.Open();
                        command.ExecuteNonQuery();
                        conectar.Close();
                        double cuotaApuesta = 0;
                        if (ap.Tipo_Cuota == "under")
                        {
                            cuotaApuesta = cuotaUnder;
                        }
                        else
                        {
                            cuotaApuesta = cuotaOver;
                        }
                        command.CommandText = "insert into apuesta(tipo_Mercado, cuota, dinero, fecha, id_Mercado, email, tipo_Cuota) values (" + ap.Tipo_Mercado + ", " + Math.Round(cuotaApuesta, 2) + ", " + ap.Dinero + ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "', " + ap.Id_Mercado + ", '" + ap.Email + "', '" + ap.Tipo_Cuota + "');";
                        try
                        {
                            conectar.Open();
                            command.ExecuteNonQuery();
                            conectar.Close();
                        }
                        catch (MySqlException e)
                        {
                            Debug.WriteLine("Se ha producido un error de conexion");
                        }
                    }
                    catch (MySqlException e)
                    {
                        Debug.WriteLine("Se ha producido un error de conexion");
                    }

                }
                catch (MySqlException e)
                {
                    Debug.WriteLine("Se ha producido un error de conexion");
                }

            }
            */
        }
    }
}