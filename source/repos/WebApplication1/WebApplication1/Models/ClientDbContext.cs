using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ClientDbContext : DbContext
    {

        public DbSet<Zamówienie> Zamówienia { get; set; }
        public DbSet<Zamowienie_WyrobCukierniczy> ZamowienieWyrob { get; set; }
        public DbSet<WyrobCukierniczy> WyrobCukierniczy { get; set; }
        public DbSet<Klient> Klienci { get; set; }
        public ClientDbContext()
        {

        }

        public ClientDbContext(DbContextOptions options) : base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Zamowienie_WyrobCukierniczy>()
                .HasKey(z => new { z.IdZamowienia, z.IdWyrobuCukierniczego });
        }
    }
}
