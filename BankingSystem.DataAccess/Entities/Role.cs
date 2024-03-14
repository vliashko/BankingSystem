namespace BankingSystem.DataAccess.Entities
{
    /// <summary>
    /// Represents a role for a user.
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Gets or sets user's identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets user's rolename
        /// </summary>
        public string RoleName { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets user's list
        /// </summary>
        public List<User> ?Users { get; set; }
    }
}
