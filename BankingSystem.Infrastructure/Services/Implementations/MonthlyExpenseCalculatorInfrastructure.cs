using BankingSystem.DataAccess.Entities;
using BankingSystem.DataAccess.Repositories.Interfaces;
using BankingSystem.Infrastructure.Services.Interfaces;

namespace BankingSystem.Infrastructure.Services.Implementations
{
    public class MonthlyExpenseCalculatorInfrastructure : IMonthlyExpenseCalculatorInfrastructure
    {
        private readonly IClientAccountRepository _clientAccountRepository;
        private readonly IMockTransactionGeneratorInfrastructure _mockTransactionGeneratorInfrastructure;
        /// <summary>
        /// Initializes a new instance cref<see cref="MonthlyExpenseCalculatorInfrastructure"></see>
        /// </summary>
        /// <param name="clientAccountRepository"></param>
        /// <param name="mockTransactionGeneratorInfrastructure"></param>
        public MonthlyExpenseCalculatorInfrastructure(IClientAccountRepository clientAccountRepository, IMockTransactionGeneratorInfrastructure mockTransactionGeneratorInfrastructure)
        {
            _clientAccountRepository = clientAccountRepository;
            _mockTransactionGeneratorInfrastructure = mockTransactionGeneratorInfrastructure;
        }
        /// <summary>
        /// Function for getting client's expense
        /// </summary>
        /// <returns></returns>
        public async Task<List<ClientWithExpense>> GetClientMonthlyExpensesAsync()
        {
            var clients = await _clientAccountRepository.GetAllAsync();
            var clientWithExpenses = new List<ClientWithExpense>();

            foreach (var client in clients)
            {
                var monthlyExpense = _mockTransactionGeneratorInfrastructure.GenerateMonthlyExpense();
                clientWithExpenses.Add(await UpdateMonthlySpendingAsync(client.Id, monthlyExpense));
            }

            return clientWithExpenses;
        }
        private async Task<ClientWithExpense> UpdateMonthlySpendingAsync(int clientId, double monthlyExpense)
        {
            var client = await _clientAccountRepository.GetByIdAsync(clientId);
            ClientWithExpense clientWithExpense = new ClientWithExpense();
            clientWithExpense.ClientFirstName = client.Passport.SurName;
            clientWithExpense.ClientLastName = client.Passport.FirstName;
            clientWithExpense.Amount = monthlyExpense;
            clientWithExpense.DateOfTransaction = DateTime.Now;

            return clientWithExpense;
        }
    }
}
