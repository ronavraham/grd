using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public int Id { get; set; }
        public Boolean Gender { get; set; }

        public Boolean IsAdmin { get; set; }
    }
}