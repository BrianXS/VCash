using API.Entities;
using API.Resources.Incoming;
using API.Resources.Outgoing;
using AutoMapper;

namespace API.Profiles
{
    public class DenominationTypeProfile : Profile
    {
        public DenominationTypeProfile()
        {
            CreateMap<DenominationType, DenominationTypeResponse>();
            CreateMap<DenominationTypeCreateRequest, DenominationType>();
            CreateMap<DenominationTypeUpdateRequest, DenominationType>();
        }
    }
}