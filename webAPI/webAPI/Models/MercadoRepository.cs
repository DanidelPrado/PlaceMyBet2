using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace webAPI.Models
{
    public class MercadoRepository
    {
        /*private MySqlConnection conexion()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=placemybet;SslMode=none";
            MySqlConnection conexion = new MySqlConnection(connectionString);
            return conexion;

        }*/

        internal List<Mercado> retrieve()
        {
            /*MySqlConnection conectar = conexion();
            MySqlCommand command = conectar.CreateCommand();
            command.CommandText = "SELECT * FROM mercado";

            try
            {
                conectar.Open();
                MySqlDataReader reader = command.ExecuteReader();
                List<Mercado> mercado = new List<Mercado>();

                while (reader.Read())
                {
                    Mercado e = new Mercado(reader.GetInt32(0), reader.GetDouble(1), reader.GetDouble(2), reader.GetDouble(3), reader.GetDouble(4), reader.GetDouble(5), reader.GetInt32(6));
                    mercado.Add(e);

                }
                conectar.Close();
                return mercado;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectar a la base de datos. ");
                return null;
            }
            return null;*/
            List<Mercado> listaMercados = new List<Mercado>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                listaMercados = context.Mercados.Include(p => p.Evento).ToList();
            }
            return listaMercados;
        }

        internal List<MercadoDTO> retrieveDTO()
        {
            /*MySqlConnection conectar = conexion();
            MySqlCommand command = conectar.CreateCommand();
            command.CommandText = "SELECT tipo_Mercado,cuota_Over,cuota_Under FROM mercado";

            try
            {
                conectar.Open();
                MySqlDataReader reader = command.ExecuteReader();
                List<MercadoDTO> mercado = new List<MercadoDTO>();

                while (reader.Read())
                {
                    MercadoDTO e = new MercadoDTO(reader.GetDouble(0), reader.GetDouble(1), reader.GetDouble(2));
                    mercado.Add(e);

                }
                conectar.Close();
                return mercado;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Error al conectar a la base de datos. ");
                return null;
            }
            return null;*/
            PlaceMyBetContext context = new PlaceMyBetContext();
            List<MercadoDTO> listaMercados = context.Mercados.Select(p => ToDTO(p)).ToList();
            return listaMercados;
        }

        static public MercadoDTO ToDTO(Mercado mercado)
        {
            return new MercadoDTO(mercado.Tipo_Mercado, mercado.Cuota_Over, mercado.Cuota_Under);

        }

        internal void Save(Mercado mercado)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            context.Mercados.Add(mercado);
            context.SaveChanges();
        }
    }
}

/*
 static public ApuestaDTO3 toDTO3(Apuesta a)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            Usuario u;
            using (context)
            {
                u = context.Usuarios.Single(b => b.UsuarioId == a.UsuarioId);

            }
            return new ApuestaDTO3(a.dinero, a.tipoCuota, u.Nombre);
}
internal List<ApuestaDTO3> RetrievebyId(int id)
        {
            List<Apuesta> lista;
            List<ApuestaDTO3> final = new List<ApuestaDTO3>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                lista = context.Apuestas.Where(a => a.MercadoId == id).ToList();
            }
            for(int i = 0; i < lista.Count; i++)
            {
                final.Add(toDTO3(lista[i]));
            }
            return final;
        }
 static public ApuestaDTO4 toDTO4(Apuesta a)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            Evento e;
            Mercado m;
            using (context)
            {
                m = context.Mercados.Single(p => p.MercadoId == a.MercadoId);
                e = context.Eventos.Single(p => p.EventoId == m.EventoId);
            }
            return new ApuestaDTO4(a.tipoCuota, e.Local, e.Visitante);
        }

internal List<ApuestaDTO4> RetrievebyId(int id)
        {
            List<Apuesta> lista;
            List<ApuestaDTO4> final = new List<ApuestaDTO4>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                lista = context.Apuestas.Where(a => a.dinero > id).ToList();
            }
            for(int i = 0; i < lista.Count; i++)
            {
                final.Add(toDTO4(lista[i]));
            }
            return final;
        }
 */