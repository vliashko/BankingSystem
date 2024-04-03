using BankingSystem.BusinessLogic.Exceptions;

namespace BankingSystem.BusinessLogic.Tests
{
    public class AlreadyExistExceptionTest
    {
        [Fact]
        public void Constructor_ShouldSetMessage()
        {
            // Arrange
            string errorMessage = "This user already exists.";

            // Act
            var exception = new AlreadyExistException(errorMessage);

            // Assert
            Assert.Equal(errorMessage, exception.Message);
        }
    }
}
