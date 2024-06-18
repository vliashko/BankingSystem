using BankingSystem.DataAccess.Entities;
using BankingSystem.DataAccess.Repositories.Interfaces;
using BankingSystem.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace BankingSystem.Infrastructure.Services.Implementations
{
    public class PassportServiceInfrastructure : IPassportServiceInfrastructure
    {
        private readonly IPassportRepository _passportRepository;
        private readonly ILogger<PassportServiceInfrastructure> _logger;
        public PassportServiceInfrastructure(IPassportRepository passportRepository, ILogger<PassportServiceInfrastructure> logger)
        {
            _passportRepository = passportRepository;
            _logger = logger;
        }
        /// <summary>
        /// Function for adding a passport
        /// </summary>
        /// <param name="passport"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Passport> AddAsync(Passport passport)
        {
            var passportLooked = await _passportRepository.GetByFirstAndSurnameAsync(passport.FirstName, passport.SurName);
            if (passportLooked is not null)
            {
                _logger.LogError("There is already a passport with those names");
                throw new Exception("This passport already exists");
            }

            var passportAdded = await _passportRepository.AddAsync(passport);

            return passportAdded;
        }
        /// <summary>
        /// Function for deleting a passport
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Passport> DeleteAsync(int id)
        {
            var passportLooked = await _passportRepository.GetByIdAsync(id);
            if (passportLooked is null)
            {
                _logger.LogError("The passport with this ID does not exist");
                throw new Exception("This passport does not exist");
            }

            var passportDeleted = await _passportRepository.DeleteAsync(passportLooked);

            return passportDeleted;
        }
        /// <summary>
        /// Function for getting a passport by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Passport> GetByIdAsync(int id)
        {
            var passportLooked = await _passportRepository.GetByIdAsync(id);
            if (passportLooked is null)
            {
                _logger.LogError("The passport with this ID does not exist");
                throw new Exception("This passport doesn't exist");
            }

            return passportLooked;
        }
        /// <summary>
        /// Function  for updating a passport
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Passport> UpdateAsync(int id)
        {
            var passportLooked = await _passportRepository.GetByIdAsync(id);
            if (passportLooked is null)
            {
                _logger.LogError("The passport with this ID does not exist");
                throw new Exception("This passport does not exist");
            }

            var passportUpdated = await _passportRepository.UpdateAsync(passportLooked);

            return passportUpdated;
        }
        /// <summary>
        /// Get all client's passeport
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Passport>> GetAllPassportsAsync(int pageNumber, int pageSize)
        {
            var passports = await _passportRepository.GetAllAsync(pageNumber, pageSize);
            if (passports is null)
            {
                _logger.LogError("There are no passports");
                throw new Exception("There are no passports");
            }

            return passports;
        }
    }
}
