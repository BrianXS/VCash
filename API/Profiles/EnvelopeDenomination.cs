using AutoMapper;

namespace API.Profiles
{
    public class EnvelopeDenomination : Profile
    {
        public EnvelopeDenomination()
        {
            CreateMap<Resources.Incoming.OfficeMovementResources.CountingProcessDtos.EnvelopeDenominationDto,
                EnvelopeDenomination>();
            
            CreateMap<EnvelopeDenomination, 
                Resources.Outgoing.OfficeMovementResources.CountingProcessDtos.EnvelopeDenominationDto>();
        }
    }
}