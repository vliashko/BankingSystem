using BankingSystem.DataAccess.Entities;
using BankingSystem.DataAccess.Repositories.Interfaces;
using BankingSystem.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace BankingSystem.DataAccess.Repositories.Implementations
{
    public class TransactionTypeServiceInfrastructure : ITransactionTypeServiceInfrastructure
    {
        private readonly ITransactionTypeRepository _transactionTypeRepository;
        private readonly ILogger<TransactionTypeServiceInfrastructure> _logger;
        /// <summary>
        /// Initializes a new instance cref<see cref="TransactionTypeServiceInfrastructure"/>
        /// </summary>
        /// <param name="transactionTypeRepository"></param>
        /// <param name="logger"></param>
        public TransactionTypeServiceInfrastructure(ITransactionTypeRepository transactionTypeRepository, ILogger<TransactionTypeServiceInfrastructure> logger)
        {
            _transactionTypeRepository = transactionTypeRepository;
            _logger = logger;
        }
        /// <summary>
        /// Function for adding a type of transaction
        /// </summary>
        /// <param name="transactionType"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<TransactionType> AddAsync(TransactionType transactionType)
        {
            var transactionTypeLooked = await _transactionTypeRepository.GetByNameAsync(transactionType.Name);

            if (transactionTypeLooked is not null)
            {
                _logger.LogError("This type of transaction already exists");
                throw new Exception("This type of transaction  exists already");
            }

            var addedTransactionType = await _transactionTypeRepository.AddAsync(transactionType);

            return addedTransactionType;
        }
        /// <summary>
        /// Function for deleting a transaction type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<TransactionType> DeleteAsync(int id)
        {
            var transactionTypeLooked = await _transactionTypeRepository.GetByIdAsync(id);

            if (transactionTypeLooked is  null)
            {
                _logger.LogError("This type of transaction does not exist");
                throw new Exception("This type of transaction does not exist");
            }

            var deletedTransactionType = await _transactionTypeRepository.DeleteAsync(transactionTypeLooked);

            return deletedTransactionType;
        }
        /// <summary>
        /// Function for getting a transaction type by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<TransactionType> GetByIdAsync(int id)
        {
            var transactionTypeLooked = await _transactionTypeRepository.GetByIdAsync(id);

            if (transactionTypeLooked is null)
            {
                _logger.LogError("This type of transaction does not exist");
                throw new Exception("This type of transaction does not exist");
            }

            return transactionTypeLooked;
        }
        /// <summary>
        /// Function for updating a transaction type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<TransactionType> UpdateAsync(int id)
        {
            var transactionTypeLooked = await _transactionTypeRepository.GetByIdAsync(id);

            if (transactionTypeLooked is null)
            {
                _logger.LogError("This type of transaction does not exist");
                throw new Exception("This type of transaction does not exist");
            }

            var deletedTransactionType = await _transactionTypeRepository.UpdateAsync(transactionTypeLooked);

            return deletedTransactionType;
        }
    }
}
