using BankingSystem.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Stripe;

public class StripeServiceInfrastructure : IStripeServiceInfrastructure
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<StripeServiceInfrastructure> _logger;
    private readonly IClientAccountServiceInfrastructure _clientAccountService;
    private readonly ITransactionServiceInfrastructure _transactionService;

    public StripeServiceInfrastructure(IConfiguration configuration, ILogger<StripeServiceInfrastructure> logger, IClientAccountServiceInfrastructure clientAccountService, ITransactionServiceInfrastructure transactionService)
    {

        _configuration = configuration;
        _clientAccountService = clientAccountService;
        _logger = logger;
        _transactionService = transactionService;
    }
    public async Task<string> MakeTransactionAsync(string token, double senderAccountNumber, double consumerAccountNumber, long amount, int transactionTypeId, string currency, int clientAccountId)
    {
        try
        {
            StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];
            var paymentMethodParams = new PaymentMethodCreateOptions
            {
                Type = "card",
                Card = new PaymentMethodCardOptions
                {
                    Token = token
                }
            };

            var paymentMethodService = new PaymentMethodService();
            var paymentMethod = await paymentMethodService.CreateAsync(paymentMethodParams);

            var options = new PaymentIntentCreateOptions
            {
                Amount = amount * 100,
                Currency = currency,
                PaymentMethod = paymentMethod.Id,
                Confirm = true,
                ReturnUrl = "https://www.example.com/payment/success",
                AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                {
                    Enabled = true,
                    AllowRedirects = "never"
                }
            };

            var service = new PaymentIntentService();
            var paymentIntent = service.Create(options);
            var clientSecret = paymentIntent.ClientSecret;
            _logger.LogInformation("The payment has been done successfully");

            var sender = await _clientAccountService.GetByAccountNumberAsync(senderAccountNumber);
            var consumer = await _clientAccountService.GetByAccountNumberAsync(consumerAccountNumber);
            BankingSystem.DataAccess.Entities.Transaction transaction = new BankingSystem.DataAccess.Entities.Transaction();
            transaction.SenderNumberAccount = senderAccountNumber;
            transaction.TransactionTypeId = transactionTypeId;
            transaction.ConsumerNumberAccount = consumerAccountNumber;
            transaction.Amount = amount;
            transaction.DateOfTransaction = DateTime.UtcNow;
            transaction.ClientAccountId = clientAccountId;

            await _transactionService.AddAsync(transaction);
            await CommitBalanceChangesAsync(senderAccountNumber, consumerAccountNumber, amount);
            _logger.LogInformation("The transaction has been added in the database");

            return clientSecret;

        }
        catch (StripeException)
        {
            _logger.LogError("The process for the transaction failed");
            throw;
        }
    }
    private async Task CommitBalanceChangesAsync(double senderAccountNumber, double consumerAccountNumber, long amount)
    {

        var sender = await _clientAccountService.GetByAccountNumberAsync(senderAccountNumber);
        var consumer = await _clientAccountService.GetByAccountNumberAsync(consumerAccountNumber);

        if (sender.Balance < amount)
        {
            _logger.LogInformation("The sender does not have money for the transaction");
            throw new Exception("The sender does not have money for the transaction");
        }

        sender.Balance -= amount;
        consumer.Balance += amount;

        await _clientAccountService.UpdateAsync(sender.Id);
        await _clientAccountService.UpdateAsync(consumer.Id);
    }
}



