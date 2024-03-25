namespace BankingSystem.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Function for getting token from the server
        /// </summary>
        /// <param name="tokenEndPoint"></param>
        /// <returns></returns>
        Task<string> GetUserTokenAsync(string tokenEndPoint, StringContent requestBody);
    }
}
