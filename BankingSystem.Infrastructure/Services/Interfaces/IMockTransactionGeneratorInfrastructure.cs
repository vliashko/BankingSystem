namespace BankingSystem.Infrastructure.Services.Interfaces
{
    public interface IMockTransactionGeneratorInfrastructure
    {
        /// <summary>
        /// Function for generating client's monthly expenses
        /// </summary>
        /// <returns></returns>
        double GenerateMonthlyExpense();
    }
}
