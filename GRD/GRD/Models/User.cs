using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GRD.Models
{
    public class User
    {
        [Key]
        [Display(Name = "מזהה")]
        public int Id { get; set; }
        [Required]
        [StringLength(60,MinimumLength = 0)]
        [Display(Name = "שם משתמש")]
        public string Username { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 0)]
        [Display(Name = "סיסמא")]
        public string Password { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 0)]
        [Display(Name = "כתובת מגורים")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "מין")]
        public Boolean Gender { get; set; }
        [Required]
        [Display(Name = "האם מנהל")]
        public Boolean IsAdmin { get; set; }
        // add for relations with Purchases
        public virtual List<Purchase> Purchases { get; set; }
    }
}