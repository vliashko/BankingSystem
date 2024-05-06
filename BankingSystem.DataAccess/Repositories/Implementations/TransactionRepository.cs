using BankingSystem.DataAccess.Data;
using BankingSystem.DataAccess.Entities;
using BankingSystem.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.DataAccess.Repositories.Implementations
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly BankingSystemDbContext _db;
        /// <summary>
        /// Initializes a new instance cref <see cref="TransactionRepository"/>
        /// </summary>
        /// <param name="db"></param>
        public TransactionRepository(BankingSystemDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Function for getting  transactions
        /// </summary>
        /// <returns></returns>
        public async Task<List<Transaction>> GetAllAsync()
        {
            return await _db.Transactions.Include(t => t.TransactionType)
                                         .ToListAsync();
        }
        /// <summary>
        /// Function for adding a transaction
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<Transaction> AddAsync(Transaction transaction)
        {
            _db.Transactions.Add(transaction);
            await _db.SaveChangesAsync();

            return transaction;
        }
        /// <summary>
        /// Function for deleting a transaction
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<Transaction> DeleteAsync(Transaction transaction)
        {
            _db.Transactions.Remove(transaction);
            await _db.SaveChangesAsync();

            return transaction;
        }
        /// <summary>
        /// Function for getting a transaction by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Transaction> GetByIdAsync(int id)
        {
            return await _db.Transactions.Include(t => t.TransactionType).FirstOrDefaultAsync(t => t.Id == id);
        }
        /// <summary>
        /// Function for updating a transaction
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<Transaction> UpdateAsync(Transaction transaction)
        {
            _db.Transactions.Update(transaction);
            await _db.SaveChangesAsync();

            return transaction;
        }
    
    }
}
