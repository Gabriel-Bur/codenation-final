using Application.ViewModels.Request;
using AutoMapper;
using Domain.Core.Entity;

namespace Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UserSingUpRequest, User>();
            CreateMap<UserLoginRequest, User>();
        }

    }
}
