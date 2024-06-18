using BankingSystem.DataAccess.Data;
using BankingSystem.DataAccess.Entities;
using BankingSystem.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.DataAccess.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly BankingSystemDbContext _db;
        /// <summary>
        /// Initializes a new instance cref<see cref="UserRepository"/>
        /// </summary>
        /// <param name="db"></param>
        public UserRepository(BankingSystemDbContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Function for adding a user
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
        /// Function for deleting a user
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
        /// Function for getting a user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<User> GetByEmailAsync(string email)
        {
            return await _db.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == email);
        }
        /// <summary>
        /// Function for updating a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> UpdateAsync(User user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();

            return user;
        }
        /// <summary>
        /// Function for getting a user by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<User> GetByUsernameAsync(string username) 
        {
            return await _db.Users.Include(u => u.ClientAccount)
                                  .Include(u => u.Role)
                                  .FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
