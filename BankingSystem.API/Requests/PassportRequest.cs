namespace BankingSystem.API.Requests
{
    /// <summary>
    /// Represents a passport request
    /// </summary>
    public class PassportRequest
    {
        /// <summary>
        /// Gets or sets the firstname
        /// </summary>
        public string FirstName { get; set; } = string.Empty;
        /// <summary>
        ///  Gets or sets the surname
        /// </summary>
        public string SurName { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the birth date
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Gets or sets the issued date
        /// </summary>
        public DateTime DateIssued { get; set; }
        /// <summary>
        /// Gets or sets the expired date
        /// </summary>
        public DateTime DateExpired { get; set; }
        /// <summary>
        /// Gets or sets the nationality
        /// </summary>
        public string Nationality { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets  phone number
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
