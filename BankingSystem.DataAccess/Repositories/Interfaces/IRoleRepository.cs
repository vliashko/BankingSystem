using BankingSystem.DataAccess.Entities;

namespace BankingSystem.DataAccess.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        /// <summary>
        /// Adding Role.
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        Task<Role> AddAsync(Role role);
        /// <summary>
        /// Updates the details of an existing role.
        /// </summary>
        /// <param name="role">The updated role details.</param>
        /// <returns></returns>
        Task<Role> UpdateAsync(Role role);
        /// <summary>
        /// Function for Deleting a role.
        /// </summary>
        /// <returns></returns>
        Task<Role> DeleteAsync(Role role);
        /// <summary>
        /// Function for getting a role by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Role> GetByIdAsync(int id);
    }
}
