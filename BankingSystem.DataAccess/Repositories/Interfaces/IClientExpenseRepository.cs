using BankingSystem.DataAccess.Entities;

namespace BankingSystem.DataAccess.Repositories.Interfaces
{
    public interface IClientExpenseRepository
    {
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
        Task<List<ClientWithExpense>> GetMonthlyClientSpendingsJobAsync();
    }
}
