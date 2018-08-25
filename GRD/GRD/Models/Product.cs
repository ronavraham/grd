using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }
    }

    public class Product
    {
        public double Price { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public int id { get; set; }
    }
}