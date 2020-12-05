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
}