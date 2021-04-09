using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Data
{
    public class MvcContext : DbContext
    {
        public MvcContext(DbContextOptions<MvcContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Uzivatel>()
                .HasIndex(u => u.Jmeno)
                .IsUnique();
        }

        public DbSet<Uzivatel> Uzivatele { get; set; }
    }
}
