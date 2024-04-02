using BankingSystem.BusinessLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.BusinessLogic.Tests
{
    public class UnAuthorizedExceptionTest
    {
        [Fact]
        public void Constructor_ShouldSetMessage()
        {
            // Arrange
            string errorMessage = "This user is not authorized.";

            // Act
            var exception = new UnAuthorizedException(errorMessage);

            // Assert
            Assert.Equal(errorMessage, exception.Message);
        }
    }
}
