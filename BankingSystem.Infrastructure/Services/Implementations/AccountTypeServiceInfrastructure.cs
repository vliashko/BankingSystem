using BankingSystem.DataAccess.Entities;
using BankingSystem.DataAccess.Repositories.Interfaces;
using BankingSystem.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace BankingSystem.Infrastructure.Services.Implementations
{
    public class AccountTypeServiceInfrastructure : IAccountTypeServiceInfrastructure
    {
        private readonly IAccountTypeRepository _accountTypeRepository;
        private readonly ILogger<AccountTypeServiceInfrastructure> _logger;
        /// <summary>
        /// Initializes a new instance cref <see cref="AccountTypeServiceInfrastructure"/>
        /// </summary>
        /// <param name="accountTypeRepository"></param>
        /// <param name="logger"></param>
        public AccountTypeServiceInfrastructure(IAccountTypeRepository accountTypeRepository, ILogger<AccountTypeServiceInfrastructure> logger)
        {
            _accountTypeRepository = accountTypeRepository;
            _logger = logger;
        }
        /// <summary>
        /// Function for adding an account's type
        /// </summary>
        /// <param name="accountType"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<AccountType> AddAsync(AccountType accountType)
        {
            var accountTypeLooked = await _accountTypeRepository.GetByNameAsync(accountType.Name);
            if (accountTypeLooked is not null)
            {
                _logger.LogError("This account's type already exists");
                throw new Exception("This account's exists already");
            }

            var accountTypeAdded = await _accountTypeRepository.AddAsync(accountType);

            return accountTypeAdded;
        }
        /// <summary>
        /// Function for deleting an account's type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<AccountType> DeleteAsync(int id)
        {
            var accountTypeLooked = await _accountTypeRepository.GetByIdAsync(id);
            if (accountTypeLooked is null)
            {
                _logger.LogError("This account's type doesn't exist");
                throw new Exception("This account's type does not exist");
            }

            var accountTypeDeleted = await _accountTypeRepository.DeleteAsync(accountTypeLooked);

            return accountTypeDeleted;
        }
        /// <summary>
        /// Function for getting an account's type by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AccountType> GetByIdAsync(int id)
        {
            var accountTypeLooked = await _accountTypeRepository.GetByIdAsync(id);
            if (accountTypeLooked is null)
            {
                _logger.LogError("This account's type doesn't exist");
                throw new Exception("This account's type doesn't exist");
            }

            return accountTypeLooked;
        }
        /// <summary>
        /// Function for updating an account's type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<AccountType> UpdateAsync(int id)
        {
            var accountTypeLooked = await _accountTypeRepository.GetByIdAsync(id);
            if (accountTypeLooked is null)
            {
                _logger.LogError("This account's type doesn't exist");
                throw new Exception("This account's type does not exist");
            }
            var accountTypeUpdated = await _accountTypeRepository.UpdateAsync(accountTypeLooked);

            return accountTypeUpdated;
        }
    }
}
