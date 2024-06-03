namespace BankingSystem.Infrastructure.Services.Interfaces
{
    public interface IStripeServiceInfrastructure
    {
        /// <summary>
        /// Function for making the transaction
        /// </summary>
        /// <param name="token"></param>
        /// <param name="senderAccountNumber"></param>
        /// <param name="consumerAccountNumber"></param>
        /// <param name="amount"></param>
        /// <param name="transactionTypeId"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        Task<string> MakeTransactionAsync(string token, double senderAccountNumber, double consumerAccountNumber, long amount, int transactionTypeId, string currency);
    }
}
