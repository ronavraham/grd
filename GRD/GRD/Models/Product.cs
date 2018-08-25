using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "מזהה")]
        public int id { get; set; }
        [Display(Name = "שם")]
        public string Name { get; set; }
        [Display(Name = "מחיר")]
        public double Price { get; set; }
        [Display(Name = "גודל")]
        public int Size { get; set; }
        [Display(Name = "תמונה")]
        public string PictureName { get; set; }
    }
}