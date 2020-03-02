using API.Entities;
using AutoMapper;

namespace API.Profiles
{
    public class EnvelopeNotificationProfile : Profile
    {
        public EnvelopeNotificationProfile()
        {
            CreateMap<Resources.Incoming.OfficeMovementResources.CountingProcessDtos.EnvelopeNotificationDto,
                EnvelopeNotification>();
            
            CreateMap<EnvelopeNotification, 
                Resources.Outgoing.OfficeMovementResources.CountingProcessDtos.EnvelopeNotificationDto>();
        }
    }
}