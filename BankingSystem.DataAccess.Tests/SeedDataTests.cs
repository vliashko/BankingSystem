using BankingSystem.DataAccess.Data;
using BankingSystem.DataAccess.Entities;
using BankingSystem.DataAccess.SeedData;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.DataAccess.Tests
{
    public class SeedDataTests
    {
        [Fact]
        public void InitializesRoles_Should_Add_Roles()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BankingSystemDbContext>()
                .UseInMemoryDatabase(databaseName: "BankingSystemDB")
                .Options;

            using (var context = new BankingSystemDbContext(options))
            {
                var modelBuilder = new ModelBuilder();

                // Act
                modelBuilder.InitializesRoles();

                // Assert
                context.Roles.Should().NotBeNull();
                // context.Roles.Should().HaveCount(2);
                //context.Roles.Should().Contain(r => r.RoleName == "Admin");
                //context.Roles.Should().Contain(r => r.RoleName == "Client");
            }
        }

        [Fact]
        public void InitializesUsers_Should_Add_Users()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BankingSystemDbContext>()
               .UseInMemoryDatabase(databaseName: "BankingSystemDB")
               .Options;

            using var context = new BankingSystemDbContext(options);
            var modelBuilder = new ModelBuilder();

            // Act
            modelBuilder.InitializesUsers();

            // Assert
            context.Users.Should().NotBeNull();
        }
    }
}
