using AutoMapper;
using Infra.CrossCutting.Adapter.AutoMapper.Profiles;

namespace Infra.CrossCutting.Adapter.AutoMapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            new UserProfile();
        }
    }
}
