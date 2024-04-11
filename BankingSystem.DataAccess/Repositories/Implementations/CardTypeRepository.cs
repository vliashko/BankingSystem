using BankingSystem.DataAccess.Data;
using BankingSystem.DataAccess.Entities;
using BankingSystem.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.DataAccess.Repositories.Implementations
{
    public class CardTypeRepository : ICardTypeRepository
    {
        private readonly BankingSystemDbContext _db;
        /// <summary>
        /// Initializes a new instance cref of <see cref="CardTypeRepository">
        /// </summary>
        /// <param name="db"></param>
        public CardTypeRepository(BankingSystemDbContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Function for adding a card type
        /// </summary>
        /// <param name="cardType"></param>
        /// <returns></returns>
        public async Task<CardType> AddAsync(CardType cardType)
        {
            _db.CardTypes.Add(cardType);
            await _db.SaveChangesAsync();

            return cardType;
        }
        /// <summary>
        /// Function for deleting a card type
        /// </summary>
        /// <param name="cardType"></param>
        /// <returns></returns>
        public async Task<CardType> DeleteAsync(CardType cardType)
        {
            _db.CardTypes.Remove(cardType);
            await _db.SaveChangesAsync();

            return cardType;
        }
        /// <summary>
        /// Function for getting a card type by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CardType> GetByIdAsync(int id)
        {
            return await _db.CardTypes.FirstOrDefaultAsync(x => x.Id == id);
        }
        /// <summary>
        /// Function for updating a card type
        /// </summary>
        /// <param name="cardType"></param>
        /// <returns></returns>
        public async Task<CardType> UpdateAsync(CardType cardType)
        {
            _db.CardTypes.Update(cardType);
            await _db.SaveChangesAsync();

            return cardType;
        }
        /// <summary>
        /// Function for getting a card type by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<CardType> GetByNameAsync(string name)
        {
            return await _db.CardTypes.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
