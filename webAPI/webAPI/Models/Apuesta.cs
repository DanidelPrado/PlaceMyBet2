using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAPI.Models
{
    public class Apuesta
    {
        public Apuesta(int id_apuesta, string tipo, double dinero, string email, double over_under)
        {
            Id_apuesta = id_apuesta;
            Tipo = tipo;
            Dinero = dinero;
            Email = email;
            Over_under = over_under;
        }

        public int Id_apuesta { get; set; }
        public string Tipo { get; set; }
        public double Dinero { get; set; }
        public string Email { get; set; }
        public double Over_under { get; set; }
    }

    public class ApuestaDTO
    {
        public ApuestaDTO(string email, double over_under, double dinero, string tipo, double cuota_over, double cuota_under, string fecha)
        {
            Tipo = tipo;
            Dinero = dinero;
            Email = email;
            Over_under = over_under;
            Cuota_over = cuota_over;
            Cuota_under = cuota_under;
            Fecha = fecha;
        }

        public string Tipo { get; set; }
        public double Dinero { get; set; }
        public string Email { get; set; }
        public double Over_under { get; set; }
        public double Cuota_over { get; set; }
        public double Cuota_under { get; set; }
        public string Fecha { get; set; }
    }
}