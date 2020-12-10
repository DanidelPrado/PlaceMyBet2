using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAPI.Models
{
    public class Apuesta
    {
        public Apuesta(int id_Apuesta, double tipo_Mercado, double cuota, double dinero, string fecha, int id_Mercado, string email, string tipo_Cuota,int eventoId)
        {
            ApuestaId = id_Apuesta;
            Tipo_Mercado = tipo_Mercado;
            Cuota = cuota;
            Dinero = dinero;
            Fecha = fecha;
            Id_Mercado = id_Mercado;
            UsuarioId = email;
            Tipo_Cuota = tipo_Cuota;
            EventoId = eventoId;
        }

        public int ApuestaId { get; set; }
        public double Tipo_Mercado { get; set; }
        public double Cuota { get; set; }
        public double Dinero { get; set; }
        public string Fecha { get; set; }
        public int Id_Mercado { get; set; }
        public string Tipo_Cuota { get; set; }
        public string UsuarioId { get; set; }
        public int EventoId { get; set; }
        public Mercado Mercado { get; set; }
        public Usuario Usuario { get; set; }

        public Apuesta() { }
    }

    public class ApuestaDTO
    {
        public ApuestaDTO(string email, double tipo_Mercado, double cuota, string tipo_Cuota, double dinero, string fecha)
        {
            Email = email;
            Tipo_Mercado = tipo_Mercado;
            Cuota = cuota;
            Tipo_Cuota = tipo_Cuota;
            Dinero = dinero;
            Fecha = fecha;
        }

        public string Email { get; set; }
        public double Tipo_Mercado { get; set; }
        public double Cuota { get; set; }
        public string Tipo_Cuota { get; set; }
        public double Dinero { get; set; }
        public string Fecha { get; set; }
    }
}