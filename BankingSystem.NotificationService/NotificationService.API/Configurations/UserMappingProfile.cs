using AutoMapper;
using BankingSystem.Messages.Shared;
using BankingSystem.NotificationService.NotificationService.Infrastructure.Models;

namespace BankingSystem.NotificationService.NotificationService.API.Configurations
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserRegisterMessage, WelcomeEmailReceiver>()
                .ReverseMap();
        }
    }
}
