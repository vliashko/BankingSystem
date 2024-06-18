using BankingSystem.DataAccess.Entities;

namespace BankingSystem.Infrastructure.Services.Interfaces
{
    public interface IBankServiceInfrastructure
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
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Bank> UpdateAsync(int id);
        /// <summary>
        /// Function for deleting a bank
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Bank> DeleteAsync(int id);
        /// <summary>
        /// Function for getting a bank by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Bank> GetByIdAsync(int id);
        /// <summary>
        /// Get all banks
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        Task<List<Bank>> GetAllAsync(int pageSize, int pageNumber);
    }
}
