namespace BankingSystem.DataAccess.Entities
{
    /// <summary>
    /// Represent a client account entity 
    /// </summary>
    public class ClientAccount
    {
        /// <summary>
        /// Gets or sets the client account identificator
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the account balance
        /// </summary>
        public double Balance { get; set; }
        public Bank? Bank { get; set; }
        /// <summary>
        /// Gets or sets the bank's identificator
        /// </summary>
        public int BankId { get; set; }
        public AccountType? AccountType { get; set; }
        /// <summary>
        /// Gets or sets the account's identificator
        /// </summary>
        public int AccountTypeId { get; set; }
        public Passport? Passport { get; set; }
        /// <summary>
        /// Gets or sets the passport's identificator
        /// </summary>
        public int PassportId { get; set; }
        /// <summary>
        /// Gets or sets the account's number
        /// </summary>
        public double AccountNumber { get; set; }
        /// <summary>
        /// Gets or sets client transactions
        /// </summary>
        public List<Transaction>? Transactions { get; set; }

        public Card? Card { get; set; }
        /// <summary>
        ///Gets or sets the user id 
        /// </summary>
        public int UserId { get; set; }
      
    }
}
