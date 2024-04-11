namespace BankingSystem.DataAccess.Entities
{
    /// <summary>
    /// Represents a CardType's entity
    /// </summary>
    public class CardType
    {
        /// <summary>
        /// Gets or sets the cardType's identificator
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the cardType's name
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
