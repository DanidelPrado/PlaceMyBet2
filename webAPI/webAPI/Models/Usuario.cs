using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAPI.Models
{
    public class Usuario
    {
        public Usuario(string email, string nombre, string apellido, int edad)
        {
            Email = email;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
        }

        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
    }
}