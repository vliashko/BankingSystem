using BankingSystem.DataAccess.Entities;
using BankingSystem.DataAccess.Repositories.Interfaces;
using BankingSystem.Infrastructure.Services.Interfaces;

namespace BankingSystem.Infrastructure.Services.Implementations
{
    public class ExpenseCalculatorInfrastructure : IExpenseCalculatorInfrastructure
    {
        private readonly IClientAccountRepository _clientAccountRepository;
        private readonly ITransactionServiceInfrastructure _transactionServiceInfrastructure;
        /// <summary>
        /// Initializes a new instance cref<see cref="ExpenseCalculatorInfrastructure"></see>
        /// </summary>
        /// <param name="clientAccountRepository"></param>
        /// <param name="transactionServiceInfrastructure"></param>
        public ExpenseCalculatorInfrastructure(ITransactionServiceInfrastructure transactionServiceInfrastructure, IClientAccountRepository clientAccountRepository)
        {
            _transactionServiceInfrastructure = transactionServiceInfrastructure;
            _clientAccountRepository = clientAccountRepository;
        }
        /// <summary>
        /// Get client's expense
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="chunkSize"></param>
        /// <returns></returns>
        public async Task<List<ClientWithExpense>> GetClientExpenseAsync(int pageNumber, int chunkSize)
        {
            var clientWithExpenses = new List<ClientWithExpense>();

            var clients = await _clientAccountRepository.GetPageAsync(pageNumber, chunkSize);

            foreach (var client in clients)
            {
                var clientExpense = await CalculateClientExpenseAsync(client, chunkSize);
                clientWithExpenses.Add(clientExpense);
            }

            return clientWithExpenses;
        }
        private async Task<ClientWithExpense> CalculateClientExpenseAsync(ClientAccount client, int chunkSize)
        {
            var transactions = await _transactionServiceInfrastructure.GetTransactionsByAccount(client.Id, chunkSize);

            double totalExpense = transactions.Sum(t => t.Amount);

            var clientExpense = new ClientWithExpense
            {
                ClientFirstName = client.Passport.FirstName,
                ClientLastName = client.Passport.SurName,
                Amount = totalExpense,
                DateOfTransaction = DateTime.Now
            };

            return clientExpense;
        }

    }
}
