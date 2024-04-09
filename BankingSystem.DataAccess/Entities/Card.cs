namespace BankingSystem.DataAccess.Entities
{
    /// <summary>
    /// Represents a card's entity
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Gets or sets the card's identificator
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name on the card
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the security code
        /// </summary>
        public double SecurityCode { get; set; }
        /// <summary>
        /// Gets or sets the issued date
        /// </summary>
        public DateTime DateIssued { get; set; }
        /// <summary>
        /// Gets or sets the expired date
        /// </summary>
        public DateTime DateExpired { get; set; }
        public CardType? CardType { get; set; }
        /// <summary>
        /// Gets or sets the card type identificator
        /// </summary>
        public int CardTypeId { get; set; }
        public ClientAccount? ClientAccount { get; set; }
        /// <summary>
        /// Gets or sets the client's account identificator
        /// </summary>
        public int ClientAccountId { get; set; }
    }
}
