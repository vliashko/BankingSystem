using AutoMapper;
using BankingSystem.API.Requests;
using BankingSystem.API.Response;
using BankingSystem.DataAccess.Entities;

namespace BankingSystem.API.Profiles
{
    public class BankProfile : Profile
    {
        public BankProfile()
        {
            CreateMap<Bank, BankRequest>().ReverseMap();
            CreateMap<Bank, BankResponse>().ReverseMap();
            CreateMap<BankRequest, BankResponse>().ReverseMap();
        }
    }
}
