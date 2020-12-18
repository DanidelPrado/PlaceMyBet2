using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAPI.Models
{
    public class Evento
    {
        public Evento(int id_evento, string local, string visitante, string fecha)
        {
            EventoId = id_evento;
            Local = local;
            Visitante = visitante;
            Fecha = fecha;
        }

        public int EventoId { get; set; }
        public string Local { get; set; }
        public string Visitante { get; set; }
        public string Fecha { get; set; }
        public List<Mercado> ListaMercados { get; set; }

        public Evento() { }
    }

    public class EventoDTO
    {
        public EventoDTO(string local, string visitante)
        {
            Local = local;
            Visitante = visitante;
        }

        public string Local { get; set; }
        public string Visitante { get; set; }
    }
    //Ejercicio 1
    public class EventoDTO2
    {
        public EventoDTO2(string rival, int idMercado, double cuota_over, double cuota_under)
        {
            Rival = rival;
            MercadoId = idMercado;
            Cuota_Over = cuota_over;
            Cuota_Under = cuota_under;
        }

        public string Rival { get; set; }
        public int MercadoId { get; set; }
        public double Cuota_Over { get; set; }
        public double Cuota_Under { get; set; }
    }
    //Ejercicio 2
    public class EventoDTO3
    {
        public EventoDTO3(string local, string visitante, double tipo_Mercado, double cuota_over, double cuota_under, double dinero_over, double dinero_under)
        {
            Local = local;
            Visitante = visitante;
            Tipo_Mercado = tipo_Mercado;
            Cuota_Over = cuota_over;
            Cuota_Under = cuota_under;
            Dinero_Over = dinero_over;
            Dinero_Under = dinero_under;
        }

        public string Local { get; set; }
        public string Visitante { get; set; }
        public double Tipo_Mercado { get; set; }
        public double Cuota_Over { get; set; }
        public double Cuota_Under { get; set; }
        public double Dinero_Over { get; set; }
        public double Dinero_Under { get; set; }
    }
    
}