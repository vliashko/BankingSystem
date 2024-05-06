using BankingSystem.DataAccess.Data;
using BankingSystem.DataAccess.Entities;
using BankingSystem.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.DataAccess.Repositories.Implementations
{
    public class ClientAccountRepository : IClientAccountRepository
    {
        private readonly BankingSystemDbContext _db;
        /// <summary>
        /// Initializes a new instance cref <see cref="ClientAccountRepository"/>
        /// </summary>
        /// <param name="db"></param>
        public ClientAccountRepository(BankingSystemDbContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Function for adding a client;s account
        /// </summary>
        /// <param name="clientAccount"></param>
        /// <returns></returns>
        public async Task<ClientAccount> AddAsync(ClientAccount clientAccount)
        {
            _db.ClientAccounts.Add(clientAccount);
            await _db.SaveChangesAsync();

            return clientAccount;
        }
        /// <summary>
        /// Function for deleting a client account
        /// </summary>
        /// <param name="clientAccount"></param>
        /// <returns></returns>
        public async Task<ClientAccount> DeleteAsync(ClientAccount clientAccount)
        {
            _db.ClientAccounts.Remove(clientAccount);
            await _db.SaveChangesAsync();

            return clientAccount;
        }
        /// <summary>
        /// Function for getting a client's account by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ClientAccount> GetByIdAsync(int id)
        {
            return await _db.ClientAccounts.Include(c => c.Bank)
                .Include(c => c.AccountType)
                .Include(c => c.Passport)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        /// <summary>
        /// Function for updating a client's account
        /// </summary>
        /// <param name="clientAccount"></param>
        /// <returns></returns>
        public async Task<ClientAccount> UpdateAsync(ClientAccount clientAccount)
        {
            _db.ClientAccounts.Update(clientAccount);
            await _db.SaveChangesAsync();

            return clientAccount;
        }
        /// <summary>
        /// Function for getting a client's account by his passport's identificator
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ClientAccount> GetByPassportIdAsync(int id) 
        {
            return await _db.ClientAccounts.FirstOrDefaultAsync(c => c.PassportId == id);
        }
        /// <summary>
        /// Function for getting all client's accounts
        /// </summary>
        /// <returns></returns>
        public async Task<List<ClientAccount>> GetAllAsync() 
        {
            return await _db.ClientAccounts.Include(c => c.Bank)
                .Include(c => c.AccountType)
                .Include(c => c.Passport).ToListAsync();
        }
        /// <summary>
        /// Function for getting a client's account by his account number
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public async Task<ClientAccount> GetByAccountNumberAsync(double accountNumber)
        {
            return await _db.ClientAccounts.FirstOrDefaultAsync(c => c.AccountNumber == accountNumber);
        }
    }
}
