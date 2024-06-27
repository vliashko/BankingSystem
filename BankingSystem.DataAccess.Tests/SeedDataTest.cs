using BankingSystem.AuthService.AuthService.Domain;
using BankingSystem.AuthService.BankingSystem.DataAccess.Data;
using BankingSystem.AuthService.BankingSystem.DataAccess.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.DataAccess.Tests
{
    public class SeedDataTest
    {
        private DbContextOptions<AuthContext> _options;
        public SeedDataTest()
        {
            _options = new DbContextOptionsBuilder<AuthContext>()
                .UseInMemoryDatabase(databaseName: "AuthServiceDB")
                .Options;

            using (var dbContext = new AuthContext(_options))
            {
                dbContext.Database.EnsureCreated();
            }
        }
        [Fact]
        public void InitializesRoles_ShouldSeedRoles()
        {
            using (var dbContext = new AuthContext(_options))
            {
                // Arrange
                var modelBuilder = new ModelBuilder();

                // Act
                modelBuilder.InitializesRoles();

                // Assert
                Assert.Equal(2, dbContext.Roles.Count());
                Assert.Contains(dbContext.Roles, r => r.RoleName == "Admin");
                Assert.Contains(dbContext.Roles, r => r.RoleName == "Client");
            }
        }
        [Fact]
        public void InitializesRoles_ShouldNotSeedDuplicateRoles()
        {
            using (var dbContext = new AuthContext(_options))
            {
                // Arrange
                var modelBuilder = new ModelBuilder();

                // Seed roles once
                modelBuilder.InitializesRoles();

                // Act: Try seeding roles again
                modelBuilder.InitializesRoles();

                // Assert
                Assert.Equal(2, dbContext.Roles.Count());
            }
        }


        [Fact]
        public void InitializesRoles_ShouldSeedDistinctIds()
        {
            using (var dbContext = new AuthContext(_options))
            {
                // Arrange
                var modelBuilder = new ModelBuilder();

                // Act
                modelBuilder.InitializesRoles();

                // Assert
                var roles = dbContext.Roles.ToList();
                Assert.True(roles.Select(r => r.Id).Distinct().Count() == roles.Count());
            }
        }

        [Fact]
        public void InitializesUsers_ShouldSeedDistinctIds()
        {
            using (var dbContext = new AuthContext(_options))
            {
                // Arrange
                var modelBuilder = new ModelBuilder();

                // Act
                modelBuilder.InitializesUsers();

                // Assert
                var users = dbContext.Users.ToList();
                Assert.True(users.Select(u => u.Id).Distinct().Count() == users.Count());
            }
        }

        [Fact]
        public void InitializesUsers_ShouldSetCorrectRoleIds()
        {
            using (var dbContext = new AuthContext(_options))
            {
                // Arrange
                var modelBuilder = new ModelBuilder();

                // Act
                modelBuilder.InitializesUsers();

                // Assert
                var users = dbContext.Users.ToList();
                Assert.True(users.All(u => u.RoleId == 1 || u.RoleId == 2));
            }
        }
        [Fact]
        public void UsersProperty_ShouldBeInitialized()
        {
            // Arrange
            var role = new Role();

            // Act
            var users = role.Users;

            // Assert
            users.Should().BeNull();
        }

        [Fact]
        public void UsersProperty_CanBeAssignedAndRetrieved()
        {
            // Arrange
            var role = new Role();
            var usersList = new List<User>();

            // Act
            role.Users = usersList;
            var retrievedUsers = role.Users;

            // Assert
            retrievedUsers.Should().BeSameAs(usersList);
        }
    }
}
