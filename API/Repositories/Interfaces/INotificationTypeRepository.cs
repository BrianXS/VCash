using System.Collections.Generic;
using API.Entities;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;

namespace API.Repositories.Interfaces
{
    public interface INotificationTypeRepository
    {
        NotificationTypeResponse FindNotificationTypeResponseById(int id);
        NotificationType FindNotificationTypeById(int id);
        List<NotificationTypeResponse> GetAllNotificationTypes();
        void CreateNotificationType(NotificationTypeCreateRequest notificationType);
        NotificationTypeResponse UpdateNotificationType(int id, NotificationTypeUpdateRequest updatedNotificationType);
        void DeleteNotificationType(NotificationType notificationType);
    }
}