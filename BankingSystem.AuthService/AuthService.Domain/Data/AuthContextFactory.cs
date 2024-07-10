using BankingSystem.AuthService.BankingSystem.DataAccess.Data;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.AuthService.AuthService.Domain.Data
{
    public class AuthContextFactory : IDesignTimeDbContextFactory<AuthContext>
    {
        public AuthContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<AuthContext>();
            var connectionString = configuration.GetConnectionString("Database");
            builder.UseSqlServer(connectionString);

            return new AuthContext(builder.Options);
        }
    }
}
