namespace BankingSystem.API.Response
{
    /// <summary>
    /// Represents a card response
    /// </summary>
    public class CardResponse
    {
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
        /// <summary>
        /// Gets or sets the card type identificator
        /// </summary>
        public int CardTypeId { get; set; }
    }
}
