using BankingSystem.DataAccess.Entities;

namespace BankingSystem.Infrastructure.Services.Interfaces
{
    public interface IAccountTypeServiceInfrastructure
    {
        /// <summary>
        /// Function for adding an account type
        /// </summary>
        /// <param name="accountType"></param>
        /// <returns></returns>
        Task<AccountType> AddAsync(AccountType accountType);
        /// <summary>
        /// Function for updating an account type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AccountType> UpdateAsync(int id);
        /// <summary>
        /// Function for deleting an account type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AccountType> DeleteAsync(int id);
        /// <summary>
        /// Function for getting a account type by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AccountType> GetByIdAsync(int id);
    }
}
