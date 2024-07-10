using BankingSystem.NotificationService.NotificationService.Infrastructure.Models;

namespace BankingSystem.NotificationService.NotificationService.Infrastructure.Services
{
    public interface IEmailSenderService
    {
        /// <summary>
        /// Function for sending the email
        /// </summary>
        /// <param name="receiver"></param>
        /// <returns></returns>
        Task SendWelcomeEmail(WelcomeEmailReceiver receiver);
    }
}
