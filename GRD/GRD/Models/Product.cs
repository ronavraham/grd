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
        [Required]
        [Display(Name = "שם")]
        [StringLength(60, MinimumLength = 0)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "מחיר")]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        [Required]
        [Display(Name = "גודל")]
        [Range(0, int.MaxValue)]
        public int Size { get; set; }
        [Display(Name = "תמונה")]
        public string PictureName { get; set; }
        // add for relations with Purchases
        public virtual List<Purchase> Purchases { get; set; }

        public int? SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        public int? ProductTypeId { get; set; }
        [Display(Name = "סוג")]
        public virtual ProductType ProductType { get; set; }
    }
}