using AutoMapper;
using BankingSystem.API.Requests;
using BankingSystem.API.Response;
using BankingSystem.DataAccess.Entities;

namespace BankingSystem.API.Profiles
{
    public class PassportProfile : Profile
    {
        /// <summary>
        /// Mapping profile
        /// </summary>
        public PassportProfile() 
        {
            CreateMap<Passport, PassportRequest>().ReverseMap();
            CreateMap<Passport, PassportResponse>().ReverseMap();
            CreateMap<PassportRequest, PassportResponse>().ReverseMap();
        }
    }
}
