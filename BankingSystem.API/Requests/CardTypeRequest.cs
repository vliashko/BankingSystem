namespace BankingSystem.API.Requests
{
    /// <summary>
    /// Represent a card type request
    /// </summary>
    public class CardTypeRequest
    {
        /// <summary>
        /// Gets or sets the cardType's name
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
