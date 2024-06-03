using BankingSystem.DataAccess.Entities;

namespace BankingSystem.Infrastructure.Services.Interfaces
{
    public interface IExpenseCalculatorInfrastructure
    {
        /// <summary>
        /// Get client's expense
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="chunkSize"></param>
        /// <returns></returns>
        Task<List<ClientWithExpense>> GetClientExpenseAsync(int pageNumber, int chunkSize);
    }
}
