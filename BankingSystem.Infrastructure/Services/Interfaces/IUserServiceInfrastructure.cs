namespace BankingSystem.Infrastructure.Services.Interfaces
{
    public interface IUserServiceInfrastructure
    {
        /// <summary>
        /// Function for getting token from the server
        /// </summary>
        /// <param name="tokenEndPoint"></param>
        /// <returns></returns>
        Task<string> GetUserTokenAsync(string tokenEndPoint, StringContent requestBody);

    }
}
