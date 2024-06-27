using BankingSystem.AuthService.BankingSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
namespace BankingSystem.AuthService.BankingSystem.DataAccess.SeedData
{
    /// <summary>
    /// Represent SeedData's class
    /// </summary>
    public static class SeedData
    {
        /// <summary>
        /// Function for Initializing roles
        /// </summary>
        /// <param name="builder"></param>
        public static void InitializesRoles(this ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(
               new Role
               {
                   Id = 1,
                   RoleName = "Admin"
               });

            builder.Entity<Role>().HasData(
              new Role
              {
                  Id = 2,
                  RoleName = "Client"
              });
        }
        /// <summary>
        /// Function for Initializing users
        /// </summary>
        /// <param name="builder"></param>
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
               });

            builder.Entity<User>().HasData(
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
              });
            builder.Entity<User>().HasData(
             new User
             {
                 Id = 4,
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
}
