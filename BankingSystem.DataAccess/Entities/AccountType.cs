namespace BankingSystem.DataAccess.Entities
{
    /// <summary>
    /// Represents a Account Type entity
    /// </summary>
    public class AccountType
    {
        /// <summary>
        /// Gets or sets the AccountType's identificator
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the AccountType's name
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
