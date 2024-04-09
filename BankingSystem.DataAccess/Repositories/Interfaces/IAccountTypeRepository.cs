using BankingSystem.DataAccess.Entities;

namespace BankingSystem.DataAccess.Repositories.Interfaces
{
    public interface IAccountTypeRepository
    {
        /// <summary>
        /// Function for adding an account's type
        /// </summary>
        /// <param name="accountType"></param>
        /// <returns></returns>
        Task<AccountType> AddAsync(AccountType accountType);
        /// <summary>
        /// Function for updating an account's type
        /// </summary>
        /// <param name="accountType"></param>
        /// <returns></returns>
        Task<AccountType> UpdateAsync(AccountType accountType);
        /// <summary>
        /// Function for deleting an account's type
        /// </summary>
        /// <param name="accountType"></param>
        /// <returns></returns>
        Task<AccountType> DeleteAsync(AccountType accountType);
        /// <summary>
        /// Function for getting an account's type by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AccountType> GetByIdAsync(int id);
        /// <summary>
        /// Function for getting an account's type by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<AccountType> GetByNameAsync(string name);
    }
}
