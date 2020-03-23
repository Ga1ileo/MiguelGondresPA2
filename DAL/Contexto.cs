using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MiguelGondresPA2.Entidades;

namespace MiguelGondresPA2.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Llamadas> Llamadas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DAL\DATA\RRparcial2.db");
        }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Llamadas>().HasData(new Llamadas { LlamadaId = 1, Descripcion = "Guitarra" });
            modelBuilder.Entity<LlamadaDetalle>().HasData(new LlamadaDetalle { LlamadaDetalleId = 1, LlamadaId = 1, Problema = "Sin Cuerdas", Solucion = "Comprar Cuerdas" });
            modelBuilder.Entity<Llamadas>().HasData(new Llamadas { LlamadaId = 2, Descripcion = "Celular" });
            modelBuilder.Entity<LlamadaDetalle>().HasData(new LlamadaDetalle { LlamadaDetalleId = 2, LlamadaId = 2, Problema = "Sin Bateria", Solucion = "Comprar Bateria" });


        }
    }
}
