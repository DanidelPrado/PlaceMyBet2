using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace webAPI.Models
{
    public class EventoRepository
    {
        /*private MySqlConnection conexion()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=placemybet;SslMode=none";
            MySqlConnection conexion = new MySqlConnection(connectionString);
            return conexion;

        }*/

        internal List<Evento> retrieve()
        {
            /*MySqlConnection conectar = conexion();
            MySqlCommand command = conectar.CreateCommand();
            command.CommandText = "SELECT * FROM evento";

            try
            {
                conectar.Open();
                MySqlDataReader reader = command.ExecuteReader();
                List<Evento> evento = new List<Evento>();

                while (reader.Read())
                {
                    Evento e = new Evento(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetMySqlDateTime(3).ToString());
                    evento.Add(e);

                }
                conectar.Close();
                return evento;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectar a la base de datos. ");
                return null;
            }
            return null;*/
            List<Evento> listaEventos = new List<Evento>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                listaEventos = context.Eventos.ToList();
            }
            return listaEventos;
        }

        internal void Save(Evento ev)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            context.Eventos.Add(ev);
            context.SaveChanges();
        }

        internal List<EventoDTO> retrieveDTO()
        {
            /*MySqlConnection conectar = conexion();
            MySqlCommand command = conectar.CreateCommand();
            command.CommandText = "SELECT local,visitante,fecha FROM evento";

            try
            {
                conectar.Open();
                MySqlDataReader reader = command.ExecuteReader();
                List<EventoDTO> evento = new List<EventoDTO>();

                while (reader.Read())
                {
                    EventoDTO e = new EventoDTO(reader.GetString(0), reader.GetString(1), reader.GetMySqlDateTime(2).ToString());
                    evento.Add(e);

                }
                conectar.Close();
                return evento;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectar a la base de datos. ");
                return null;
            }*/
            return null;
        }


    }
}