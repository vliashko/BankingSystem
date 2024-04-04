using AutoMapper;
using BankingSystem.API.Requests;
using BankingSystem.API.Response;
using BankingSystem.DataAccess.Entities;

namespace BankingSystem.API.Profiles
{
    /// <summary>
    /// Configuration of mapping
    /// </summary>
    public class CardTypeProfile : Profile
    {
        public CardTypeProfile() 
        {
            CreateMap<CardType, CardTypeRequest>().ReverseMap();
            CreateMap<CardType, CardTypeResponse>().ReverseMap();
            CreateMap<CardTypeRequest, CardTypeResponse>().ReverseMap();
        }
    }
}
