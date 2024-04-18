using BankingSystem.DataAccess.Entities;

namespace BankingSystem.Infrastructure.Services.Interfaces
{
    public interface IEmailSenderServiceInfrastructure
    {
        /// <summary>
        /// Function for sending the email
        /// </summary>
        /// <param name="emailObject"></param>
        /// <returns></returns>
        Task SendEmailAsync(EmailSender emailObject);
    }
}
