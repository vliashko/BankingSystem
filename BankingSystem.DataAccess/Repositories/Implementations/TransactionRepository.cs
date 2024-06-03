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
        /// Function for the number of all  transactions
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetTotalCountAsync()
        {
            return await _db.Transactions.CountAsync();
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
            return await _db.Transactions.Include(t => t.TransactionType)
                                         .Include(c => c.ClientAccount)
                                         .ThenInclude(c => c.Passport)
                                         .FirstOrDefaultAsync(t => t.Id == id);
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
        /// <summary>
        /// Function of using chunks for optimizing data
        /// </summary>
        /// <param name="pageNumber">Page number (1-based index)</param>
        /// <param name="pageSize">Number of items per page</param>
        /// <returns>List of transaction for the specified page</returns>
        public async Task<List<Transaction>> GetPageAsync(int pageNumber, int pageSize)
        {
            int startIndex = (pageNumber - 1) * pageSize;

            return await _db.Transactions
                .OrderBy(c => c.Id)
                .Skip(startIndex)
                .Take(pageSize)
                .ToListAsync();
        }
        /// <summary>
        /// Get the transaction by the client account
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="chunkSize"></param>
        /// <returns></returns>
        public async Task<List<Transaction>> GetTransactionsByAccountAsync(double accountNumber, int chunkSize)
        {
            List<Transaction> allTransactions = new List<Transaction>();
            int totalCount = await _db.Transactions
                                        .Where(t => t.SenderNumberAccount == accountNumber)
                                        .CountAsync();

            for (int offset = 0; offset < totalCount; offset += chunkSize)
            {
                var chunk = await _db.Transactions
                                      .Include(t => t.TransactionType)
                                      .Include(c => c.ClientAccount)
                                      .ThenInclude(c => c.Passport)
                                      .Where(t => t.SenderNumberAccount == accountNumber)
                                      .OrderBy(t => t.Id)
                                      .Skip(offset)
                                      .Take(chunkSize)
                                      .ToListAsync();

                allTransactions.AddRange(chunk);
            }

            return allTransactions;
        }

    }
}
