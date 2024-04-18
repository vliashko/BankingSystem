using BankingSystem.DataAccess.Entities;

namespace BankingSystem.DataAccess.Repositories.Interfaces
{
    public interface IBankRepository
    {
        /// <summary>
        /// Function for adding a bank
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        Task<Bank> AddAsync(Bank bank);
        /// <summary>
        /// Function for updating a bank
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        Task<Bank> UpdateAsync(Bank bank);
        /// <summary>
        /// Function for deleting a bank
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        Task<Bank> DeleteAsync(Bank bank);
        /// <summary>
        /// Function for getting a bank by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Bank> GetByIdAsync(int id);
        /// <summary>
        /// Function for getting a Bank by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<Bank> GetByNameAsync(string name);
    }
}
