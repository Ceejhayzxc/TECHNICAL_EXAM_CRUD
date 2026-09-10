using EXAM.CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace EXAM.CRUD.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Persons> Persons { get; set; }
    }
}
