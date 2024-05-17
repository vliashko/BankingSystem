namespace BankingSystem.DataAccess.Entities
{
    public class TransactionType
    {
        /// <summary>
        /// Identificator for transaction's type
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Transaction's type name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        public Transaction? Transaction { get; set; }

    }
}
