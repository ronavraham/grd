using GRD.Models;
using Microsoft.EntityFrameworkCore;

namespace GRD.Data
{
    public class ProjectContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        { }
    }
}
