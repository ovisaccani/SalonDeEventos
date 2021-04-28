using Microsoft.EntityFrameworkCore;
using ProySalonDeEventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProySalonDeEventos.Context
{
    public class SalonDatabaseContext: DbContext
    {
        public
       SalonDatabaseContext(DbContextOptions<SalonDatabaseContext> options)
       : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evento>()
                .HasOne<Reserva>(s => s.reserva)
                .WithOne(ad => ad.Evento)
                .HasForeignKey<Reserva>(ad => ad.CurrentIdEvento);



           /* modelBuilder.Entity<Reserva>()
                .HasOne<Evento>(s => s.evento)
                .WithOne(ad => ad.reserva)
                .HasForeignKey<Evento>(ad => ad.IdEvento);*/





            modelBuilder.Entity<Reserva>()
              .HasOne<Cliente>(s => s.Cliente)
              .WithMany(g => g.reservas)
              .HasForeignKey(s => s.CurrentIdCliente);

        }


        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Presupuesto> Presupuestos { get; set; }
        public DbSet<Evento> Eventos { get; set; }

    }
}

