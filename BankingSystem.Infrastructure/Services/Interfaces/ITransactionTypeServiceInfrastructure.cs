using BankingSystem.DataAccess.Entities;

namespace BankingSystem.Infrastructure.Services.Interfaces
{
    public interface ITransactionTypeServiceInfrastructure
    {
        /// <summary>
        /// Function for adding a transaction's type
        /// </summary>
        /// <param name="transactionType"></param>
        /// <returns></returns>
        Task<TransactionType> AddAsync(TransactionType transactionType);
        /// <summary>
        /// Function for updating a transaction's type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TransactionType> UpdateAsync(int id);
        /// <summary>
        /// Function for deleting a transaction's type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TransactionType> DeleteAsync(int id);
        /// <summary>
        /// Function for getting a Transaction's type by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TransactionType> GetByIdAsync(int id);
    }
}
