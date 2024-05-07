using BankingSystem.DataAccess.Entities;
using BankingSystem.DataAccess.Repositories.Interfaces;
using BankingSystem.Infrastructure.Services.Interfaces;

namespace BankingSystem.Infrastructure.Services.Implementations
{
    public class ExpenseCalculatorInfrastructure : IExpenseCalculatorInfrastructure
    {
        private readonly IClientAccountServiceInfrastructure _clientAccountService;
        private readonly IClientAccountRepository _clientAccountRepository;
        private readonly ITransactionServiceInfrastructure _transactionServiceInfrastructure;
        /// <summary>
        /// Initializes a new instance cref<see cref="ExpenseCalculatorInfrastructure"></see>
        /// </summary>
        /// <param name="clientAccountRepository"></param>
        /// <param name="transactionServiceInfrastructure"></param>
        public ExpenseCalculatorInfrastructure(IClientAccountServiceInfrastructure clientAccountService, ITransactionServiceInfrastructure transactionServiceInfrastructure, IClientAccountRepository clientAccountRepository)
        {
            _clientAccountService = clientAccountService;
            _transactionServiceInfrastructure = transactionServiceInfrastructure;
            _clientAccountRepository = clientAccountRepository;
        }
        /// <summary>
        /// Function for getting client's expense
        /// </summary>
        /// <returns></returns>
        public async Task<List<ClientWithExpense>> GetClientExpensesAsync()
        {
            var clients = await _clientAccountRepository.GetAllAsync();
            var clientWithExpenses = new List<ClientWithExpense>();
            var transactions = await _transactionServiceInfrastructure.GetAllAsync();

            foreach (var client in clients)
            {
                var monthlyExpense = transactions.Where(t => t.SenderNumberAccount == client.AccountNumber ).Select(t => t.Amount).Sum();
                clientWithExpenses.Add(await UpdateSpendingAsync(client.AccountNumber, monthlyExpense));
            }

            return clientWithExpenses;
        }
        private async Task<ClientWithExpense> UpdateSpendingAsync(double accountNumber, double monthlyExpense)
        { 
            var client = await _clientAccountService.GetByAccountNumberAsync(accountNumber);
            ClientWithExpense clientWithExpense = new ClientWithExpense();
            clientWithExpense.ClientFirstName = client.Passport.SurName;
            clientWithExpense.ClientLastName = client.Passport.FirstName;
            clientWithExpense.Amount = monthlyExpense;

            return clientWithExpense;
        }
    }
}
