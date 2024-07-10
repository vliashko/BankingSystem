using BankingSystem.AuthService.BankingSystem.DataAccess.Entities;

namespace BankingSystem.AuthService.AuthService.Infrastructure.Services.Interfaces
{
    public interface IUserServiceInfrastructure
    {
        /// <summary>
        /// Function for user's connection
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<Token> LoginAsync(string username, string password);
        /// <summary>
        /// Function for registering a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> RegisterAsync(User user);
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
        /// <summary>
        /// Function for Logging out the user
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        Task LogoutAsync(string refreshToken);
        /// <summary>
        /// Retrieve RefreshToken from the header
        /// </summary>
        /// <returns></returns>
        public string RetrieveRefreshToken();
    }
}
