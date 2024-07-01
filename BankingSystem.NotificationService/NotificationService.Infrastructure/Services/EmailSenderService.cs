using BankingSystem.NotificationService.NotificationService.Infrastructure.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Mustache;

namespace BankingSystem.NotificationService.NotificationService.Infrastructure.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailSenderService> _logger;
        /// <summary>
        /// /// Initializes a new instance cref<see cref="EmailSenderService"/>
        /// </summary>
        /// <param name="configuration"></param>
        public EmailSenderService(IConfiguration configuration, ILogger<EmailSenderService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="receiver"></param>
        /// <returns></returns>
        public async Task SendWelcomeEmail(WelcomeEmailReceiver receiver)
        {
            string templateEmailBody = File.ReadAllText(_configuration["EmailSetting:WelcomeEmail:BodyTemplatePath"]);
            var emailBody = Template.Compile(templateEmailBody).Render(receiver);

            await SendEmailAsync(receiver.Email, _configuration["EmailSetting:WelcomeEmail:Title"], emailBody);

            _logger.LogInformation("The welcome email has been successfully sent to the email address {name}", receiver.Email);
        }

        /// <summary>
        /// Function for sending email after registering
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="title"></param>
        /// <param name="emailBody"></param>
        /// <returns></returns>
        private async Task SendEmailAsync(string emailAddress, string title, string emailBody)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_configuration["EmailSetting:EmailUsername"]));
                email.To.Add(MailboxAddress.Parse(emailAddress));
                email.Subject = title;
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = emailBody };

                using var smtpClient = new SmtpClient();
                    await smtpClient.ConnectAsync(_configuration["EmailSetting:EmailHost"], int.Parse(_configuration["EmailSetting:EmailPort"]), SecureSocketOptions.StartTlsWhenAvailable);
                    await smtpClient.AuthenticateAsync(_configuration["EmailSetting:EmailUsername"], _configuration["EmailSetting:EmailPassword"]);
                    await smtpClient.SendAsync(email);
                    await smtpClient.DisconnectAsync(true);
    
            }
            catch (Exception ex)
            {
                _logger.LogError($"The sending email process failed, Error:{ex.Message}");
                throw;
            }

        }
    }
}
