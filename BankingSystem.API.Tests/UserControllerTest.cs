using BankingSystem.API.Controllers;
using BankingSystem.API.Requests;
using BankingSystem.DataAccess.Entities;
using BankingSystem.Infrastructure.Services.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BankingSystem.API.Tests
{
    public class UserControllerTest
    {
        [Fact]
        public async Task Login_Returns_Token_With_Valid_Credentials()
        {
            // Arrange
            var userLoginRequest = new UserLoginRequest
            {
                UserName = "testuser",
                Password = "testpassword"
            };
            var mockUserService = new Mock<IUserServiceInfrastructure>();
            var mockEmailSenderService = new Mock<IEmailSenderServiceInfrastructure>();
            var expectedAccessToken = "sample_access_token";

            mockUserService.Setup(x => x.LoginAsync(userLoginRequest.UserName, userLoginRequest.Password))
                           .ReturnsAsync(new Token { AccessToken = expectedAccessToken });

            var controller = new UserController(mockUserService.Object, mockEmailSenderService.Object, null);

            // Act
            var result = await controller.Login(userLoginRequest) as ObjectResult;

            // Assert
            result.Should().NotBeNull();
            result.Value.Should().BeOfType<Token>().Which.AccessToken.Should().Be(expectedAccessToken);
        }

        [Fact]
        public async Task Login_Returns_With_Invalid_Credentials()
        {
            // Arrange
            var actualUser = new UserLoginRequest
            {
                UserName = "invaliduser",
                Password = "invalidpassword"
            };
            var mockUserService = new Mock<IUserServiceInfrastructure>();
            var mockEmailSenderService = new Mock<IEmailSenderServiceInfrastructure>();

            mockUserService.Setup(x => x.LoginAsync(actualUser.UserName, actualUser.Password))
                           .ReturnsAsync((Token)null);

            var controller = new UserController(mockUserService.Object, mockEmailSenderService.Object, null);

            // Act
            var result = await controller.Login(actualUser) as ObjectResult;

            // Assert
            result.Should().NotBeNull();
            result.Value.Should().BeNull();
        }
    }

}

