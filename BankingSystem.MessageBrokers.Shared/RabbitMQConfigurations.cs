namespace BankingSystem.MessageBrokers.Shared
{
    /// <summary>
    /// Represents an RabbitMQ configurations entity
    /// </summary>
    public class RabbitMQConfigurations
    {
        public string Host { get; set; } = string.Empty;
        public string VirtualHost { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
