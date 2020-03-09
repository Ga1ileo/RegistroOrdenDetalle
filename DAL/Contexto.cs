using Microsoft.EntityFrameworkCore;
using RegistroOrdenDetalle.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroOrdenDetalle.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Orden> Orden { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DAL\Scripts\OrdenDetalles.db");
        }
    }
}
