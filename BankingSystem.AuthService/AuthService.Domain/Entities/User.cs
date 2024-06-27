namespace BankingSystem.AuthService.BankingSystem.DataAccess.Entities 
{

    /// <summary>
    /// Represent a User's class
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the user's identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The user's register first name
        /// </summary>
        public string FirstName { get; set; } = string.Empty;
        /// <summary>
        /// The user's register last name
        /// </summary>
        public string LastName { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the user's name 
        /// </summary>
        public string Username { get; set; } = string.Empty;
        /// <summary>
        ///Gets or sets  user's email adress
        /// </summary>
        public string Email { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the user's password
        /// </summary>
        public string Password { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the user's role
        /// </summary>
        public Role? Role { get; set; }
        /// <summary>
        /// Gets or sets the user's roleId
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// User's permission about getting emails regarding news of bank
        /// </summary>
        public bool AgreeToGetEmail { get; set; }

    }
}
