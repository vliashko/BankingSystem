using BankingSystem.BusinessLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.BusinessLogic.Tests
{
    public class NotFoundExceptionTest
    {
        [Fact]
        public void Constructor_ShouldSetMessage()
        {
            // Arrange
            string errorMessage = "This user does not exist.";

            // Act
            var exception = new NotFoundException(errorMessage);

            // Assert
            Assert.Equal(errorMessage, exception.Message);
        }
    }
}
