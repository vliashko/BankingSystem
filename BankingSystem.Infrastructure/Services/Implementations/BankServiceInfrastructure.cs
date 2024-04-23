using BankingSystem.DataAccess.Entities;
using BankingSystem.DataAccess.Repositories.Interfaces;
using BankingSystem.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace BankingSystem.Infrastructure.Services.Implementations
{
    public class BankServiceInfrastructure : IBankServiceInfrastructure
    {
        private readonly IBankRepository _bankRepository;
        private readonly ILogger<BankServiceInfrastructure> _logger;
        /// <summary>
        /// Initializes a new instance cref <see cref="BankServiceInfrastructure"/>
        /// </summary>
        /// <param name="bankRepository"></param>
        /// <param name="logger"></param>
        public BankServiceInfrastructure(IBankRepository bankRepository, ILogger<BankServiceInfrastructure> logger)
        {
            _bankRepository = bankRepository;
            _logger = logger;
        }

        /// <summary>
        /// Function for adding bank
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Bank> AddAsync(Bank bank)
        {
            var bankLooked = await _bankRepository.GetByNameAsync(bank.Name);
            if (bankLooked is not null)
            {
                _logger.LogError("This bank already exists");
                throw new Exception("This bank exists already");
            }

            var addedBank = await _bankRepository.AddAsync(bank);

            return addedBank;
        }
        /// <summary>
        /// Function for deleting a bank
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Bank> DeleteAsync(int id)
        {
            var bankLooked = await _bankRepository.GetByIdAsync(id);
            if (bankLooked is null)
            {
                _logger.LogError("This bank doesn't exist");
                throw new Exception("This bank does not exist");
            }

            var deletedBank = await _bankRepository.DeleteAsync(bankLooked);

            return deletedBank;
        }
        /// <summary>
        /// Function for getting bank by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Bank> GetByIdAsync(int id)
        {
            var bankLooked = await _bankRepository.GetByIdAsync(id);
            if (bankLooked is null)
            {
                _logger.LogError("This bank doesn't exist");
                throw new Exception("This bank doesn't exist");
            }

            return bankLooked;
        }
        /// <summary>
        /// Function for updating bank
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Bank> UpdateAsync(int id)
        {
            var bankLooked = await _bankRepository.GetByIdAsync(id);
            if (bankLooked is null)
            {
                _logger.LogError("This bank doesn't exist");
                throw new Exception("This bank does not exist");
            }
            var updatedBank = await _bankRepository.UpdateAsync(bankLooked);

            return updatedBank;
        }
    }
}
