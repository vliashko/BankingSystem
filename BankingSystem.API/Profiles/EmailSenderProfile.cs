using AutoMapper;
using BankingSystem.API.Requests;
using BankingSystem.DataAccess.Entities;

namespace BankingSystem.API.Profiles
{
    public class EmailSenderProfile:Profile
    {
        /// <summary>
        /// Configuration of mapping
        /// </summary>
        public EmailSenderProfile()
        {
            CreateMap<EmailSender, EmailSenderRequest>().ReverseMap();
        }
    }
}
