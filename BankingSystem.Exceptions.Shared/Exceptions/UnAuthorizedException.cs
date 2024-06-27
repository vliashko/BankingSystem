namespace BankingSystem.Exceptions.Shared.Exceptions 
{ 
    /// <summary>
    /// Represents a Unauthorized exception class
    /// </summary>
    public class UnAuthorizedException : Exception
    {
        public UnAuthorizedException(string message) : base(message) { }
    }
}
