using BankingSystem.DataAccess.Repositories.Interfaces;
using BankingSystem.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BankingSystem.Infrastructure.Services.Implementations
{
    public class BackgroundCalculatorInfrastructure : BackgroundService
    {
        private readonly IMonthlyExpenseCalculatorInfrastructure _monthlyExpenseCalculatorInfrastructure;
        private readonly IClientAccountRepository _clientAccountRepository;
        private readonly IMockTransactionGeneratorInfrastructure _mockTransactionGenerator;
        private readonly ILogger<BackgroundCalculatorInfrastructure> _logger;
        /// <summary>
        /// Initializes a new instance cref<see cref="BackgroundCalculatorInfrastructure"></see>
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="logger"></param>
        public BackgroundCalculatorInfrastructure(IServiceProvider serviceProvider, ILogger<BackgroundCalculatorInfrastructure> logger)
        {
            var scope = serviceProvider.CreateScope();
            _clientAccountRepository = scope.ServiceProvider.GetRequiredService<IClientAccountRepository>();
            _mockTransactionGenerator = scope.ServiceProvider.GetRequiredService<IMockTransactionGeneratorInfrastructure>();
            _monthlyExpenseCalculatorInfrastructure = scope.ServiceProvider.GetRequiredService<IMonthlyExpenseCalculatorInfrastructure>();
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("Starting the process of getting client's expenses in the background");
                    await _monthlyExpenseCalculatorInfrastructure.GetClientMonthlyExpensesAsync();
                    _logger.LogInformation("The process of getting client's expenses completed successfully in the background");
                    await Task.Delay(GetMillisecondsUntilNextMonth(), stoppingToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting client's expenses in the background");
                throw;
            }
        }
        private int GetMillisecondsUntilNextMonth()
        {
            var now = DateTime.UtcNow;
            var nextMonth = now.AddMonths(1).AddDays(-now.Day + 1).AddHours(-now.Hour).AddMinutes(-now.Minute).AddSeconds(-now.Second).AddMilliseconds(-now.Millisecond);
            var millisecondsUntilNextMonth = (int)(nextMonth - now).TotalMilliseconds;
            return millisecondsUntilNextMonth;
        }
    }
}
