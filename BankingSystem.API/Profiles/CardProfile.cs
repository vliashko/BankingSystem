using AutoMapper;
using BankingSystem.API.Requests;
using BankingSystem.API.Response;
using BankingSystem.DataAccess.Entities;

namespace BankingSystem.API.Profiles
{
    public class CardProfile : Profile
    {
        /// <summary>
        /// Configuration of mapping
        /// </summary>
        public CardProfile()
        {
            CreateMap<Card, CardRequest>().ReverseMap();
            CreateMap<Card, CardResponse>().ReverseMap();
            CreateMap<CardRequest, CardResponse>().ReverseMap();
            
        }
    }
}
