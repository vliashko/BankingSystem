using BankingSystem.DataAccess.Entities;

namespace BankingSystem.Infrastructure.Services.Interfaces
{
    public interface IUserServiceInfrastructure
    {
        /// <summary>
        /// Function for getting token from the server
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<string> GetUserTokenAsync(string username, string password);
        Task<HttpResponseMessage> RegisterUserAsync(string username, string password);

    }
}
