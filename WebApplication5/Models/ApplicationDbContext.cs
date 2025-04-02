using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Song> Songs { get; set; }

    }
}
