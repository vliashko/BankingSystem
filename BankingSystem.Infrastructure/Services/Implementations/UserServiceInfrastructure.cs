using BankingSystem.Infrastructure.Services.Interfaces;
using Google.Apis.Auth.OAuth2.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace BankingSystem.Infrastructure.Services.Implementations
{
    public class UserServiceInfrastructure : IUserServiceInfrastructure
    {
        private readonly ILogger<UserServiceInfrastructure> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        /// <summary>
        /// Initializes a new instance cref of < see cref="UserServiceInfrastructure">
        /// </summary>
        /// <param name="logger"></param>
        public UserServiceInfrastructure(ILogger<UserServiceInfrastructure> logger, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Function for getting the user's access token
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<string> GetUserTokenAsync(string username, string password)
        {
            try 
            {
                var requestBody = GenerateRequestBody(username, password);
                var tokenResponse = await SendTokenRequestAsync(_configuration["Keycloak:tokenEndpoint"], requestBody);
                return tokenResponse.ToString();
            }
            catch(Exception ex) 
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

        public async Task<HttpResponseMessage> RegisterUserAsync(string username, string password)
        {
            try
            {
                var requestBody = GenerateRequestBody(username, password);
                var tokenEndpoint = _configuration["Keycloak:tokenEndpoint"];
                var tokenResponse = await SendTokenRequestAsync(tokenEndpoint, requestBody);
                await SetAccessTokenCookieAsync(tokenResponse);

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
        private StringContent GenerateRequestBody(string username, string password)
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
        private async Task<HttpResponseMessage> SendTokenRequestAsync(string tokenEndpoint, StringContent requestBody)
        {
            var client = new HttpClient();
            return await client.PostAsync(tokenEndpoint, requestBody);
        }

    }
}
