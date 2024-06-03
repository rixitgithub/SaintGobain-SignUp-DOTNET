using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SignupApi.Models
{
    public class UserDetailContext : DbContext
    {
        public UserDetailContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserDetails> UserDetails { get; set; }
    }
}

