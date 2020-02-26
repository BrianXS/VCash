using API.Entities;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;
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