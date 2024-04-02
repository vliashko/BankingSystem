using BankingSystem.Infrastructure.Services.Implementations;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Text;

namespace BankingSystem.Infrastructure.Tests.Services
{
    public class UserServiceInfrastructureTests
    {
        [Fact]
        public void GenerateRequestBody_Returns_Correct_StringContent()
        {
            // Arrange
            var configuration = new Mock<IConfiguration>();
            configuration.Setup(x => x["Keycloak:resource"]).Returns("clientId");
            configuration.Setup(x => x["Keycloak:credentials:secret"]).Returns("clientSecret");
            var userService = new UserServiceInfrastructure(null, configuration.Object, null);
            var username = "testuser";
            var password = "testpassword";

            // Act
            var result = userService.GenerateRequestBody(username, password);

            // Assert
            result.Should().BeEquivalentTo(new StringContent("grant_type=password&client_id=clientId&username=testuser&password=testpassword&client_secret=clientSecret", Encoding.UTF8, "application/x-www-form-urlencoded"));
        }
    }
}
