using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GRD.Models
{
    public class Purchase
    {
        [Key]
        [Display(Name = "מזהה רכישה")]
        public int Id { get; set; }
        [Display(Name = "כמות")]
        public int Count { get; set; }
        [Display(Name = "תאריך רכישה")]
        public DateTime PurchaseDate { get; set; }
        [ForeignKey("ProductId")]
        [Display(Name = "מוצר")]
        public Product Product { get; set; }
        [ForeignKey("BranchId")]
        [Display(Name = "סניף")]
        public Branch Branch { get; set; }
        [ForeignKey("UserId")]
        [Display(Name = "משתמש")]
        public User User { get; set; }
    }
}
