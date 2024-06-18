using BankingSystem.DataAccess.Entities;

namespace BankingSystem.Infrastructure.Services.Interfaces
{
    public interface IPassportServiceInfrastructure
    {
        /// <summary>
        /// Function for adding a passport
        /// </summary>
        /// <param name="passport"></param>
        /// <returns></returns>
        Task<Passport> AddAsync(Passport passport);
        /// <summary>
        /// Function for updating a passport
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Passport> UpdateAsync(int id);
        /// <summary>
        /// Function for deleting a passport
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Passport> DeleteAsync(int id);
        /// <summary>
        /// Function for getting a passport by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Passport> GetByIdAsync(int id);
        /// <summary>
        /// Function for getting client's passport
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<List<Passport>> GetAllPassportsAsync(int pageNumber, int pageSize);
    }
}
