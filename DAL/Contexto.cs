using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MiguelGondresPA2.Entidades;

namespace MiguelGondresPA2.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Llamadas> llamadas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DAL\DATA\RRparcial2.db");
        }

    }
}
