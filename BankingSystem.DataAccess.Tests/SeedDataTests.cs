using BankingSystem.DataAccess.Data;
using BankingSystem.DataAccess.SeedData;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.DataAccess.Tests
{
    public class SeedDataTests
    {
        [Fact]
        public void InitializesRoles_Succeeds()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BankingSystemDbContext>()
                .UseInMemoryDatabase(databaseName: "BankingSystemDB")
                .Options;

            using (var context = new BankingSystemDbContext(options))
            {
                var modelBuilder = new ModelBuilder();
                var seedData = new SeedData();

                // Act
                seedData.InitializesRoles(modelBuilder);

                // Assert
                Assert.NotEmpty(context.Roles); // Assuming Roles property exists in YourDbContext
            }
        }

        [Fact]
        public void InitializesUsers_Succeeds()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BankingSystemDbContext>()
                .UseInMemoryDatabase(databaseName: "test_database")
                .Options;

            using (var context = new BankingSystemDbContext(options))
            {
                var modelBuilder = new ModelBuilder();
                var seedData = new SeedData();

                // Act
                seedData.InitializesUsers(modelBuilder);

                // Assert
                Assert.NotEmpty(context.Users);
            }
        }
    }
}
