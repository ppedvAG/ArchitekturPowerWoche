using HalloEfCore.Model;
using Microsoft.EntityFrameworkCore;

namespace HalloEfCore.Data
{
    internal class EfContext : DbContext
    {
        public DbSet<Abteilung> Abteilungen { get; set; }
        public DbSet<Kunde> Kunden { get; set; }
        public DbSet<Mitarbeiter> Mitarbeiter { get; set; }

        public EfContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conString = "Server=(localdb)\\mssqllocaldb;Database=HalloEfCore;Trusted_Connection=true";

            optionsBuilder.UseSqlServer(conString);
        }
    }
}
