using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
