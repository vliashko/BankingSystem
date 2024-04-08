using BankingSystem.DataAccess.Data;
using BankingSystem.DataAccess.Entities;
using BankingSystem.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.DataAccess.Repositories.Implementations
{
    public class PassportRepository : IPassportRepository
    {
        private readonly BankingSystemDbContext _db;
        public PassportRepository(BankingSystemDbContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Function for adding a passport
        /// </summary>
        /// <param name="passport"></param>
        /// <returns></returns>
        public async Task<Passport> AddAsync(Passport passport)
        {
            _db.Passports.Add(passport);
            await _db.SaveChangesAsync();

            return passport;
        }
        /// <summary>
        /// Function for deleting a passport
        /// </summary>
        /// <param name="passport"></param>
        /// <returns></returns>
        public async Task<Passport> DeleteAsync(Passport passport)
        {
            _db.Passports.Remove(passport);
            await _db.SaveChangesAsync();

            return passport;
        }
        /// <summary>
        /// Function for getting a passport by Firstname and Surname
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="surname"></param>
        /// <returns></returns>
        public async Task<Passport> GetByFirstAndSurnameAsync(string firstname, string surname)
        {
            return await _db.Passports.FirstOrDefaultAsync(p => p.FirstName.Equals(firstname) && p.SurName.Equals(surname));
        }
        /// <summary>
        /// Function for getting a passport by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Passport> GetByIdAsync(int id)
        {
            return await _db.Passports.FirstOrDefaultAsync(p => p.Id == id);
        }
        /// <summary>
        /// Function for updating a passport
        /// </summary>
        /// <param name="passport"></param>
        /// <returns></returns>
        public async Task<Passport> UpdateAsync(Passport passport)
        {
            _db.Passports.Update(passport);
            await _db.SaveChangesAsync();

            return passport;
        }
    }
}
