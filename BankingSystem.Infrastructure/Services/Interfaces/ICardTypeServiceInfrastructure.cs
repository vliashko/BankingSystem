using BankingSystem.DataAccess.Entities;

namespace BankingSystem.Infrastructure.Services.Interfaces
{
    public interface ICardTypeServiceInfrastructure
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
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CardType> UpdateAsync(int id);
        /// <summary>
        /// Function for deleting a cardType
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CardType> DeleteAsync(int id);
        /// <summary>
        /// Function for getting a cardType by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CardType> GetByIdAsync(int id);
    }
}
