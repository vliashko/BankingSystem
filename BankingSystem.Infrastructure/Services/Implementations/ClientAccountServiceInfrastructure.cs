using BankingSystem.DataAccess.Entities;
using BankingSystem.DataAccess.Repositories.Interfaces;
using BankingSystem.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace BankingSystem.Infrastructure.Services.Implementations
{
    public class ClientAccountServiceInfrastructure : IClientAccountServiceInfrastructure
    {
        private readonly IClientAccountRepository _clientAccountRepository;
        private readonly ILogger<ClientAccountServiceInfrastructure> _logger;
        /// <summary>
        /// Initializes a new instance cref<see cref="ClientAccountServiceInfrastructure"/>
        /// </summary>
        /// <param name="clientAccountRepository"></param>
        /// <param name="logger"></param>
        public ClientAccountServiceInfrastructure(IClientAccountRepository clientAccountRepository, ILogger<ClientAccountServiceInfrastructure> logger)
        {
            _clientAccountRepository = clientAccountRepository;
            _logger = logger;
        }

        /// <summary>
        /// Function for adding a client's account
        /// </summary>
        /// <param name="clientAccount"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ClientAccount> AddAsync(ClientAccount clientAccount)
        {
            var clientAccountLooked = await _clientAccountRepository.GetByPassportIdAsync(clientAccount.PassportId);
            if (clientAccountLooked is not null)
            {
                _logger.LogError("This client's account already exists with this passport id");
                throw new Exception("This client's account exists already with this passport id");
            }

            var clientAccountAdded = await _clientAccountRepository.AddAsync(clientAccount);

            return clientAccountAdded;
        }
        /// <summary>
        /// Function for deleting a client's account
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ClientAccount> DeleteAsync(int id)
        {
            var clientAccountLooked = await _clientAccountRepository.GetByIdAsync(id);
            if (clientAccountLooked is null)
            {
                _logger.LogError("This client's account doesn't exist");
                throw new Exception("This client's account does not exist");
            }

            var clientAccountDeleted = await _clientAccountRepository.DeleteAsync(clientAccountLooked);

            return clientAccountDeleted;
        }
        /// <summary>
        /// Function for getting client's account by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ClientAccount> GetByIdAsync(int id)
        {
            var clientAccountLooked = await _clientAccountRepository.GetByIdAsync(id);
            if (clientAccountLooked is null)
            {
                _logger.LogError("This client's account doesn't exist");
                throw new Exception("This client's account doesn't exist");
            }

            return clientAccountLooked;
        }
        /// <summary>
        /// Function for updating client's account
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ClientAccount> UpdateAsync(int id)
        {
            var clientAccountLooked = await _clientAccountRepository.GetByIdAsync(id);
            if (clientAccountLooked is null)
            {
                _logger.LogError("This client's account doesn't exist");
                throw new Exception("This client's account does not exist");
            }
            var clientAccountUpdated = await _clientAccountRepository.UpdateAsync(clientAccountLooked);

            return clientAccountUpdated;
        }
    
    }
}
