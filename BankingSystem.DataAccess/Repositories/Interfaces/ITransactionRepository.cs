using BankingSystem.DataAccess.Entities;

namespace BankingSystem.DataAccess.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        /// <summary>
        /// Function for getting  transactions
        /// </summary>
        /// <returns></returns>
        Task<List<Transaction>> GetAllAsync();
        /// <summary>
        /// Function for adding a transaction
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
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
    }
}
