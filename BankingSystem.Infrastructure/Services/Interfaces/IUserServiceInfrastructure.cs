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
        /// <param name="user"></param>
        /// <returns></returns>
        Task <HttpResponseMessage>RegisterAsync(User user);
        /// <summary>
        /// Function for creating a confirmation email
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        EmailSender CreateConfirmationEmail(string emailAddress);
        /// <summary>
        /// Function for deleting a user 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<User> DeleteAsync(string email);
        /// <summary>
        /// Function for updating a user
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<User> UpdateAsync(string email);
        /// <summary>
        /// Function for getting a user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<User> GetByEmailAsync(string email);
    }
}
