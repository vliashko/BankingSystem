using BankingSystem.DataAccess.Entities;
using BankingSystem.DataAccess.Repositories.Interfaces;
using BankingSystem.Infrastructure.Services.Interfaces;
using Google.Apis.Auth.OAuth2.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text;

namespace BankingSystem.Infrastructure.Services.Implementations
{
    public class UserServiceInfrastructure : IUserServiceInfrastructure
    {
        private readonly ILogger<UserServiceInfrastructure> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        /// <summary>
        /// Initializes a new instance cref of < see cref="UserServiceInfrastructure">
        /// </summary>
        /// <param name="logger"></param>
        public UserServiceInfrastructure(ILogger<UserServiceInfrastructure> logger, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            _logger = logger;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Function for getting the user's access token
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<string> LoginAsync(string username, string password)
        {
            try
            {
                var client = new HttpClient();
                var requestBody = GenerateRequestBody(username, password);
                var tokenResponse = await client.PostAsync(_configuration["Keycloak:tokenEndpoint"], requestBody);
                tokenResponse.EnsureSuccessStatusCode();
                var responseContent = await tokenResponse.Content.ReadAsStringAsync();
                dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);
                string accessToken = jsonResponse.access_token;

                return accessToken;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error login's user: {ex.Message}");
                throw;
            }

        }
        /// <summary>
        /// Function for registration
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>

        public async Task<HttpResponseMessage> RegisterAsync(User user, string username, string password)
        {
            try
            {
                var requestBody = GenerateRequestBody(username, password);
                var tokenEndpoint = _configuration["Keycloak:tokenEndpoint"];
                var tokenResponse = await SendTokenRequestAsync(tokenEndpoint, requestBody);
                await SetAccessTokenCookieAsync(tokenResponse);
                var userLooked = await _userRepository.GetByEmailAsync(user.Email);

                if (userLooked is not null)
                {
                    _logger.LogError($"The email : {userLooked.Email},already belong to a user!!!");
                    throw new Exception("This user already exists");
                }
                var userWithRole = SetUserRole(user);
                await _userRepository.AddAsync(userWithRole);

                _logger.LogInformation("User registered successfully");

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error registering user: {ex.Message}");
                throw;
            }
        }
        /// <summary>
        /// Function to generate the request body
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public StringContent GenerateRequestBody(string username, string password)
        {
            var clientId = _configuration["Keycloak:resource"];
            var clientSecret = _configuration["Keycloak:credentials:secret"];

            return new StringContent($"grant_type=password&client_id={clientId}&username={username}&password={password}&client_secret={clientSecret}", Encoding.UTF8, "application/x-www-form-urlencoded");
        }
        /// <summary>
        /// Sets Acces Token in a cookie
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        [ExcludeFromCodeCoverage]
        private async Task SetAccessTokenCookieAsync(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            var deserializedTokenResponse = JsonConvert.DeserializeObject<TokenResponse>(content);
            var accessToken = deserializedTokenResponse.AccessToken;

            var cookieOptions = new CookieOptions
            {
                Path = "/",
                HttpOnly = true,
                Secure = true,
                MaxAge = TimeSpan.FromDays(1)
            };

            _httpContextAccessor.HttpContext.Response.Cookies.Append("access_token", accessToken, cookieOptions);
        }
        /// <summary>
        /// Sends the request to the specific endPoint
        /// </summary>
        /// <param name="tokenEndpoint"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        /// 
        [ExcludeFromCodeCoverage]
        private async Task<HttpResponseMessage> SendTokenRequestAsync(string tokenEndpoint, StringContent requestBody)
        {
            var client = new HttpClient();

            return await client.PostAsync(tokenEndpoint, requestBody);
        }
        /// <summary>
        /// Creation of a confirmation email
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public EmailSender CreateConfirmationEmail(string emailAddress)
        {
            return new EmailSender
            {
                To = emailAddress,
                Subject = "Registration's confirmation",
                Body = "Your registration has been approved with success!"
            };
        }
        /// <summary>
        /// Function for deleting a user 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<User> DeleteAsync(string email)
        {
            var userLooked = await _userRepository.GetByEmailAsync(email);
            if (userLooked is null)
            {
                _logger.LogError("This user doesn't exist");
                throw new Exception("This user doesn't exist");
            }

            var deletedUser = await _userRepository.DeleteAsync(userLooked);

            return deletedUser;
        }
        /// <summary>
        /// Function for updating a user
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<User> UpdateAsync(string email)
        {
            var userLooked = await _userRepository.GetByEmailAsync(email);
            if (userLooked is null)
            {
                _logger.LogError("This user doesn't exist");
                throw new Exception("This user doesn't exist");
            }

            var updatedUser = await _userRepository.UpdateAsync(userLooked);

            return updatedUser;
        }
        /// <summary>
        /// Function for getting a user by Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<User> GetByEmailAsync(string email)
        {
            var userLooked = await _userRepository.GetByEmailAsync(email);
            if (userLooked is null)
            {
                _logger.LogError($"The user with this email:{email} Ddoes not exist");
                throw new Exception("This user doesn't exist");
            }

            return userLooked;
        }
        /// <summary>
        /// Set the role
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private User SetUserRole(User user)
        {
            user.RoleId = 2;

            return user;
        }
    }
}
