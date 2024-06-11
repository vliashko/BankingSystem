namespace BankingSystem.API.Response
{
    public class ClientAccountResponse
    {
        /// <summary>
        /// Gets or sets the account balance
        /// </summary>
        public double Balance { get; set; }
        /// <summary>
        /// Gets or sets the bank's identificator
        /// </summary>
        public int BankId { get; set; }
        /// <summary>
        /// Gets or sets the account's identificator
        /// </summary>
        public int AccountTypeId { get; set; }
        /// <summary>
        /// Gets or sets the passport's identificator
        /// </summary>
        public int PassportId { get; set; }
        /// <summary>
        /// Gets or sets the user's identificator
        /// </summary>
        public int UserId { get; set; }
    }
}
