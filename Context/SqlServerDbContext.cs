using Infera_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Infera_WebApi.Context
{
    public class SqlServerDbContext:DbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> opt): base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Users table
            modelBuilder.Entity<User>()
                .HasIndex(b => b.Email)
                .IsUnique();
            #endregion

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
