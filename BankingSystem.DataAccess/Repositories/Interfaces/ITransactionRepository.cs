using BankingSystem.DataAccess.Entities;

namespace BankingSystem.DataAccess.Repositories.Interfaces
{
    public interface ITransactionRepository
    { 
        Task<Transaction> AddAsync(Transaction transaction);
        /// <summary>
        /// Function for updating a transaction
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        Task<Transaction> UpdateAsync(Transaction transaction);
        /// <summary>
        /// Function for deleting a transaction
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        Task<Transaction> DeleteAsync(Transaction transaction);
        /// <summary>
        /// Function for getting a Transaction by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Transaction> GetByIdAsync(int id);
        /// <summary>
        /// Function of using chunks for optimizing data
        /// </summary>
        /// <param name="pageNumber">Page number (1-based index)</param>
        /// <param name="chunkSize">Number of items per page</param>
        /// <returns>List of transactions for the specified page</returns>
        Task<List<Transaction>> GetPageAsync(int pageNumber, int chunkSize);
        /// <summary>
        /// Get the transaction by the client account
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="chunkSize"></param>
        /// <returns></returns>
        Task<List<Transaction>> GetTransactionsByAccountAsync(double accountNumber, int chunkSize);
        /// <summary>
        /// Function for the number of all  transactions
        /// </summary>
        /// <returns></returns>
        Task<int> GetTotalCountAsync();

    }
}
