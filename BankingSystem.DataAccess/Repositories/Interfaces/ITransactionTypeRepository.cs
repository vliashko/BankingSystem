using BankingSystem.DataAccess.Entities;

namespace BankingSystem.DataAccess.Repositories.Interfaces
{
    public interface ITransactionTypeRepository
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
        /// <param name="transactionType"></param>
        /// <returns></returns>
        Task<TransactionType> UpdateAsync(TransactionType transactionType);
        /// <summary>
        /// Function for deleting a transaction's type
        /// </summary>
        /// <param name="transactionType"></param>
        /// <returns></returns>
        Task<TransactionType> DeleteAsync(TransactionType transactionType);
        /// <summary>
        /// Function for getting a Transaction's type by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TransactionType> GetByIdAsync(int id);
        /// <summary>
        /// Function for getting an Transaction's type by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<TransactionType> GetByNameAsync(string name);
    }
}
