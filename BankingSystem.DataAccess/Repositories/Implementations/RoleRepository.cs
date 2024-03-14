using BankingSystem.DataAccess.Data;
using BankingSystem.DataAccess.Entities;
using BankingSystem.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.DataAccess.Repositories.Implementations
{
    /// <summary>
    /// Represents a repository for a role
    /// </summary>
    public class RoleRepository : IRoleRepository
    {
        private readonly BankingSystemDbContext _db;
        /// <summary>
        /// Initializes a new instance cref of< see cref="RoleRepository"/>
        /// </summary>
        /// <param name="db"></param>
        public RoleRepository(BankingSystemDbContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Function for adding the role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public async Task<Role> AddAsync(Role role)
        {
            _db.Roles.Add(role);
            await _db.SaveChangesAsync();

            return role;
        }
        /// <summary>
        /// Function for deleting the role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public async Task<Role> DeleteAsync(Role role)
        {
            _db.Roles.Remove(role);
            await _db.SaveChangesAsync();

            return role;
        }
        /// <summary>
        /// Function for getting  the role by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Role> GetByIdAsync(int id)
        {
            return await _db.Roles.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
        }
        /// <summary>
        /// Function for updating  the role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public async Task<Role> UpdateAsync(Role role)
        {
            _db.Roles.Update(role);
            await _db.SaveChangesAsync();

            return role;
        }
    }
}
