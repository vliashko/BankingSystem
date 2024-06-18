using BankingSystem.DataAccess.Data;
using BankingSystem.DataAccess.Entities;
using BankingSystem.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.DataAccess.Repositories.Implementations
{
    public class BankRepository : IBankRepository
    {
        private readonly BankingSystemDbContext _db;
        /// <summary>
        /// Initializes a new instance cref of <see cref ="BankRepository" >
        /// </summary>
        /// <param name="db"></param>
        public BankRepository(BankingSystemDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Function for adding a bank
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        public async Task<Bank> AddAsync(Bank bank)
        {
            _db.Banks.Add(bank);
            await _db.SaveChangesAsync();

            return bank;
        }
        /// <summary>
        /// Function for deleting a bank
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        public async Task<Bank> DeleteAsync(Bank bank)
        {
            _db.Banks.Remove(bank);
            await _db.SaveChangesAsync();

            return bank;
        }
        /// <summary>
        /// Function for getting a bank by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Bank> GetByIdAsync(int id)
        {
            return await _db.Banks.FirstOrDefaultAsync(b => b.Id == id);
        }
        /// <summary>
        /// Function for updating a bank
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        public async Task<Bank> UpdateAsync(Bank bank)
        {
            _db.Banks.Update(bank);
            await _db.SaveChangesAsync();

            return bank;
        }
        /// <summary>
        /// Function for getting a bank  by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Bank> GetByNameAsync(string name)
        {
            return await _db.Banks.FirstOrDefaultAsync(b => b.Name == name);
        }
        /// <summary>
        /// Get all banks
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public async Task<List<Bank>> GetAllAsync(int pageNumber, int pageSize)
        {
            int startIndex = (pageNumber - 1) * pageSize;

            return await _db.Banks
                .OrderBy(c => c.Name)
                .Skip(startIndex)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
