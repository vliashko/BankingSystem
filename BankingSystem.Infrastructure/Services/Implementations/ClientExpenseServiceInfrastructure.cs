using BankingSystem.DataAccess.Entities;
using BankingSystem.DataAccess.Repositories.Interfaces;
using BankingSystem.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace BankingSystem.Infrastructure.Services.Implementations
{
    public class ClientExpenseServiceInfrastructure : IClientExpenseServiceInfrastructure
    {
        private readonly IClientExpenseRepository _clientExpenseRepository;
        private readonly ILogger<ClientExpenseServiceInfrastructure> _logger;
        public ClientExpenseServiceInfrastructure(IClientExpenseRepository clientExpenseRepository, ILogger<ClientExpenseServiceInfrastructure> logger)
        {
            _clientExpenseRepository = clientExpenseRepository;
            _logger = logger;
        }
        /// <summary>
        /// Function for getting client's expense
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<ClientWithExpense>> GetMonthlyClientSpendingsJobAsync()
        {
            var clientExpense = await _clientExpenseRepository.GetMonthlyClientSpendingsJobAsync();

            if (clientExpense == null)
            {
                _logger.LogError($"There is  no clientExpense");
                throw new Exception($"There is no clientExpense");
            }

            return clientExpense;
        }
    }
}
