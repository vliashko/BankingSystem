namespace BankingSystem.Infrastructure.Services.Interfaces
{
    public interface IUserServiceInfrastructure
    {
        /// <summary>
        /// Function for getting token from the server
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<string> LoginAsync(string username, string password);
        Task<HttpResponseMessage> RegisterAsync(string username, string password);

    }
}
