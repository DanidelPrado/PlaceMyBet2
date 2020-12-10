using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAPI.Models
{
    public class PlaceMyBetContext : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Apuesta> Apuestas { get; set; }
        public DbSet<Mercado> Mercados { get; set; }
        public DbSet<Evento> Eventos { get; set; }

        public PlaceMyBetContext()
        {
        }

        public PlaceMyBetContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=PlaceMyBet2;Uid=root;password=");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Apuesta>().HasData(new Apuesta(1, 1.5, 1.87, 200, "2020-10-14", 1, "AnaRS@gmail.com", "over"));
            modelbuilder.Entity<Apuesta>().HasData(new Apuesta(2, 2.5, 2.39, 150, "2020-09-15", 2, "JuanPL@gmail.com", "under"));
            modelbuilder.Entity<Apuesta>().HasData(new Apuesta(3, 3.5, 1.92, 175, "2020-09-16", 3, "PepeGB@gmail.com", "over"));
            modelbuilder.Entity<Evento>().HasData(new Evento(1, "Valencia", "Espanyol", "2020-10-17"));
            modelbuilder.Entity<Evento>().HasData(new Evento(2, "Barcelona", "Valladolid", "2020-10-30"));
            modelbuilder.Entity<Evento>().HasData(new Evento(3, "Madrid", "Villareal", "2020 -10-23"));
            modelbuilder.Entity<Mercado>().HasData(new Mercado(1, 1.43, 2.85, 100, 50, 1.5, 1));
            modelbuilder.Entity<Mercado>().HasData(new Mercado(2, 1.9, 1.9, 100, 100, 2.5, 2));
            modelbuilder.Entity<Mercado>().HasData(new Mercado(3, 2.85, 1.43, 50, 100, 3.5, 3));
            modelbuilder.Entity<Usuario>().HasData(new Usuario("AnaRS@gmail.com", "Ana", "Rodríguez Sánchez", 25));
            modelbuilder.Entity<Usuario>().HasData(new Usuario("JuanPL@gmail.com", "Juan", "Pérez López", 27));
            modelbuilder.Entity<Usuario>().HasData(new Usuario("PepeGB@gmail.com", "Pepe", "Gómez Botella", 23));
        }
    }
}