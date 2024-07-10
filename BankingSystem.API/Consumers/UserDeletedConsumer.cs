using BankingSystem.Infrastructure.Services.Interfaces;
using BankingSystem.Messages.Shared;
using MassTransit;

namespace BankingSystem.ManagementService.Consumers
{
    public class UserDeletedConsumer : IConsumer<UserDeletedMessage>
    {
        private readonly IClientAccountServiceInfrastructure _clientAccountService;
        private readonly ILogger<UserDeletedConsumer> _logger;

        public UserDeletedConsumer(IClientAccountServiceInfrastructure clientAccountService, ILogger<UserDeletedConsumer> logger)
        {
            _clientAccountService = clientAccountService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UserDeletedMessage> context)
        {
            var userDeletedMessage = context.Message;
            var clientAccount = await _clientAccountService.GetByUserIdAsync(userDeletedMessage.Id);

            await _clientAccountService.DeleteAsync(clientAccount.Id);

            _logger.LogInformation("The client account has been deleted successfuly");
        }
    }
}
