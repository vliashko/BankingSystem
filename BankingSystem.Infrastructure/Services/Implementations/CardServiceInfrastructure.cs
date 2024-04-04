using BankingSystem.DataAccess.Entities;
using BankingSystem.DataAccess.Repositories.Interfaces;
using BankingSystem.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace BankingSystem.Infrastructure.Services.Implementations
{
    public class CardServiceInfrastructure : ICardServiceInfrastructure
    {
        private readonly ICardRepository _cardRepository;
        private readonly ILogger<CardServiceInfrastructure> _logger;
        /// <summary>
        /// Initializes a new instance cref <see cref="CardServiceInfrastructure"/>
        /// </summary>
        /// <param name="cardRepository"></param>
        public CardServiceInfrastructure(ICardRepository cardRepository, ILogger<CardServiceInfrastructure> logger)
        {
            _cardRepository = cardRepository;
            _logger = logger;
        }
        /// <summary>
        /// Function for adding card
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Card> AddAsync(Card card)
        {
            var cardLooked = await _cardRepository.GetByNameAsync(card.Name);
            if (cardLooked is not null)
            {
                _logger.LogError("This card already exists");
                throw new Exception("This card exists already");
            }

            var addedCard = await _cardRepository.AddAsync(card);

            return addedCard;
        }
        /// <summary>
        /// Function for deleting a card
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Card> DeleteAsync(int id)
        {
            var cardLooked = await _cardRepository.GetByIdAsync(id);
            if (cardLooked is null)
            {
                _logger.LogError("This card already exists");
                throw new Exception("This card does not exist");
            }

            var deletedCard = await _cardRepository.DeleteAsync(cardLooked);

            return deletedCard;
        }
        /// <summary>
        /// Function for getting card by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Card> GetByIdAsync(int id)
        {
            var cardLooked = await _cardRepository.GetByIdAsync(id);
            if (cardLooked is null)
            {
                _logger.LogError("This card already exists");
                throw new Exception("This card doesn't exist");
            }

            return cardLooked;
        }
        /// <summary>
        /// Function for updating card
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Card> UpdateAsync(int id)
        {
            var cardLooked = await _cardRepository.GetByIdAsync(id);
            if (cardLooked is null)
            {
                _logger.LogError("This card already exists");
                throw new Exception("This card does not exist");
            }
            var updatedCard = await _cardRepository.UpdateAsync(cardLooked);

            return updatedCard;
        }
    }
}
