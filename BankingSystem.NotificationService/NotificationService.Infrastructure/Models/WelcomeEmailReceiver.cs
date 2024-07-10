namespace BankingSystem.NotificationService.NotificationService.Infrastructure.Models
{
    public class WelcomeEmailReceiver
    {
        /// <summary>
        /// User's email
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// User's name
        /// </summary>
        public string Username { get; set; } = string.Empty;
    }
}
