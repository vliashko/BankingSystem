using BankingSystem.Infrastructure.Services.Interfaces;

namespace BankingSystem.Infrastructure.Services.Implementations
{
    public class MockTransactionGeneratorInfrastructure : IMockTransactionGeneratorInfrastructure
    {
        private readonly Random _random;
        /// <summary>
        /// Initializes a new instance cref<see cref="MockTransactionGeneratorInfrastructure"/>
        /// </summary>
        public MockTransactionGeneratorInfrastructure() 
        {
            _random = new Random();
        }
        public double GenerateMonthlyExpense()
        {
            return  _random.Next(20,100);
        }
    }
}
