using BankingSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.DataAccess.SeedData
{
    /// <summary>
    /// Represents seed data class's for card type
    /// </summary>
    public static class SeedDataCardType
    {
        /// <summary>
        /// Function for seeding a Card Type
        /// </summary>
        /// <param name="builder"></param>
        public static void InitializesCardTypes(this ModelBuilder builder)
        {
            builder.Entity<CardType>().HasData(
                new CardType
                {
                    Id = 1,
                    Name = "Debit Card"

                });
            builder.Entity<CardType>().HasData(
               new CardType
               {
                   Id = 2,
                   Name = "Credit Card"

               });
            builder.Entity<CardType>().HasData(
                new CardType
                {
                    Id = 3,
                    Name = "Corporate Card"

                });
        }
    }
}
