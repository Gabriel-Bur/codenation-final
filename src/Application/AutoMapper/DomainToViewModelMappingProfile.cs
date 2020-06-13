using Application.ViewModels.Request;
using Application.ViewModels.Response;
using AutoMapper;
using Domain.Core.Entity;
using Domain.Entity;

namespace Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserLoginRequest>();
            CreateMap<User, UserSingUpRequest>();
            CreateMap<User, UserSingUpResponse>();

            CreateMap<Error, ErrorResponse>();
            CreateMap<ErrorFile, ErrorFileResponse>();
        }
    }
}
