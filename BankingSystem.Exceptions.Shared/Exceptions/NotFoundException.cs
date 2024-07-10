namespace BankingSystem.Exceptions.Shared.Exceptions
{
    /// <summary>
    /// Represents a NotFoundException's class
    /// </summary>
    public class NotFoundException: Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}
