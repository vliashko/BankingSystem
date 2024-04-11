using BankingSystem.DataAccess.Entities;

namespace BankingSystem.Infrastructure.Services.Interfaces
{
    public interface ICardServiceInfrastructure
    {
        /// <summary>
        /// Function for adding a card
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        Task<Card> AddAsync(Card card);
        /// <summary>
        /// Function for updating a card
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Card> UpdateAsync(int id);
        /// <summary>
        /// Function for deleting a card
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Card> DeleteAsync(int id);
        /// <summary>
        /// Function for getting a card by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Card> GetByIdAsync(int id);
    }
}
