namespace BankingSystem.API.Response
{
    public class ClientAccountResponse
    {
        /// <summary>
        /// Gets or sets the account's identificator
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the account balance
        /// </summary>
        public double Balance { get; set; }
        /// <summary>
        /// Gets or sets the bank's identificator
        /// </summary>
        public int BankId { get; set; }
        /// <summary>
        /// Gets or sets the user's identificator
        /// </summary>
        public int UserId { get; set; }
    }
}
