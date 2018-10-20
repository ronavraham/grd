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
        public int? ProductId { get; set; }
        [Display(Name = "מוצר")]
        public virtual  Product Product { get; set; }
        public int? BranchId { get; set; }
        [Display(Name = "סניף")]
        public virtual  Branch Branch { get; set; }
        public int? UserId { get; set; }
        [Display(Name = "משתמש")]
        public virtual User User { get; set; }
    }
}
