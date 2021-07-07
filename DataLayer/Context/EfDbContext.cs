using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Context
{
    public class EfDbContext : DbContext
    {

        public DbSet<Genre> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Company { get; set; }

        public EfDbContext(DbContextOptions<EfDbContext> options): base(options)
        {
           Database.EnsureCreated();
        }
    }
}
