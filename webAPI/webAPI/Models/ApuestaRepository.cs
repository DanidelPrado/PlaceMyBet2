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
            command.CommandText = "insert into apuesta(Id_apuesta, tipo, dinero, email, `over/under`) values ('" + ap.Id_apuesta + "','" + ap.Tipo + "','" + ap.Dinero + "','" + ap.Email + "','" + ap.Over_under + "');";
            Debug.WriteLine("comando " + command.CommandText);
            try
            {
                conectar.Open();
                command.ExecuteNonQuery();
                conectar.Close();
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión");
            }

        }
    }
}