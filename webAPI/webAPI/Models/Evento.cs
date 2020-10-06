using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAPI.Models
{
    public class Evento
    {
        public Evento(string id_evento, string local, string visitante, string fecha)
        {
            Id_evento = id_evento;
            Local = local;
            Visitante = visitante;
            Fecha = fecha;
        }

        public string Id_evento { get; set; }
        public string Local { get; set; }
        public string Visitante { get; set; }
        public string Fecha { get; set; }
    }
}