using BankingSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.DataAccess.SeedData
{
    /// <summary>
    /// Represent SeedData's class
    /// </summary>
    public static class SeedDataCard
    {
        /// <summary>
        /// Function for Initializing for seeding card
        /// </summary>
        /// <param name="builder"></param>
        public static void InitializesCard(this ModelBuilder builder)
        {
            builder.Entity<Card>().HasData(
               new Card
               {
                   Id = 1,
                   Name = "Joseph Ledi",
                   DateIssued = DateTime.Now,
                   DateExpired = new DateTime(2029, 04, 03),
                   CardTypeId = 1,
                   SecurityCode = 01785
               });

            builder.Entity<Card>().HasData(
              new Card
              {
                  Id = 2,
                  Name = "Barron Louis",
                  DateIssued = DateTime.Now,
                  DateExpired = new DateTime(2029, 04, 03),
                  CardTypeId = 2,
                  SecurityCode = 01985
              });
            builder.Entity<Card>().HasData(
              new Card
              {
                  Id = 3,
                  Name = "Marlon Murphy",
                  DateIssued = DateTime.Now,
                  DateExpired = new DateTime(2029, 04, 03),
                  CardTypeId = 3,
                  SecurityCode = 01795
              });
        }
    }
}
