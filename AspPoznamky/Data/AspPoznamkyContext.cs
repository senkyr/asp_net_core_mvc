using Microsoft.EntityFrameworkCore;
using AspPoznamky.Models;

namespace AspPoznamky.Data
{
    public class AspPoznamkyContext : DbContext
    {
        public DbSet<Uzivatel> Uzivatele { get; set; }
        public DbSet<Poznamka> Poznamky { get; set; }

        public AspPoznamkyContext(DbContextOptions<AspPoznamkyContext> options) : base(options) { }

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
