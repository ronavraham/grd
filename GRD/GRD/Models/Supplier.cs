using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GRD.Models
{
    public class Supplier
    {
        [Key]
        [Display(Name = "מזהה")]
        public int Id { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 0)]
        [Display(Name = "שם ספק")]
        public string Name { get; set; }
        [Display(Name = "רשימת מוצרים")]
        public virtual List<Product> Products { get; set; }
    }
}