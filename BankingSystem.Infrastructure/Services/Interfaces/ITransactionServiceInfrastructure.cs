using BankingSystem.DataAccess.Entities;

namespace BankingSystem.Infrastructure.Services.Interfaces
{
    public interface ITransactionServiceInfrastructure
    {
        /// <summary>
        /// Function for adding a transaction
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        Task<Transaction> AddAsync(Transaction transaction);
        /// <summary>
        /// Function for updating a transaction
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Transaction> UpdateAsync(int id);
        /// <summary>
        /// Function for deleting a transaction
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Transaction> DeleteAsync(int id);
        /// <summary>
        /// Function for getting a Transaction by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Transaction> GetByIdAsync(int id);
        /// <summary>
        /// Function For getting transactions
        /// </summary>
        /// <returns></returns>
        Task<int> GetTotalCountAsync();
        /// <summary>
        /// Function of using chunks for optimizing data
        /// </summary>
        /// <param name="pageNumber">Page number (1-based index)</param>
        /// <param name="chunkSize">Number of items per page</param>
        /// <returns>List of transactions for the specified page</returns>
        Task<List<Transaction>> GetPageAsync(int pageNumber, int chunkSize);
        /// <summary>
        /// Function for getting a Transaction by account number
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        Task<List<Transaction>> GetTransactionsByAccount(double accountNumber, int chunkSize);
    }
}
