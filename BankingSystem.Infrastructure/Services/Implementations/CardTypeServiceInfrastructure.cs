using BankingSystem.DataAccess.Entities;
using BankingSystem.DataAccess.Repositories.Interfaces;
using BankingSystem.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace BankingSystem.Infrastructure.Services.Implementations
{
    public class CardTypeServiceInfrastructure : ICardTypeServiceInfrastructure
    {
        private readonly ICardTypeRepository _cardTypeRepository;
        private readonly ILogger<CardTypeServiceInfrastructure> _logger;
        /// <summary>
        /// Initializes a new instance cref <see cref="CardTypeServiceInfrastructure"/>
        /// </summary>
        /// <param name="cardTypeRepository"></param>
        public CardTypeServiceInfrastructure(ICardTypeRepository cardTypeRepository, ILogger<CardTypeServiceInfrastructure> logger)
        {
            _cardTypeRepository = cardTypeRepository;
            _logger = logger;
        }
        /// <summary>
        /// Function for adding card type
        /// </summary>
        /// <param name="cardType"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<CardType> AddAsync(CardType cardType)
        {
            var cardTypeLooked = await _cardTypeRepository.GetByNameAsync(cardType.Name);
            if (cardTypeLooked is not null)
            {
                _logger.LogError("This card already exists");
                throw new Exception("This card type exists already");
            }

            var addedCardType = await _cardTypeRepository.AddAsync(cardType);

            return addedCardType;
        }
        /// <summary>
        /// Function for deleting a card type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<CardType> DeleteAsync(int id)
        {
            var cardTypeLooked = await _cardTypeRepository.GetByIdAsync(id);
            if (cardTypeLooked is null)
            {
                _logger.LogError("This card type doesn't  exist");
                throw new Exception("This card type does not exist");
            }

            var deletedCardType = await _cardTypeRepository.DeleteAsync(cardTypeLooked);

            return deletedCardType;
        }
        /// <summary>
        /// Function for getting card type by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CardType> GetByIdAsync(int id)
        {
            var cardTypeLooked = await _cardTypeRepository.GetByIdAsync(id);
            if (cardTypeLooked is null)
            {
                _logger.LogError("This card type  doesn't  exist");
                throw new Exception("This card type doesn't exist");
            }

            return cardTypeLooked;
        }
        /// <summary>
        /// Function for updating card type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<CardType> UpdateAsync(int id)
        {
            var cardTypeLooked = await _cardTypeRepository.GetByIdAsync(id);
            if (cardTypeLooked is null)
            {
                _logger.LogError("This card type doesn't  exist");
                throw new Exception("This card type does not exist");
            }
            var updatedCardType = await _cardTypeRepository.UpdateAsync(cardTypeLooked);

            return updatedCardType;
        }
    }
}
