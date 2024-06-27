namespace BankingSystem.Messages.Shared
{
    /// <summary>
    /// Represents a UserRegisterMessage
    /// </summary>
    public class UserRegisterMessage
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
    }
}
