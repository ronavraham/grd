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
        [DisplayName("קו רוחב")]
        public double Lat { get; set; }
        [DisplayName("קו אורך")]
        public double Long { get; set; }
        [DisplayName("שם")]
        public string Name { get; set; }
        [DisplayName("עיר")]
        public string City { get; set; }
        [DisplayName("כתובת")]
        public string Address { get; set; }
        [DisplayName("טלפון")]
        public string Telephone { get; set; }
        [DisplayName("פתוח בשבת")]
        public Boolean IsSaturday { get; set; }
        // add for relations with Purchases
        public virtual List<Purchase> Purchases { get; set; }
    }
}