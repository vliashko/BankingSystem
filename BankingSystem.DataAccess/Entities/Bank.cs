namespace BankingSystem.DataAccess.Entities
{
    /// <summary>
    /// Represents a Bank entity
    /// </summary>
    public class Bank
    {
        /// <summary>
        /// Gets or sets the bank's identificator
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the bank code
        /// </summary>
        public double BankCode { get; set; }
        /// <summary>
        /// Gets or sets the bank's name
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the bank's city
        /// </summary>
        public string City { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the bank's phone number
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
