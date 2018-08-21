using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
        public float Lat { get; set; }
        public float Long { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public Boolean IsSaturday { get; set; }
        public int Id { get; set; }
    }
}