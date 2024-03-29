﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GRD.Models
{
    public class ProductType
    {
        [Key]
        [Display(Name = "מזהה")]
        public int Id { get; set; }
        [Display(Name = "סוג מוצר")]
        public string Name { get; set; }
        [Display(Name = "מין")]
        public Boolean Gender { get; set; }
        [Display(Name = "מוצרים")]
        public virtual List<Product> Products { get; set; }
    }
}
