using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GRD.Models
{
    public class Product
    {
        [Key]
        [Display(Name = "מזהה")]
        public int Id { get; set; }
        [Display(Name = "שם")]
        public string Name { get; set; }
        [Display(Name = "מחיר")]
        public double Price { get; set; }
        [Display(Name = "גודל")]
        public int Size { get; set; }
        [Display(Name = "תמונה")]
        public string PictureName { get; set; }
        // add for relations with Purchases
        public List<Purchase> Purchases { get; set; }
        [ForeignKey("SupplierForeignKey")]
        public Supplier Supplier { get; set; }
    }
}