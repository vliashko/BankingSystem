using BankingSystem.API.Controllers;
using BankingSystem.API.Requests;
using BankingSystem.Infrastructure.Services.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace BankingSystem.API.Tests
{
    public class UserControllerTest
    {
        [Fact]
        public async Task Login_Returns_Token_With_Valid_Credentials()
        {
            //Assign 
            var userLoginRequest = new UserLoginRequest
            {
                UserName = "testuser",
                Password = "testpassword"
            };
            var mockUserService = new Mock<IUserServiceInfrastructure>();
            var mockEmailSenderService = new Mock<IEmailSenderServiceInfrastructure>();
            var expectedAccessToken = "sample_access_token";
            mockUserService.Setup(x => x.LoginAsync(userLoginRequest.UserName, userLoginRequest.Password))
                           .ReturnsAsync(expectedAccessToken);
            //Act
            var controller = new UserController(mockUserService.Object, mockEmailSenderService.Object);

            var result = await controller.Login(userLoginRequest) as ObjectResult;

            //Assert
            result.Should().NotBeNull();
            result.Value.Should().Be(expectedAccessToken);
        }
        [Fact]
        public async Task Login_Returns_With_Invalid_Credentials()
        {
            //Assign
            var actualUser = new UserLoginRequest
            {
                UserName = "invaliduser",
                Password = "invalidpassword"
            };
            var expectedUser = new UserLoginRequest
            {
                UserName = "validuser",
                Password = "validpassword"
            };
            var mockUserService = new Mock<IUserServiceInfrastructure>();
            var mockEmailSenderService = new Mock<IEmailSenderServiceInfrastructure>();
            mockUserService.Setup(x => x.LoginAsync(actualUser.UserName, actualUser.Password))
                           .ReturnsAsync((string)null);
            var controller = new UserController(mockUserService.Object, mockEmailSenderService.Object);

            //Act
            var result = await controller.Login(actualUser) as ObjectResult;

            //Assert
            result.Should().NotBeNull();
            Assert.NotEqual(expectedUser, actualUser);
        }

        [Fact]
        public async Task Register_Returns_Ok_With_Valid_Details()
        {
            //Assign
            var userRegisterRequest = new UserRegisterRequest
            {
                UserName = "newuser",
                Password = "newpassword"
            };
            var mockUserService = new Mock<IUserServiceInfrastructure>();
            var mockEmailSenderService = new Mock<IEmailSenderServiceInfrastructure>();
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK);
            mockUserService.Setup(x => x.RegisterAsync(userRegisterRequest.UserName, userRegisterRequest.Password))
                           .ReturnsAsync(expectedResponse);
            var controller = new UserController(mockUserService.Object, mockEmailSenderService.Object);

            //Act
            var result = await controller.Register(userRegisterRequest) as ObjectResult;

            //Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
    }
}

