using AutoMapper;
using BankingSystem.API.Requests;
using BankingSystem.API.Response;
using BankingSystem.DataAccess.Entities;

namespace BankingSystem.API.Profiles
{
    public class AccountTypeProfile: Profile
    {
        public AccountTypeProfile()
        {
            CreateMap<AccountType, AccountTypeRequest>().ReverseMap();
            CreateMap<AccountType, AccountTypeResponse>().ReverseMap();
            CreateMap<AccountTypeRequest, AccountTypeResponse>().ReverseMap();
        }
    }
}
