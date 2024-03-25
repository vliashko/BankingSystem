using BankingSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.DataAccess.SeedData
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
                   Username = "silicon26",
                   Email = "joyceledi26@gmail.com",
                   Password = "2601ledi",
                   RoleId = 1
               });

            builder.Entity<User>().HasData(
              new User
              {
                  Id = 2,
                  Username = "storm243",
                  Email = "parkerlewis@example.com",
                  Password = "user1password",
                  RoleId = 2
              });
        }
    }
}
