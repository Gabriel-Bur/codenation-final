using Application.ViewModels;
using AutoMapper;
using Domain.Core.Entity;

namespace Infra.CrossCutting.Adapter.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserSingUpViewModel>()
                .ReverseMap();

            CreateMap<User, UserLoginViewModel>()
                .ReverseMap();
        }
    }
}
