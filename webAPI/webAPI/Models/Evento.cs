﻿using System;
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
}