using BankingSystem.API.Requests;
using BankingSystem.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.API.Controllers
{
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserServiceInfrastructure _userServiceInfrastructure;
        private readonly IEmailSenderServiceInfrastructure _emailSenderServiceInfrastructure;
        public UserController(IUserServiceInfrastructure userServiceInfrastructure, IEmailSenderServiceInfrastructure emailSenderServiceInfrastructure)
        {
            _userServiceInfrastructure = userServiceInfrastructure;
            _emailSenderServiceInfrastructure = emailSenderServiceInfrastructure;
        }

        [HttpPost("login")]

        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest userLoginRequest)
        {
            var response = await _userServiceInfrastructure.LoginAsync(userLoginRequest.UserName, userLoginRequest.Password);

            return Ok(response);
        }
        [HttpPost("register")]

        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest userRegisterRequest)
        {
            var response = await _userServiceInfrastructure.RegisterAsync(userRegisterRequest.UserName, userRegisterRequest.Password);
            var confirmationEmail = _userServiceInfrastructure.CreateConfirmationEmail(userRegisterRequest.Email);
            await _emailSenderServiceInfrastructure.SendEmailAsync(confirmationEmail);

            return Ok(response);
        }
    }
}
