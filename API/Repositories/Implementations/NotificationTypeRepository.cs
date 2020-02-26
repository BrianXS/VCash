using System.Collections.Generic;
using System.Linq;
using API.Entities;
using API.Repositories.Interfaces;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;
using API.Services.Database;
using AutoMapper;

namespace API.Repositories.Implementations
{
    public class NotificationTypeRepository : INotificationTypeRepository
    {
        private readonly VcashDbContext _dbContext;
        private readonly IMapper _mapper;

        public NotificationTypeRepository(VcashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public NotificationTypeResponse FindNotificationTypeResponseById(int id)
        {
            var notificationType = _dbContext.NotificationTypes.FirstOrDefault(x => x.Id.Equals(id));
            return _mapper.Map<NotificationTypeResponse>(notificationType);
        }

        public NotificationType FindNotificationTypeById(int id)
        {
            return _dbContext.NotificationTypes.FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<NotificationTypeResponse> GetAllNotificationTypes()
        {
            var notificationTypes = _dbContext.NotificationTypes.ToList();
            return _mapper.Map<List<NotificationTypeResponse>>(notificationTypes);
        }

        public void CreateNotificationType(NotificationTypeCreateRequest notificationType)
        {
            _dbContext.NotificationTypes.Add(_mapper.Map<NotificationType>(notificationType));
            _dbContext.SaveChanges();
        }

        public NotificationTypeResponse UpdateNotificationType(int id, NotificationTypeUpdateRequest updatedNotificationType)
        {
            var notificationTypeToUpdate = _dbContext.NotificationTypes.FirstOrDefault(x => x.Id.Equals(id));
            _mapper.Map(updatedNotificationType, notificationTypeToUpdate);

            _dbContext.NotificationTypes.Update(notificationTypeToUpdate);
            _dbContext.SaveChanges();
            
            return _mapper.Map<NotificationTypeResponse>(notificationTypeToUpdate);
        }

        public void DeleteNotificationType(NotificationType notificationType)
        {
            _dbContext.NotificationTypes.Remove(notificationType);
            _dbContext.SaveChanges();
        }
    }
}