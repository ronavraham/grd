using System;
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
        [Display(Name = "שם")]
        public string Name { get; set; }
        [Display(Name = "מוצרים")]
        public List<Product> Products;
    }
}
