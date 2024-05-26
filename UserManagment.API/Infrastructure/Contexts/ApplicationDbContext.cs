using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UserManagment.API.Domain.Entities;

namespace UserManagment.API.Infrastructure.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserDetails> UserDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserDetails>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }
    }
}