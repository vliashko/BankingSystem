namespace BankingSystem.DataAccess.Entities
{
    /// <summary>
    /// Represents a token entity
    /// </summary>
    public class Token
    {
        /// <summary>
        /// Gets or sets the access token
        /// </summary>
        public string AccessToken { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the refresh token
        /// </summary>
        public string RefreshToken { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the userId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the user money account id
        /// </summary>
        public int ClientAccountId { get; set; }
        /// <summary>
        /// Gets or sets the user's roleId
        /// </summary>
        public int RoleId { get; set; }
    }
}
