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
        public DbSet<Supplier> Suppliers { get; set; }
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Branch)
                .WithMany(b => b.Purchases)
                .HasForeignKey(p => p.BranchId);

            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.User)
                .WithMany(b => b.Purchases)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Product)
                .WithMany(b => b.Purchases)
                .HasForeignKey(p => p.ProductId);
        }
    }
}
