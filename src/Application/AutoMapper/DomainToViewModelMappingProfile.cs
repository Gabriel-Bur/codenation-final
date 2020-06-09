using Application.ViewModels.Request;
using AutoMapper;
using Domain.Core.Entity;

namespace Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserLoginRequest>();
            CreateMap<User, UserSingUpRequest>();
        }
    }
}
