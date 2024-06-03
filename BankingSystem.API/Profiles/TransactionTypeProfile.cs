using AutoMapper;
using BankingSystem.API.Requests;
using BankingSystem.API.Response;
using BankingSystem.DataAccess.Entities;

namespace BankingSystem.API.Profiles
{
    public class TransactionTypeProfile: Profile
    {
        public TransactionTypeProfile() 
        {
            CreateMap<TransactionType, TransactionTypeRequest>().ReverseMap();
            CreateMap<TransactionType, TransactionTypeResponse>().ReverseMap();
            CreateMap<TransactionTypeRequest, TransactionTypeResponse>().ReverseMap();
        }
    }
}
