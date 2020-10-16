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
        private MySqlConnection conexion()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=placemybet;SslMode=none";
            MySqlConnection conexion = new MySqlConnection(connectionString);
            return conexion;

        }

        internal List<Apuesta> retrieve()
        {
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
                    Apuesta e = new Apuesta(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetString(3), reader.GetDouble(4));
                    apuesta.Add(e);

                }
                conectar.Close();
                return apuesta;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectar a la base de datos. ");
                return null;
            }
        }

        internal List<ApuestaDTO> retrieveDTO()
        {
            MySqlConnection conectar = conexion();
            MySqlCommand command = conectar.CreateCommand();
            command.CommandText = "SELECT apuesta.`email`,apuesta.`over/under`,apuesta.`dinero`,apuesta.tipo,mercado.`cuota over`,mercado.`cuota under`,evento.Fecha FROM apuesta INNER JOIN mercado ON apuesta.`over/under` = mercado.`over/under` INNER JOIN evento ON mercado.Id_evento = evento.Id_evento;";

            try
            {
                conectar.Open();
                MySqlDataReader reader = command.ExecuteReader();
                List<ApuestaDTO> apuesta = new List<ApuestaDTO>();

                while (reader.Read())
                {
                    ApuestaDTO e = new ApuestaDTO(reader.GetString(0), reader.GetDouble(1), reader.GetDouble(2), reader.GetString(3), reader.GetDouble(4), reader.GetDouble(5), reader.GetString(6));
                    apuesta.Add(e);

                }
                conectar.Close();
                return apuesta;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectar a la base de datos. ");
                return null;
            }
        }

        internal void Save(Apuesta ap)
        {
            MySqlConnection conectar = conexion();
            MySqlCommand command = conectar.CreateCommand();
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");

            culInfo.NumberFormat.NumberDecimalSeparator = ".";

            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;

            command.CommandText = "select * from mercado where mercado.`over/under`=" + ap.Over_under + ";";
            try
            {
                conectar.Open();
                MySqlDataReader res = command.ExecuteReader();
                res.Read();
                Debug.WriteLine(res.GetDouble(0) + " " + res.GetDouble(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3) + " " + res.GetDouble(4) + " " + res.GetInt32(5));
                Mercado mer = new Mercado(res.GetDouble(0), res.GetDouble(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetString(5));

                double dineroOver = 0;
                double dineroUnder = 0;
                if (ap.Tipo == "over")
                {
                    dineroOver = ap.Dinero + mer.Dinero_over;
                    dineroUnder = mer.Dinero_under;
                }
                else
                {
                    dineroOver = mer.Dinero_over;
                    dineroUnder = ap.Dinero + mer.Dinero_under;
                }

                double cuotaOver = dineroOver / (dineroOver + dineroUnder);
                cuotaOver = (1 / cuotaOver) * 0.95;
                double cuotaUnder = dineroUnder / (dineroUnder + dineroOver);
                cuotaUnder = (1 / cuotaUnder) * 0.95;
                res.Close();
                conectar.Close();
                command.CommandText = "update mercado set `cuota over`=" + Math.Round(cuotaOver, 2) + ", `cuota under`=" + Math.Round(cuotaUnder, 2) + ", `dinero over`=" + dineroOver + ", `dinero under`=" + dineroUnder + " mercado.`over/under`=" + ap.Over_under + ";";
                try
                {
                    conectar.Open();
                    command.ExecuteNonQuery();
                    conectar.Close();
                    double cuotaApuesta = 0;
                    if (ap.Tipo == "under")
                    {
                        cuotaApuesta = cuotaUnder;
                    }
                    else
                    {
                        cuotaApuesta = cuotaOver;
                    }
                    command.CommandText = "insert into apuesta(tipo, dinero, email, `over/under`,cuota) values (" + ap.Tipo + ", " + ap.Dinero + ", " +  ap.Email + ", '" + ap.Over_under + ", '" + Math.Round(cuotaApuesta, 2) + "'); ";
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
    }
}