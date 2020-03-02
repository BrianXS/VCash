using API.Entities;
using AutoMapper;

namespace API.Profiles
{
    public class BagDenominationProfile : Profile
    {
        public BagDenominationProfile()
        {
            CreateMap<Resources.Incoming.OfficeMovementResources.CountingProcessDtos.BagDenominationDto,
                BagDenomination>();
            
            CreateMap<BagDenomination, 
                Resources.Outgoing.OfficeMovementResources.CountingProcessDtos.BagDenominationDto>();
        }
    }
}