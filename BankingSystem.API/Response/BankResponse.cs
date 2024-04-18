namespace BankingSystem.API.Response
{
    public class BankResponse
    {
        public double BankCode { get; set; }
        /// <summary>
        /// Gets or sets the bank's name
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the bank's city
        /// </summary>
        public string City { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the bank's phone number
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
