using BankingSystem.AuthService.AuthService.Infrastructure.Services.Interfaces;
using BankingSystem.AuthService.BankingSystem.DataAccess.Entities;
using BankingSystem.AuthService.BankingSystem.DataAccess.Repositories.Interfaces;
using BankingSystem.Exceptions.Shared.Exceptions;
using Google.Apis.Auth.OAuth2.Responses;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace BankingSystem.AuthService.AuthService.Infrastructure.Services.Implementations
{
    public class UserServiceInfrastructure : IUserServiceInfrastructure
    {
        private readonly ILogger<UserServiceInfrastructure> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        //  private readonly IPublishEndpoint _publishEndpoint;
        private readonly HttpClient _httpClient;
        /// <summary>
        /// Initializes a new instance cref of < see cref="UserServiceInfrastructure">
        /// </summary>
        /// <param name="logger"></param>
        public UserServiceInfrastructure(ILogger<UserServiceInfrastructure> logger, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, HttpClient httpClient)// IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _httpClient = httpClient;
            //_publishEndpoint = publishEndpoint;
        }

        /// <summary>
        /// Function for getting the user's access token
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<Token> LoginAsync(string username, string password)
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
                string refreshToken = jsonResponse.refresh_token;
                var user = await _userRepository.GetByUsernameAsync(username);

                Token token = new Token()
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    UserId = user.Id,
                    RoleId = user.RoleId
                };

                return token;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error login's user: {ex.Message}");
                throw;
            }

        }
        /// <summary>
        /// Function for Logging out the user
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        public async Task LogoutAsync(string refreshToken)
        {
            try
            {
                var logoutEndpoint = _configuration["Keycloak:LogOut"];
                var logoutRequest = new HttpRequestMessage(HttpMethod.Post, logoutEndpoint);
                var clientId = _configuration["Keycloak:resource"];
                var clientSecret = _configuration["Keycloak:credentials:secret"];

                logoutRequest.Content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("refresh_token", refreshToken),
                    new KeyValuePair<string, string>("client_id", clientId),
                    new KeyValuePair<string, string>("client_secret", clientSecret),
                });

                var response = await _httpClient.SendAsync(logoutRequest);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("Error logging out user");
                    throw new Exception("Error logging out user");
                }

                _logger.LogInformation("User logged out successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error logging out user: {ex.Message}");
                throw;
            }
        }
        /// <summary>
        /// Function for registration
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        public async Task<HttpResponseMessage> RegisterAsync(User user)
        {
            var keycloakUrl = _configuration["Keycloak:auth-server-url"];
            var realm = _configuration["Keycloak:realm"];
            var clientId = _configuration["Keycloak:resource"];
            var clientSecret = _configuration["Keycloak:credentials:secret"];
            var token = await GetAdminAccessTokenAsync(keycloakUrl, realm, clientId, clientSecret);

            var keycloakNewUser = new KeycloakUser
            {
                Username = user.Username,
                Email = user.Email,
                Enabled = true,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Credentials = new List<Credential>
                {
                    new Credential
                    {
                        Type = "password",
                        Value = user.Password,
                        Temporary = false
                    }
                }
            };

            var userRequest = new HttpRequestMessage(HttpMethod.Post, $"{keycloakUrl}/admin/realms/{realm}/users");
            userRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            userRequest.Content = new StringContent(JsonConvert.SerializeObject(keycloakNewUser), Encoding.UTF8, "application/json");
            var response = await _httpClient.SendAsync(userRequest);
            response.EnsureSuccessStatusCode();

            var userWithRole = SetUserRole(user);
            await _userRepository.AddAsync(userWithRole);
            _logger.LogInformation("User registered successfully");

            return new HttpResponseMessage(HttpStatusCode.OK);
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
        /// Function for getting the admin token 
        /// </summary>
        /// <param name="keycloakUrl"></param>
        /// <param name="realm"></param>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <returns></returns>
        private async Task<string> GetAdminAccessTokenAsync(string keycloakUrl, string realm, string clientId, string clientSecret)
        {
            var tokenRequestUrl = $"{keycloakUrl}/realms/{realm}/protocol/openid-connect/token";
            var tokenRequest = new HttpRequestMessage(HttpMethod.Post, tokenRequestUrl);

            tokenRequest.Content = new FormUrlEncodedContent(new[]
            {
                 new KeyValuePair<string, string>("client_id", clientId),
                 new KeyValuePair<string, string>("client_secret", clientSecret),
                 new KeyValuePair<string, string>("grant_type", "client_credentials")
            });

            var response = await _httpClient.SendAsync(tokenRequest);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(content);

            return tokenResponse.AccessToken;
        }
        /// <summary>
        /// Creation of a confirmation email
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        //public EmailSender CreateConfirmationEmail(string emailAddress)
        //{
        //    return new EmailSender
        //    {
        //        To = emailAddress,
        //        Subject = "Registration's confirmation",
        //        Body = "Your registration has been approved with success!"
        //    };
        //}
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
                throw new NotFoundException("This user doesn't exist");
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
                throw new NotFoundException("This user doesn't exist");
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
                throw new NotFoundException("This user doesn't exist");
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
        /// <summary>
        /// Retrieve RefreshToken from the header
        /// </summary>
        /// <returns></returns>
        public string RetrieveRefreshToken()
        {
            string refreshToken = _httpContextAccessor.HttpContext.Request.Headers["Refresh-Token"].ToString();

            if (string.IsNullOrEmpty(refreshToken))
            {
                _logger.LogError("refresh token is missing from the header.");

                return null;
            }

            return refreshToken;
        }
    }
}
