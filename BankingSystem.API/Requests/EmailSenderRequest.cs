namespace BankingSystem.API.Requests
{
    public class EmailSenderRequest
    {
        /// <summary>
        /// The destination of the email 
        /// </summary>
        public string To { get; set; } = string.Empty;
        /// <summary>
        ///The content of the email 
        /// </summary>
        public string Subject { get; set; } = string.Empty;
        /// <summary>
        /// The format of the email
        /// </summary>
        public string Body { get; set; } = string.Empty;
    }
}
