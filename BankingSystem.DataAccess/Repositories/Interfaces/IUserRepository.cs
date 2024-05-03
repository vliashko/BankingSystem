using BankingSystem.DataAccess.Entities;

namespace BankingSystem.DataAccess.Repositories.Interfaces
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
        /// <param name="name"></param>
        /// <returns></returns>
        Task<User> GetByEmailAsync(string email);
    }
}
