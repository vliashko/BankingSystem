using BankingSystem.DataAccess.Entities;
using BankingSystem.Infrastructure.Services.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit;


namespace BankingSystem.Infrastructure.Services.Implementations
{
    public class EmailSenderServiceInfrastrucutre : IEmailSenderServiceInfrastructure
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailSenderServiceInfrastrucutre> _logger;
        /// <summary>
        /// /// Initializes a new instance cref<see cref="EmailSenderServiceInfrastrucutre"/>
        /// </summary>
        /// <param name="configuration"></param>
        public EmailSenderServiceInfrastrucutre(IConfiguration configuration, ILogger<EmailSenderServiceInfrastrucutre> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        public async Task SendEmailAsync(EmailSender emailObject)
        {
            try 
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_configuration["EmailSetting:EmailUsername"]));
                email.To.Add(MailboxAddress.Parse(emailObject.To));
                email.Subject = emailObject.Subject;
                email.Body = new TextPart(MimeKit.Text.TextFormat.Plain) { Text = emailObject.Body };

                using (var smtpClient = new SmtpClient())
                {
                    await smtpClient.ConnectAsync(_configuration["EmailSetting:EmailHost"], 587, SecureSocketOptions.StartTlsWhenAvailable);
                    await smtpClient.AuthenticateAsync(_configuration["EmailSetting:EmailUsername"], _configuration["EmailSetting:EmailPassword"]);
                    await smtpClient.SendAsync(email);
                    await smtpClient.DisconnectAsync(true);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError($"The sending email process failed, Error:{ex.Message}");
                throw;
            }
           
        }
    }
}
