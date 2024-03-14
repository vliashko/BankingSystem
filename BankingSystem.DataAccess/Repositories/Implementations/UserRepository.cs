using BankingSystem.DataAccess.Data;
using BankingSystem.DataAccess.Entities;
using BankingSystem.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.DataAccess.Repositories.Implementations
{
    /// <summary>
    /// Represents a Repository for the user
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly BankingSystemDbContext _db;
        /// <summary>
        /// Initializes a new instance cref of< see cref="UserRepository"/>
        /// </summary>
        /// <param name="db"></param>
        public UserRepository(BankingSystemDbContext db) 
        {
            _db = db;
        }
        /// <summary>
        /// Function for adding the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> AddAsync(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return user;
        }
        /// <summary>
        /// Function for deleting the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> DeleteAsync(User user)
        {
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();

            return user;
        }
        /// <summary>
        /// Function for Getting the user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<User> GetByEmailAsync(string email)
        {
            return await _db.Users.AsNoTracking()
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == email);
        }
        /// <summary>
        /// Function for updating the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> UpdateAsync(User user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();

            return user;
        }
    }
}
