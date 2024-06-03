namespace BankingSystem.DataAccess.Entities
{
    public class Payment
    {
        public string CardNumber { get; set; } = string.Empty;
        public int ExpiredMonth { get; set; }
        public int ExpiredYear { get; set; }
        public string Cvc { get; set; } = string.Empty;
        public long Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
