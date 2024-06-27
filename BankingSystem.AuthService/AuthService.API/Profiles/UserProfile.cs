using AutoMapper;
using BankingSystem.AuthService.AuthService.API.Requests;
using BankingSystem.AuthService.AuthService.API.Response;
using BankingSystem.AuthService.BankingSystem.DataAccess.Entities;

namespace BankingSystem.AuthService.AuthService.API.Profiles
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
