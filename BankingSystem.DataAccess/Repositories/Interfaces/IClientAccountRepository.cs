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
        /// Function for getting a client's account by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ClientAccount> GetByUserIdAsync(int userId);
        /// <summary>
        /// Function for getting number of all client's accounts
        /// </summary>
        /// <returns></returns>
        Task<int> GetTotalCountAsync();
        /// <summary>
        /// Function for getting a client's account by his account's number
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        Task<ClientAccount> GetByAccountNumberAsync(double accountNumber);
        /// <summary>
        /// Function of using chunks for optimizing data
        /// </summary>
        /// <param name="pageNumber">Page number (1-based index)</param>
        /// <param name="chunkSize">Number of items per page</param>
        /// <returns>List of client's account for the specified page</returns>
        Task<List<ClientAccount>> GetPageAsync(int pageNumber, int chunkSize);
    }
}
