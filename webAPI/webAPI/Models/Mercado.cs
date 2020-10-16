using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAPI.Models
{
    public class Mercado
    {
        public Mercado(double over_Under, double cuota_over, double cuota_under, double dinero_over, double dinero_under, string id_evento)
        {
            Over_Under = over_Under;
            Cuota_over = cuota_over;
            Cuota_under = cuota_under;
            Dinero_over = dinero_over;
            Dinero_under = dinero_under;
            Id_evento = id_evento;
        }

        public double Over_Under { get; set; }
        public double Cuota_over { get; set; }
        public double Cuota_under { get; set; }
        public double Dinero_over { get; set; }
        public double Dinero_under { get; set; }
        public string Id_evento { get; set; }
    }

    public class MercadoDTO
    {
        public MercadoDTO(double over_Under, double cuota_over, double cuota_under)
        {
            Over_Under = over_Under;
            Cuota_over = cuota_over;
            Cuota_under = cuota_under;
        }

        public double Over_Under { get; set; }
        public double Cuota_over { get; set; }
        public double Cuota_under { get; set; }
    }
}