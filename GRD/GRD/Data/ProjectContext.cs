﻿using GRD.Models;
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
                .HasForeignKey(p => p.SupplierForeignKey);
        }
    }
}
