using BankingSystem.AuthService.BankingSystem.DataAccess.Entities;
using BankingSystem.AuthService.BankingSystem.DataAccess.SeedData;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.AuthService.BankingSystem.DataAccess.Data
{
    /// <summary>
    /// Represent a DbContext class
    /// </summary>
    public class AuthContext : DbContext
    {
        public AuthContext(DbContextOptions<AuthContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.InitializesRoles();
            builder.InitializesUsers();
        }
        /// <summary>
        /// Gets or sets the table of users
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// Gets or sets the table of roles
        /// </summary>
        public DbSet<Role> Roles { get; set; }
    }
}
