using BankingSystem.DataAccess.Entities;

namespace BankingSystem.Infrastructure.Services.Interfaces
{
    public interface IClientAccountServiceInfrastructure
    {
        /// <summary>
        /// Function for adding a client's account
        /// </summary>
        /// <param name="clientAccount"></param>
        /// <returns></returns>
        Task<ClientAccount> AddAsync(ClientAccount clientAccount);
        /// <summary>
        /// Function for updating a client's account
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ClientAccount> UpdateAsync(int id);
        /// <summary>
        /// Function for deleting a client's account
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ClientAccount> DeleteAsync(int id);
        /// <summary>
        /// Function for getting a client's account by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ClientAccount> GetByIdAsync(int id);

    }
}
