using BankingSystem.DataAccess.Entities;
using BankingSystem.DataAccess.SeedData;
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
            builder.InitializesCard();
            builder.InitializesCardTypes();
        }
        /// <summary>
        /// Gets or sets the table of AccountTypes
        /// </summary>
        public DbSet<AccountType> AccountTypes { get; set; }
        /// <summary>
        /// Gets or sets the table of Banks
        /// </summary>
        public DbSet<Bank> Banks { get; set; }
        /// <summary>
        /// Gets or sets the table of Cards
        /// </summary>
        public DbSet<Card> Cards { get; set; }
        /// <summary>
        /// Gets or sets the table of CardTypes
        /// </summary>
        public DbSet<CardType> CardTypes { get; set; }
        /// <summary>
        /// Gets or sets the table of ClientAccounts
        /// </summary>
        public DbSet<ClientAccount> ClientAccounts { get; set; }
        /// <summary>
        /// Gets or sets the table of Passport
        /// </summary>
        public DbSet<Passport> Passports { get; set; }
        /// <summary>
        /// Gets or sets the table of TransactionTypes
        /// </summary>
        public DbSet<TransactionType> TransactionTypes { get; set; }
        /// <summary>
        /// Gets or sets the table of Transaction
        /// </summary>
        public DbSet<Transaction> Transactions { get; set; }

    }
}
