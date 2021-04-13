using Microsoft.EntityFrameworkCore;
using MvcPoznamky.Models;

namespace MvcPoznamky.Data
{
    public class MvcPoznamkyContext : DbContext
    {
        public DbSet<Uzivatel> Uzivatele { get; set; }
        public DbSet<Poznamka> Poznamky { get; set; }

        public MvcPoznamkyContext(DbContextOptions<MvcPoznamkyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Uzivatel>()
                .HasIndex(u => u.Jmeno)
                .IsUnique();

            builder.Entity<Poznamka>()
                .HasOne(p => p.Autor)
                .WithMany(u => u.Poznamky);
        }
    }
}
