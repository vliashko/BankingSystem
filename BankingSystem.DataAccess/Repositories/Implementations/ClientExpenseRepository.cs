using BankingSystem.DataAccess.Data;
using BankingSystem.DataAccess.Entities;
using BankingSystem.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BankingSystem.DataAccess.Repositories.Implementations
{
    public class ClientExpenseRepository:IClientExpenseRepository
    {
        private readonly BankingSystemDbContext _db;
        private readonly IConfiguration _configuration;
        public ClientExpenseRepository(BankingSystemDbContext db, IConfiguration configuration) 
        {
            _db = db;
            _configuration = configuration;
        }
        /// <summary>
        /// Retrieves the total spending of all clients for the past month.
        /// This is the list that will be calculated by the background service
        /// It will take 10 clients at time
        /// </summary>
        /// <returns>A list of client spendings.</returns>
        /// <summary>
        /// Retrieves the total spending of all clients for the past month.
        /// </summary>
        /// <returns>A list of client spendings.</returns>
        public async Task<List<ClientWithExpense>> GetMonthlyClientSpendingsJobAsync()
        {
            int clientChunkSize = Convert.ToInt32(_configuration["ConstanteValue:ten"]);
            var oneMonthAgo = DateTime.UtcNow.AddMonths(-1);
            var clientIds = await _db.Transactions
                                        .Where(t => t.DateOfTransaction >= oneMonthAgo)
                                        .Select(t => t.ClientAccountId)
                                        .Distinct()
                                        .OrderBy(id => id)
                                        .ToListAsync();

            var clientSpendings = new List<ClientWithExpense>();

            for (int i = 0; i < clientIds.Count; i += clientChunkSize)
            {
                var chunk = clientIds.Skip(i).Take(clientChunkSize);
                foreach (var clientId in chunk)
                {
                    var transactions = await _db.Transactions
                                                .Where(t => t.ClientAccountId == clientId && t.DateOfTransaction >= oneMonthAgo)
                                                .ToListAsync();

                    var totalSpending = transactions.Sum(t => t.Amount);
                    clientSpendings.Add(new ClientWithExpense { ClientAccountId = clientId, Amount = totalSpending });
                }
            }

            return clientSpendings;
        }
    }
}
