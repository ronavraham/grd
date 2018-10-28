using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GRD.Models
{
    public class Branch
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("קו רוחב")]
        public double Lat { get; set; }
        [Required]
        [DisplayName("קו אורך")]
        public double Long { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 0)]
        [DisplayName("שם")]
        public string Name { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 0)]
        [DisplayName("עיר")]
        public string City { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 0)]
        [DisplayName("כתובת")]
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "המספר שהזנת אינו תקין")]
        [DisplayName("טלפון")]
        public string Telephone { get; set; }
        [DisplayName("פתוח בשבת")]
        public Boolean IsSaturday { get; set; }
        // add for relations with Purchases
        public virtual List<Purchase> Purchases { get; set; }
    }
}