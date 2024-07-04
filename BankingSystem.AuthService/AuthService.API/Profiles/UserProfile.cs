using AutoMapper;
using BankingSystem.AuthService.AuthService.API.Requests;
using BankingSystem.AuthService.AuthService.API.Response;
using BankingSystem.AuthService.BankingSystem.DataAccess.Entities;
using BankingSystem.Messages.Shared;

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
            CreateMap<User, UserRegisterMessage>().ReverseMap();
            CreateMap<User, UserDeletedMessage>().ReverseMap();
        }
    }
}
