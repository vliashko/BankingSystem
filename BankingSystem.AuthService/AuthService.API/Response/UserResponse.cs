namespace BankingSystem.AuthService.AuthService.API.Response
{
    public class UserResponse
    {
        /// <summary>
        /// Gets or sets the username
        /// </summary>
        public string Username { get; set; } = string.Empty;
        /// <summary>
        ///  Gets or sets the user's email
        /// </summary>
        public string Email { get; set; } = string.Empty;
        /// <summary>
        /// The user's register first name
        /// </summary>
        public string FirstName { get; set; } = string.Empty;
        /// <summary>
        /// The user's register last name
        /// </summary>
        public string LastName { get; set; } = string.Empty;
        /// User's permission about getting emails regarding news of bank
        /// </summary>
        public bool AgreeToGetEmail { get; set; }
    }
}
