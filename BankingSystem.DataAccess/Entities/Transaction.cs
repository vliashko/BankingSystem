namespace BankingSystem.DataAccess.Entities
{
    public class Transaction
    {
        /// <summary>
        /// Identificator for transaction
        /// </summary>
        public int Id { get; set; }
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
        public TransactionType? TransactionType { get; set; }
        /// <summary>
        /// The type of the transaction
        /// </summary>
        public int TransactionTypeId { get; set; }
        public ClientAccount? ClientAccount { get; set; }
        /// <summary>
        /// The client account's Id
        /// </summary>
        public int ClientAccountId { get; set; }

    }
}
