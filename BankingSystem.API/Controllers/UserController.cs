using AutoMapper;
using BankingSystem.API.Requests;
using BankingSystem.API.Response;
using BankingSystem.DataAccess.Entities;
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
        private readonly IMapper _mapper;
        public UserController(IUserServiceInfrastructure userServiceInfrastructure, IEmailSenderServiceInfrastructure emailSenderServiceInfrastructure, IMapper mapper)
        {
            _userServiceInfrastructure = userServiceInfrastructure;
            _emailSenderServiceInfrastructure = emailSenderServiceInfrastructure;
            _mapper = mapper;
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
            var response = await _userServiceInfrastructure.RegisterAsync(_mapper.Map<User>(userRegisterRequest), userRegisterRequest.UserName, userRegisterRequest.Password);
            var confirmationEmail = _userServiceInfrastructure.CreateConfirmationEmail(userRegisterRequest.Email);
            await _emailSenderServiceInfrastructure.SendEmailAsync(confirmationEmail);

            return Ok(response);
        }

        [HttpPut("{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Update(string email, [FromBody] UserRegisterRequest userRegisterRequest)
        {
            var user = await _userServiceInfrastructure.GetByEmailAsync(email);
            _mapper.Map(userRegisterRequest, user);
            await _userServiceInfrastructure.UpdateAsync(user.Email);

            return Ok(_mapper.Map<UserResponse>(user));
        }

        [HttpDelete("{email}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Delete(string email)
        {
            var response = await _userServiceInfrastructure.DeleteAsync(email);

            return Ok(_mapper.Map<UserResponse>(response));
        }
    }
}
