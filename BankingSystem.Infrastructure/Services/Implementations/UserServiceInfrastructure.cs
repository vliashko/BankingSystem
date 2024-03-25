using BankingSystem.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace BankingSystem.Infrastructure.Services.Implementations
{
    public class UserServiceInfrastructure : IUserServiceInfrastructure
    {
        private readonly ILogger<UserServiceInfrastructure> _logger;
        /// <summary>
        /// Initializes a new instance cref of < see cref="UserServiceInfrastructure">
        /// </summary>
        /// <param name="logger"></param>
        public UserServiceInfrastructure(ILogger<UserServiceInfrastructure> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Function for getting the access token
        /// </summary>
        /// <param name="tokenEndPoint"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        public async Task<string> GetUserTokenAsync(string tokenEndPoint, StringContent requestBody)
        {
            var tokenResponse = String.Empty;
            var client = new HttpClient();

            var response = await client.PostAsync(tokenEndPoint, requestBody);
            if (response.IsSuccessStatusCode)
            {
                tokenResponse = await response.Content.ReadAsStringAsync();
                _logger.LogInformation("The request has been processed successfully");
            }
            else
            {
                _logger.LogError("The request was not processed successfully");
            }

            return tokenResponse;
        }

    }
}
