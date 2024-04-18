using AutoMapper;
using BankingSystem.API.Requests;
using BankingSystem.API.Response;
using BankingSystem.DataAccess.Entities;

namespace BankingSystem.API.Profiles
{
    public class ClientAccountProfile : Profile
    {
        /// <summary>
        /// Configuration of mapping
        /// </summary>
        public ClientAccountProfile()
        {
            CreateMap<ClientAccount, ClientAccountRequest>().ReverseMap();
            CreateMap<ClientAccount, ClientAccountResponse>().ReverseMap();
            CreateMap<ClientAccountRequest, ClientAccountResponse>().ReverseMap();
        }
    }
}
