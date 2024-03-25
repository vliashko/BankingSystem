using BankingSystem.API.Requests;
using BankingSystem.API.Responses;
using BankingSystem.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace BankingSystem.API.Controllers
{
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest userLoginRequest)
        {
            var tokenEndpoint = _configuration["Keycloak:tokenEndpoint"];
            var clientId = _configuration["Keycloak:resource"];
            var clientSecret = _configuration["Keycloak:credentials:secret"];
            var requestBody = new StringContent($"grant_type=password&client_id={clientId}&username={userLoginRequest.UserName}&password={userLoginRequest.Password}&client_secret={clientSecret}", Encoding.UTF8, "application/x-www-form-urlencoded");
            UserLoginResponse userLoginResponse = new UserLoginResponse();
            userLoginResponse.AccesToken = await _userService.GetUserTokenAsync(tokenEndpoint, requestBody);

            return Ok(userLoginResponse);
        }
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest userRegisterRequest)
        {
            var tokenEndpoint = _configuration["Keycloak:tokenEndpoint"];
            var clientId = _configuration["Keycloak:resource"];
            var clientSecret = _configuration["Keycloak:credentials:secret"];
            var requestBody = new StringContent($"grant_type=password&client_id={clientId}&username={userRegisterRequest.UserName}&password={userRegisterRequest.Password}&client_secret={clientSecret}", Encoding.UTF8, "application/x-www-form-urlencoded");
            UserRegisterResponse userRegisterResponse = new UserRegisterResponse();
            userRegisterResponse.AccesToken = await _userService.GetUserTokenAsync(tokenEndpoint, requestBody);

            return Ok(userRegisterResponse);

        }
    }
}
