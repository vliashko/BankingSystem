using BankingSystem.AuthService.BankingSystem.DataAccess.Entities;

namespace BankingSystem.AuthService.BankingSystem.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Function for adding user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<User> AddAsync(User user);
        /// <summary>
        /// Function for updating user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<User> UpdateAsync(User user);
        /// <summary>
        /// Function for deleting user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<User> DeleteAsync(User user);
        /// <summary>
        /// Function for getting user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<User> GetByEmailAsync(string email);
        /// <summary>
        /// Function for getting user by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<User> GetByUsernameAsync(string username);
    }
}
