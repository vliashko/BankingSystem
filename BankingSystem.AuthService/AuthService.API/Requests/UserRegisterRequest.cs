namespace BankingSystem.AuthService.AuthService.API.Requests
{
    public class UserRegisterRequest
    {
        /// <summary>
        /// The user's register first name
        /// </summary>
        public string FirstName { get; set; } = string.Empty;
        /// <summary>
        /// The user's register last name
        /// </summary>
        public string LastName { get; set; } = string.Empty;
        /// <summary>
        /// The user's register email
        /// </summary>
        public string Email { get; set; } = string.Empty;
        /// <summary>
        /// The user's register Username
        /// </summary>
        public string Username { get; set; } = string.Empty;
        /// <summary>
        /// The user's register password 
        /// </summary>
        public string Password { get; set; } = string.Empty;
        /// <summary>
        /// The user's register password confirmation
        /// </summary>
        public string ConfirmPassword { get; set; } = string.Empty;
        /// <summary>
        /// User's permission about getting emails regarding news of bank
        /// </summary>
        public bool AgreeToGetEmail { get; set; }
    }
}
