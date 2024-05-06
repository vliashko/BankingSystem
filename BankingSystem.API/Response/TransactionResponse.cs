namespace BankingSystem.API.Response
{
    public class TransactionResponse
    {
        /// <summary>
        /// The amount of the transaction
        /// </summary>
        public double Amount { get; set; }
        /// <summary>
        /// The Date of the transaction
        /// </summary>
        public DateTime DateOfTransaction { get; set; }
        /// <summary>
        /// The client's account number of the sender
        /// </summary>
        public double SenderNumberAccount { get; set; }
        /// <summary>
        /// The client's account number of the consumer
        /// </summary>
        public double ConsumerNumberAccount { get; set; }
    }
}
