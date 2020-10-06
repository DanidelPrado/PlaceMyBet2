using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    }
}