using BankingSystem.DataAccess.Data;
using BankingSystem.DataAccess.Entities;
using BankingSystem.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.DataAccess.Repositories.Implementations
{
    public class CardRepository : ICardRepository
    {
        private readonly BankingSystemDbContext _db;
        /// <summary>
        /// Initializes a new instance cref of <see cref="CardRepository">
        /// </summary>
        /// <param name="db"></param>
        public CardRepository(BankingSystemDbContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Function for adding a card
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public async Task<Card> AddAsync(Card card)
        {
            _db.Cards.Add(card);
            await _db.SaveChangesAsync();

            return card;
        }
        /// <summary>
        /// Function for deleting a card
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public async Task<Card> DeleteAsync(Card card)
        {
            _db.Cards.Remove(card);
            await _db.SaveChangesAsync();

            return card;
        }
        /// <summary>
        /// Function for getting a card by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Card> GetByIdAsync(int id)
        {
            return await _db.Cards.Include(c => c.CardType).Include(c => c.ClientAccount).FirstOrDefaultAsync(c => c.Id == id);
        }
        /// <summary>
        /// Function for updating a card
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public async Task<Card> UpdateAsync(Card card)
        {
            _db.Cards.Update(card);
            await _db.SaveChangesAsync();

            return card;
        }
        /// <summary>
        /// Function for getting a card  by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Card> GetByNameAsync(string name)
        {
            return await _db.Cards.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
