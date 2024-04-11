using BankingSystem.DataAccess.Entities;

namespace BankingSystem.DataAccess.Repositories.Interfaces
{

    public interface ICardTypeRepository
    {
        /// <summary>
        /// Function for adding a cardType
        /// </summary>
        /// <param name="cardType"></param>
        /// <returns></returns>
        Task<CardType> AddAsync(CardType cardType);
        /// <summary>
        /// Function for updating a cardType
        /// </summary>
        /// <param name="cardType"></param>
        /// <returns></returns>
        Task<CardType> UpdateAsync(CardType cardType);
        /// <summary>
        /// Function for deleting a cardType
        /// </summary>
        /// <param name="cardType"></param>
        /// <returns></returns>
        Task<CardType> DeleteAsync(CardType cardType);
        /// <summary>
        /// Function for getting a cardType by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CardType>GetByIdAsync(int id);
        /// <summary>
        /// Function for getting a cardType by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<CardType> GetByNameAsync(string name);
    }
}
