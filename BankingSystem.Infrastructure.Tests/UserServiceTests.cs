using BankingSystem.AuthService.AuthService.Infrastructure.Services.Implementations;
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
            var userService = new UserServiceInfrastructure(null,null, configuration.Object, null, null, null, null);
            var username = "testuser";
            var password = "testpassword";

            // Act
            var result = userService.GenerateRequestBody(username, password);

            // Assert
            result.Should().BeEquivalentTo(new StringContent("grant_type=password&client_id=clientId&username=testuser&password=testpassword&client_secret=clientSecret", Encoding.UTF8, "application/x-www-form-urlencoded"));
        }

        [Fact]
        public void GenerateRequestBody_With_Null_Values_Returns_Correct_StringContent()
        {
            // Arrange
            var configuration = new Mock<IConfiguration>();
            configuration.Setup(x => x["Keycloak:resource"]).Returns((string)null);
            configuration.Setup(x => x["Keycloak:credentials:secret"]).Returns((string)null);
            var userService = new UserServiceInfrastructure(null, null, configuration.Object, null, null, null, null);
            var username = "testuser";
            var password = "testpassword";

            // Act
            var result = userService.GenerateRequestBody(username, password);

            // Assert
            result.Should().BeEquivalentTo(new StringContent("grant_type=password&client_id=&username=testuser&password=testpassword&client_secret=", Encoding.UTF8, "application/x-www-form-urlencoded"));
        }

        [Fact]
        public void GenerateRequestBody_With_Empty_Values_Returns_Correct_StringContent()
        {
            // Arrange
            var configuration = new Mock<IConfiguration>();
            configuration.Setup(x => x["Keycloak:resource"]).Returns("");
            configuration.Setup(x => x["Keycloak:credentials:secret"]).Returns("");
            var userService = new UserServiceInfrastructure(null, null, configuration.Object, null, null, null, null);
            var username = "testuser";
            var password = "testpassword";

            // Act
            var result = userService.GenerateRequestBody(username, password);

            // Assert
            result.Should().BeEquivalentTo(new StringContent("grant_type=password&client_id=&username=testuser&password=testpassword&client_secret=", Encoding.UTF8, "application/x-www-form-urlencoded"));
        }

    }
}

