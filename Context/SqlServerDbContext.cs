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
            #region Users
            modelBuilder.Entity<User>()
                .HasIndex(b => b.Email)
                .IsUnique();
            #endregion

            #region UserRoles

            //modelBuilder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>().HasOne(ur => ur.User).WithMany(u => u.Roles)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<UserRole>().HasOne(ur => ur.Role).WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            #endregion

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
