using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
    }

    public class User
    {
        [Display(Name = "שם משתמש")]
        public string Username { get; set; }
        [Display(Name = "סיסמא")]
        public string Password { get; set; }
        [Display(Name = "כתובת מגורים")]
        public string Address { get; set; }
        [Display(Name = "מזהה")]
        public int Id { get; set; }
        [Display(Name = "מין")]
        public Boolean Gender { get; set; }
        [Display(Name = "האם מנהל")]
        public Boolean IsAdmin { get; set; }
    }
}