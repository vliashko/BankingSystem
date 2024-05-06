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
        Task<List<Transaction>> GetAllAsync();
    }
}
