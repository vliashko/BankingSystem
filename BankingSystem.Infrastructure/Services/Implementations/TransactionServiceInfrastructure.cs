using BankingSystem.DataAccess.Entities;
using BankingSystem.DataAccess.Repositories.Interfaces;
using BankingSystem.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace BankingSystem.Infrastructure.Services.Implementations
{
    public class TransactionServiceInfrastructure : ITransactionServiceInfrastructure
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ILogger<TransactionServiceInfrastructure> _logger;
        /// <summary>
        /// Initializes a new instance cref<see cref="TransactionServiceInfrastructure"/>
        /// </summary>
        /// <param name="transactionRepository"></param>
        /// <param name="logger"></param>
        public TransactionServiceInfrastructure(ITransactionRepository transactionRepository, ILogger<TransactionServiceInfrastructure> logger)
        {
            _transactionRepository = transactionRepository;
            _logger = logger;
        }

        /// <summary>
        /// Function for adding a transaction
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Transaction> AddAsync(Transaction transaction)
        {
            var addedTransactionType = await _transactionRepository.AddAsync(transaction);

            return addedTransactionType;
        }
        /// <summary>
        /// Function for deleting a transaction
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Transaction> DeleteAsync(int id)
        {
            var transactionLooked = await _transactionRepository.GetByIdAsync(id);

            if (transactionLooked is null)
            {
                _logger.LogError("This transaction does not exist");
                throw new Exception("This transaction does not exist");
            }

            var deletedTransaction = await _transactionRepository.DeleteAsync(transactionLooked);

            return deletedTransaction;
        }
        /// <summary>
        /// Function for getting a transaction by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Transaction> GetByIdAsync(int id)
        {
            var transactionLooked = await _transactionRepository.GetByIdAsync(id);

            if (transactionLooked is null)
            {
                _logger.LogError("This transaction does not exist");
                throw new Exception("This transaction does not exist");
            }

            return transactionLooked;
        }
        /// <summary>
        /// Function for updating a transaction
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Transaction> UpdateAsync(int id)
        {
            var transactionLooked = await _transactionRepository.GetByIdAsync(id);

            if (transactionLooked is null)
            {
                _logger.LogError("This transaction does not exist");
                throw new Exception("This transaction does not exist");
            }

            var deletedTransaction = await _transactionRepository.UpdateAsync(transactionLooked);

            return deletedTransaction;
        }
        /// <summary>
        /// Function For getting transactions
        /// </summary>
        /// <returns></returns>
        public async Task<List<Transaction>> GetAllAsync() 
        {
            var transactions = await _transactionRepository.GetAllAsync();

            if (transactions is null)
            {
                _logger.LogError("There is no transactions");
                throw new Exception("There is no transactions");
            }

            return transactions;
        }
    }
}
