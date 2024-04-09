using BankingSystem.DataAccess.Entities;

namespace BankingSystem.API.Requests
{
    public class ClientAccountRequest
    {
        /// <summary>
        /// Gets or sets the account balance
        /// </summary>
        public double Balance { get; set; }
        /// <summary>
        /// Gets or sets the bank's identificator
        /// </summary>
        public int BankId { get; set; }
        /// <summary>
        /// Gets or sets the account's identificator
        /// </summary>
        public int AccountTypeId { get; set; }
        /// <summary>
        /// Gets or sets the passport's identificator
        /// </summary>
        public int PassportId { get; set; }
    }
}
