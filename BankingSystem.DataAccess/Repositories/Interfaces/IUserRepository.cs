using BankingSystem.DataAccess.Entities;

namespace BankingSystem.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Adding user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<User> AddAsync(User user);
        /// <summary>
        /// Updates the details of an existing user.
        /// </summary>
        /// <param name="user">The updated user details.</param>
        /// <returns></returns>
        Task<User> UpdateAsync(User user);
        /// <summary>
        /// Function for Deleting a user.
        /// </summary>
        /// <returns></returns>
        Task<User> DeleteAsync(User user);
        /// <summary>
        /// Function for getting a user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<User> GetByEmailAsync(string email);
    }
}
