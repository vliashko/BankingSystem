using BankingSystem.DataAccess.Entities;

namespace BankingSystem.Infrastructure.Services.Interfaces
{
    public interface IMonthlyExpenseCalculatorInfrastructure
    {
        /// <summary>
        /// Function for client's Expenses
        /// </summary>
        /// <returns></returns>
        Task <List<ClientWithExpense>>GetClientMonthlyExpensesAsync();
    }
}
