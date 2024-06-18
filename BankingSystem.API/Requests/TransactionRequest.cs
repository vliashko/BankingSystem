namespace BankingSystem.API.Requests
{
    public class TransactionRequest
    {
        /// <summary>
        /// The amount of the transaction
        /// </summary>
        public long Amount { get; set; }
        /// <summary>
        /// The Date of the transaction
        /// </summary>
        public DateTime DateOfTransaction { get; set; }
        /// <summary>
        /// The Stripe's id account of the sender
        /// </summary>
        public string Token { get; set; } = string.Empty;
        /// <summary>
        /// The client's account number of the sender
        /// </summary>
        public double SenderNumberAccount { get; set; }
        /// <summary>
        /// The client's account number of the consumer
        /// </summary>
        public double ConsumerNumberAccount { get; set; }
        /// <summary>
        /// The transaction type id
        /// </summary>
        public int TransactionTypeId { get; set; }
        /// <summary>
        /// The clientAccount id
        /// </summary>
        public int ClientAccountId { get; set; }
        /// <summary>
        /// The currency
        /// </summary>
        public string Currency { get; set; } = string.Empty;
    }
}
