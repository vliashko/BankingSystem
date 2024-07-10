using BankingSystem.AuthService.BankingSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.AuthService.AuthService.Domain;

/// <summary>
/// Represents the SeedData class.
/// </summary>
public static class SeedData
{
    /// <summary>
    /// Function for initializing roles.
    /// </summary>
    /// <param name="builder">The model builder.</param>
    public static void InitializesRoles(this ModelBuilder builder)
    {
        builder.Entity<Role>().HasData(
            new Role
            {
                Id = 1,
                RoleName = "Admin"
            },
            new Role
            {
                Id = 2,
                RoleName = "Client"
            });
    }

    /// <summary>
    /// Function for initializing users.
    /// </summary>
    /// <param name="builder">The model builder.</param>
    public static void InitializesUsers(this ModelBuilder builder)
    {
        builder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Username = "renoi26",
                Email = "joyceledi26@gmail.com",
                FirstName = "Joyce",
                LastName = "Ledi",
                AgreeToGetEmail = false,
                Password = "2601ledi",
                RoleId = 1
            },
            new User
            {
                Id = 2,
                Username = "storm243",
                Email = "parkerlewis@example.com",
                FirstName = "Parker",
                LastName = "Lewis",
                AgreeToGetEmail = true,
                Password = "user1password",
                RoleId = 2
            },
            new User
            {
                Id = 3, // Corrigé pour avoir un identifiant unique et cohérent
                Username = "tyron26",
                Email = "tyron@gmail.com",
                FirstName = "Tyron",
                LastName = "Ledi",
                AgreeToGetEmail = true,
                Password = "cocoti43",
                RoleId = 2
            });
    }
}
