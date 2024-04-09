using BankingSystem.DataAccess.Data;
using BankingSystem.DataAccess.Entities;
using BankingSystem.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.DataAccess.Repositories.Implementations
{
    public class AccountTypeRepository : IAccountTypeRepository
    {
        private readonly BankingSystemDbContext _db;
        /// <summary>
        /// Initializes a new instance cref <see cref="AccountTypeRepository"/>
        /// </summary>
        /// <param name="db"></param>
        public AccountTypeRepository(BankingSystemDbContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Function for adding an account's type
        /// </summary>
        /// <param name="accountType"></param>
        /// <returns></returns>
        public async Task<AccountType> AddAsync(AccountType accountType)
        {
            _db.AccountTypes.Add(accountType);
            await _db.SaveChangesAsync();

            return accountType;
        }
        /// <summary>
        /// Function for deleting an account's type
        /// </summary>
        /// <param name="accountType"></param>
        /// <returns></returns>
        public async Task<AccountType> DeleteAsync(AccountType accountType)
        {
            _db.AccountTypes.Remove(accountType);
            await _db.SaveChangesAsync();

            return accountType;
        }
        /// <summary>
        /// Function for getting an account's type by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AccountType> GetByIdAsync(int id)
        {
            return await _db.AccountTypes.FirstOrDefaultAsync(c => c.Id == id);
        }
        /// <summary>
        /// Function for updating an account's type
        /// </summary>
        /// <param name="accountType"></param>
        /// <returns></returns>
        public async Task<AccountType> UpdateAsync(AccountType accountType)
        {
            _db.AccountTypes.Update(accountType);
            await _db.SaveChangesAsync();

            return accountType;
        }
        /// <summary>
        /// Function for getting an account's type  by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<AccountType> GetByNameAsync(string name)
        {
            return await _db.AccountTypes.FirstOrDefaultAsync(a => a.Name == name);
        }
    }
}
