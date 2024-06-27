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
        /// Get the transaction by the client account
        /// </summary>
        /// <param name="clientAccountId"></param>
        /// <param name="chunkSize"></param>
        /// <returns></returns>
        public async Task<List<Transaction>> GetTransactionsByAccountAsync(int clientAccountId, int chunkSize)
        {
            List<Transaction> allTransactions = new List<Transaction>();
            int totalCount = await _db.Transactions
                                        .Where(t => t.ClientAccountId == clientAccountId)
                                        .CountAsync();

            for (int offset = 0; offset < totalCount; offset += chunkSize)
            {
                var chunk = await _db.Transactions
                                      .Include(t => t.TransactionType)
                                      .Where(t => t.ClientAccountId == clientAccountId)
                                      .OrderBy(t => t.Id)
                                      .Skip(offset)
                                      .Take(chunkSize)
                                      .ToListAsync();

                allTransactions.AddRange(chunk);
            }

            return allTransactions;
        }
        /// <summary>
        /// Get all client's transaction
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public async Task<List<Transaction>> GetAllTransactionsAsync(int pageNumber, int pageSize)
        {
            int startIndex = (pageNumber - 1) * pageSize;

            return await _db.Transactions
                .Include(c => c.TransactionType)
                .Include(c => c.ClientAccount)
           //     .ThenInclude(c => c.User)
                .OrderBy(c => c.ClientAccount)
                .Skip(startIndex)
                .Take(pageSize)
                .ToListAsync();
        }

    }
}
