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
        public float Price { get; set; }
        public string Name { get; set; }
        public string size { get; set; }
        public int id { get; set; }
    }
}