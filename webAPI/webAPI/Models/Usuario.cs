﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAPI.Models
{
    public class Usuario
    {
        public Usuario(string email, string nombre, string apellido, int edad)
        {
            UsuarioId = email;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
        }

        public string UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public List<Apuesta> Apuestas { get; set; }

        public Usuario() { }
    }
}