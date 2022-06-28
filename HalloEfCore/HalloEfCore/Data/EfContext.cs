using HalloEfCore.Model;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("HalloEfCore.Tests")]

namespace HalloEfCore.Data
{
    internal class EfContext : DbContext
    {
        public DbSet<Abteilung> Abteilungen { get; set; }
        public DbSet<Kunde> Kunden { get; set; }
        public DbSet<Mitarbeiter> Mitarbeiter { get; set; }
        public DbSet<Person> Persons { get; set; }

 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Mitarbeiter>().ToTable("Mitarbeiter");
            modelBuilder.Entity<Kunde>().ToTable("Kunden");
            modelBuilder.Entity<Mitarbeiter>().Property(x => x.Beruf).HasColumnName("BBBBBBBBeruf");
        }

        string conString;

        public EfContext(string conString = "Server=(localdb)\\mssqllocaldb;Database=HalloEfCore;Trusted_Connection=true")
        {
            this.conString = conString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(conString);
        }
    }
}
