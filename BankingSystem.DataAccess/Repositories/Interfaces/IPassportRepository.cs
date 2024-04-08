using BankingSystem.DataAccess.Entities;

namespace BankingSystem.DataAccess.Repositories.Interfaces
{
    public interface IPassportRepository
    {
        /// <summary>
        /// Function for adding passport
        /// </summary>
        /// <param name="passport"></param>
        /// <returns></returns>
        Task<Passport> AddAsync(Passport passport);
        /// <summary>
        /// Function for updating a passport
        /// </summary>
        /// <param name="passport"></param>
        /// <returns></returns>
        Task<Passport> UpdateAsync(Passport passport);
        /// <summary>
        /// Function for deleting a passport
        /// </summary>
        /// <param name="passport"></param>
        /// <returns></returns>
        Task<Passport> DeleteAsync(Passport passport);
        /// <summary>
        /// Function for getting a passport by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Passport> GetByIdAsync(int id);
        /// <summary>
        /// Function for getting a passport by firstname and surname
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="surname"></param>
        /// <returns></returns>
        Task<Passport> GetByFirstAndSurnameAsync(string firstname, string surname);
    }
}
