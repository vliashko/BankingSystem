namespace BankingSystem.DataAccess.Entities
{
    /// <summary>
    /// Represents all client's expenses
    /// </summary>
    public class ClientWithExpense
    {
        /// <summary>
        /// The firstname of the client 
        /// </summary>
        public string ClientFirstName { get; set; } = string.Empty;
        /// <summary>
        /// The Lastname of the client 
        /// </summary>
        public string ClientLastName { get; set; } = string.Empty;
        /// <summary>
        /// The amount of the expense
        /// </summary>
        public double Amount { get; set; }
        /// <summary>
        /// The date of the transaction
        /// </summary>
        public DateTime DateOfTransaction { get; set; }
        /// <summary>
        /// The id of the client account
        /// </summary>
        public int ClientAccountId { get; set; }


    }
}
