using BankingSystem.DataAccess.Entities;

namespace BankingSystem.DataAccess.Repositories.Interfaces
{
    public interface IClientAccountRepository
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
        /// <param name="clientAccount"></param>
        /// <returns></returns>
        Task<ClientAccount> UpdateAsync(ClientAccount clientAccount);
        /// <summary>
        /// Function for deleting a client's account
        /// </summary>
        /// <param name="clientAccount"></param>
        /// <returns></returns>
        Task<ClientAccount> DeleteAsync(ClientAccount clientAccount);
        /// <summary>
        /// Function for getting a client's account by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ClientAccount> GetByIdAsync(int id);
        /// <summary>
        /// Function for getting a client's account by his passport identificator
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ClientAccount> GetByPassportIdAsync(int id);
        /// <summary>
        /// Function for getting all client's accounts
        /// </summary>
        /// <returns></returns>
        Task<List<ClientAccount>> GetAllAsync();
        /// <summary>
        /// Function for getting a client's account by his account's number
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        Task<ClientAccount> GetByAccountNumberAsync(double accountNumber);
    }
}
