using BankingSystem.DataAccess.Entities;

namespace BankingSystem.DataAccess.Repositories.Interfaces
{
    public interface ICardRepository
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
        /// <param name="card"></param>
        /// <returns></returns>
        Task<Card> UpdateAsync(Card card);
        /// <summary>
        /// Function for deleting a card
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        Task<Card> DeleteAsync(Card card);
        /// <summary>
        /// Function for getting a card by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Card> GetByIdAsync(int id);
        /// <summary>
        /// Function for getting a card by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<Card> GetByNameAsync(string name);
    }
}
