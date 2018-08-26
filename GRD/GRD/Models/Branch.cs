using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public class BranchesContext : DbContext
    {
        public BranchesContext(DbContextOptions<BranchesContext> options)
            : base(options)
        { }

        public DbSet<Branch> Branches { get; set; }
    }

    public class Branch
    {
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
        public int Id { get; set; }
    }
}