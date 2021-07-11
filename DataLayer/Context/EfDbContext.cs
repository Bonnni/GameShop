using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Context
{
    public class EfDbContext : DbContext
    {

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Company { get; set; }

        public EfDbContext(DbContextOptions<EfDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .ToTable("genre");
            modelBuilder.Entity<Product>()
                .ToTable("product");
            modelBuilder.Entity<Company>()
                .ToTable("company");
        }
    }
}
