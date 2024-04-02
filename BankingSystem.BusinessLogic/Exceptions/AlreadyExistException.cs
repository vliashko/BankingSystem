namespace BankingSystem.BusinessLogic.Exceptions
{
    /// <summary>
    /// Represents a AlreadyExistException's class
    /// </summary>
    public class AlreadyExistException : Exception
    {
        public AlreadyExistException(string message) : base(message) { }

    }
}
