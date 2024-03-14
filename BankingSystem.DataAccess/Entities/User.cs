namespace BankingSystem.DataAccess.Entities
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
        public Role ?Role { get; set; }
        public int RoleId { get; set; }
    }
}
