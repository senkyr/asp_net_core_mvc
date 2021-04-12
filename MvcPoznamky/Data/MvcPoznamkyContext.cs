using Microsoft.EntityFrameworkCore;
using MvcPoznamky.Models;

namespace MvcPoznamky.Data
{
    public class MvcPoznamkyContext : DbContext
    {
        public MvcPoznamkyContext(DbContextOptions<MvcPoznamkyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Uzivatel>()
                .HasIndex(u => u.Jmeno)
                .IsUnique();
        }

        public DbSet<Uzivatel> Uzivatele { get; set; }
        public DbSet<Poznamka> Poznamky { get; set; }
    }
}
