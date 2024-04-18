using BankingSystem.DataAccess.Entities;

namespace BankingSystem.Infrastructure.Services.Interfaces
{
    public interface IUserServiceInfrastructure
    {
        /// <summary>
        /// Function for user's connection
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<string> LoginAsync(string username, string password);
        /// <summary>
        /// Function for registering a user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> RegisterAsync(string username, string password);
        /// <summary>
        /// Function for creating a confirmation email
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        EmailSender CreateConfirmationEmail(string emailAddress);

    }
}
