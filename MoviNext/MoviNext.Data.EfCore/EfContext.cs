using Microsoft.EntityFrameworkCore;
using MoviNext.Model;

namespace MoviNext.Data.EfCore
{
    public class EfContext : DbContext
    {
        private readonly string conString;

        public DbSet<Hardware>? Hardware { get; set; }
        public DbSet<Umrichter>? Umrichter { get; set; }
        public DbSet<Steuerung>? Steuergungen { get; set; }
        public DbSet<Subkomponente>? Subkomponenten { get; set; }

        public EfContext(string conString = "Server=(localdb)\\mssqllocaldb;Database=MovieNext_dev;Trusted_Connection=true;")
        {
            this.conString = conString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conString).UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hardware>().ToTable("Hardware");
            modelBuilder.Entity<Steuerung>().ToTable("Steuerung");
            modelBuilder.Entity<Subkomponente>().ToTable("Subkomponente");
            modelBuilder.Entity<Umrichter>().ToTable("Umrichter");

            modelBuilder.Entity<Umrichter>()
                        .HasOne(x => x.Steuerung)
                        .WithMany(x => x.Umrichter)
                        .IsRequired();

            modelBuilder.Entity<Umrichter>().HasMany(x => x.Subkomponenten)
                                            .WithOne(x => x.Umrichter)
                                            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Umrichter>().Property(x => x.LeistungsEinheit)
                                            .HasConversion(x => (byte)x, x => (LeistungsEinheit)x);

            modelBuilder.Entity<Umrichter>().Property(x => x.FrequenzEinheit)
                                            .HasConversion(x => x.ToString(), x => Enum.Parse<FrequenzEinheit>(x));
        }
    }
}