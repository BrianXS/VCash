using API.Entities;
using AutoMapper;

namespace API.Profiles
{
    public class EnvelopeProfile : Profile
    {
        public EnvelopeProfile()
        {
            CreateMap<Resources.Incoming.OfficeMovementResources.CountingProcessDtos.EnvelopeDto, Envelope>();
            CreateMap<Envelope, Resources.Outgoing.OfficeMovementResources.CountingProcessDtos.EnvelopeDto>();
        }
    }
}