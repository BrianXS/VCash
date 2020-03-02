using AutoMapper;

namespace API.Profiles
{
    public class BagNotificationProfile : Profile
    {
        public BagNotificationProfile()
        {
            CreateMap<Resources.Incoming.OfficeMovementResources.CountingProcessDtos.BagNotificationDto,
                BagNotificationProfile>();
            
            CreateMap<BagNotificationProfile, 
                Resources.Outgoing.OfficeMovementResources.CountingProcessDtos.BagNotificationDto>();
        }
    }
}