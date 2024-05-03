using AutoMapper;
using BankingSystem.API.Requests;
using BankingSystem.API.Response;
using BankingSystem.DataAccess.Entities;

namespace BankingSystem.API.Profiles
{
    public class UserProfile : Profile
    {
        /// <summary>
        /// Mapping profile
        /// </summary>
        public UserProfile() 
        {
            CreateMap<User, UserRegisterRequest>().ReverseMap();
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<UserRegisterRequest, UserResponse>().ReverseMap();
        }
    }
}
