using BankingSystem.DataAccess.Data;
using BankingSystem.DataAccess.Entities;
using BankingSystem.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.DataAccess.Repositories.Implementations
{
    public class TransactionTypeRepository: ITransactionTypeRepository
    {
        private readonly BankingSystemDbContext _db;
        /// <summary>
        /// Initializes a new instance cref <see cref="TransactionTypeRepository"/>
        /// </summary>
        /// <param name="db"></param>
        public TransactionTypeRepository(BankingSystemDbContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Function for adding a transaction's type
        /// </summary>
        /// <param name="transactionType"></param>
        /// <returns></returns>
        public async Task<TransactionType> AddAsync(TransactionType transactionType)
        {
            _db.TransactionTypes.Add(transactionType);
            await _db.SaveChangesAsync();

            return transactionType;
        }
        /// <summary>
        /// Function for deleting an transaction's type
        /// </summary>
        /// <param name="transactionType"></param>
        /// <returns></returns>
        public async Task<TransactionType> DeleteAsync(TransactionType transactionType)
        {
            _db.TransactionTypes.Remove(transactionType);
            await _db.SaveChangesAsync();

            return transactionType;
        }
        /// <summary>
        /// Function for getting a transaction's type by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TransactionType> GetByIdAsync(int id)
        {
            return await _db.TransactionTypes.FirstOrDefaultAsync(t => t.Id == id);
        }
        /// <summary>
        /// Function for updating an transaction's type
        /// </summary>
        /// <param name="transactionType"></param>
        /// <returns></returns>
        public async Task<TransactionType> UpdateAsync(TransactionType transactionType)
        {
            _db.TransactionTypes.Update(transactionType);
            await _db.SaveChangesAsync();

            return transactionType;
        }
        /// <summary>
        /// Function for getting a transaction's type  by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<TransactionType> GetByNameAsync(string name)
        {
            return await _db.TransactionTypes.FirstOrDefaultAsync(a => a.Name == name);
        }
    }
}
