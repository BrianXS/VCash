using API.Entities;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;
using AutoMapper;

namespace API.Profiles
{
    public class NotificationTypeProfile : Profile
    {
        public NotificationTypeProfile()
        {
            CreateMap<NotificationType, NotificationTypeResponse>();
            CreateMap<NotificationTypeCreateRequest, NotificationType>();
            CreateMap<NotificationTypeUpdateRequest, NotificationType>();
        }
    }
}