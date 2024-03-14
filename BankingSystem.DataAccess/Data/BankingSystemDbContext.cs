using BankingSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.DataAccess.Data
{
    /// <summary>
    /// Represent a DbContext class
    /// </summary>
    public class BankingSystemDbContext : DbContext
    {
        public BankingSystemDbContext(DbContextOptions<BankingSystemDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        /// <summary>
        /// Gets or sets the table of roles
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// Gets or sets the table of roles
        /// </summary>
        public DbSet<Role> Roles { get; set; }
    }
}
