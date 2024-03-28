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
        public UserController(IUserServiceInfrastructure userServiceInfrastructure)
        {
            _userServiceInfrastructure = userServiceInfrastructure;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest userLoginRequest)
        {
            var response = await _userServiceInfrastructure.GetUserTokenAsync(userLoginRequest.UserName, userLoginRequest.Password);

            return Ok(response);
        }
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest userRegisterRequest)
        {
            var response = await _userServiceInfrastructure.RegisterUserAsync(userRegisterRequest.UserName, userRegisterRequest.Password);

            return Ok(response);
        }
    }
}
