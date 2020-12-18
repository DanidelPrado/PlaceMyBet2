using Microsoft.EntityFrameworkCore;
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
            }
            return null;*/
            List<EventoDTO> eventos = new List<EventoDTO>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                eventos = context.Eventos.Select(p => ToDTO(p)).ToList();
            }
            return eventos;
        }

        static public EventoDTO ToDTO(Evento e)
        {
            return new EventoDTO(e.Local, e.Visitante);
        }
        //Ejercicio 1
        static public EventoDTO2 ToDTO2(Evento e,string equipo)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            Mercado m;
            using (context)
            {
                m = context.Mercados.FirstOrDefault(b => b.EventoId == e.EventoId);
            }
            if (e.Local == equipo)
            {
                return new EventoDTO2(e.Visitante, m.MercadoId, m.Cuota_Over, m.Cuota_Under);
            } else
            {
                return new EventoDTO2(e.Local, m.MercadoId, m.Cuota_Over, m.Cuota_Under);
            }
        }
        //Ejercicio 1
        internal List<EventoDTO2> retrievebyLocal(string equipo)
        {
            List<Evento> listaevento;
            List<EventoDTO2> listafinal = new List<EventoDTO2>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                listaevento = context.Eventos.Where(a => a.Local == equipo || a.Visitante == equipo).ToList();
            }
            for (int i = 0; i < listaevento.Count; i++)
            {
                listafinal.Add(ToDTO2(listaevento[i], equipo));
            }
            return listafinal;
        }
        //Ejercicio 2
        internal void Save(Evento ev)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            using (context)
            {
                context.Eventos.Add(ev);
                context.SaveChanges();
            }
        }
            internal void Put(int id, string local, string visitante)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            Evento evento;
            evento = context.Eventos.FirstOrDefault(e => e.EventoId == id);
            evento.Local = local;
            evento.Visitante = visitante;
            context.SaveChanges();
        }

        internal void Delete(int id)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            Evento evento;
            evento = context.Eventos.FirstOrDefault(e => e.EventoId == id);
            context.Eventos.Remove(evento);
            context.SaveChanges();
        }
    }
}

