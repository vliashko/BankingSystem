using BankingSystem.BusinessLogic.Services.Interfaces;
using BankingSystem.Infrastructure.Services.Interfaces;

namespace BankingSystem.BusinessLogic.Services.Implementantions
{
    public class UserService : IUserService
    {
        private readonly IUserServiceInfrastructure _userServiceInfrastructure;
        /// <summary>
        /// Initializes an new instance cref of < see cref="UserService">
        /// </summary>
        /// <param name="userServiceInfrastructure"></param>
        public UserService(IUserServiceInfrastructure userServiceInfrastructure)
        {
            _userServiceInfrastructure = userServiceInfrastructure;
        }
        /// <summary>
        /// Function for getting the accesToken
        /// </summary>
        /// <param name="tokenEndPoint"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        public async Task<string> GetUserTokenAsync(string tokenEndPoint, StringContent requestBody)
        {

            var token = await _userServiceInfrastructure.GetUserTokenAsync(tokenEndPoint, requestBody);

            return token;
        }
    }
}
