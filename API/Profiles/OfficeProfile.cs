using API.Entities;
using API.Resources.Incoming;
using API.Resources.Outgoing;
using AutoMapper;

namespace API.Profiles
{
    public class OfficeProfile : Profile
    {
        public OfficeProfile()
        {
            CreateMap<Office, OfficeResponse>();
            CreateMap<OfficeCreateRequest, Office>();
            CreateMap<OfficeUpdateRequest, Office>();
        }
    }
}