using AutoMapper;
using BankingSystem.Messages.Shared;
using BankingSystem.NotificationService.NotificationService.Infrastructure.Models;
using BankingSystem.NotificationService.NotificationService.Infrastructure.Services;
using MassTransit;

namespace BankingSystem.NotificationService.NotificationService.API.Consumers
{
    public class UserRegisteredConsumer : IConsumer<UserRegisterMessage>
    {
        private readonly IEmailSenderService _emailSenderService;
        private readonly ILogger<UserRegisteredConsumer> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates an instance of <see cref="UserRegisteredConsumer"/>
        /// </summary>
        /// <param name="emailSenderService"></param>
        /// <param name="logger"></param>
        public UserRegisteredConsumer(IEmailSenderService emailSenderService, ILogger<UserRegisteredConsumer> logger, IMapper mapper)
        {
            _emailSenderService = emailSenderService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        ///Method called everytime a message is received in one if RabbitMQ queues 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Consume(ConsumeContext<UserRegisterMessage> context)
        {
            _logger.LogInformation("Message received from the broker");

            var receiver = _mapper.Map<WelcomeEmailReceiver>(context.Message);

            await _emailSenderService.SendWelcomeEmail(receiver);

            _logger.LogInformation("Message Sent Successfuly");
        }
    }
}
