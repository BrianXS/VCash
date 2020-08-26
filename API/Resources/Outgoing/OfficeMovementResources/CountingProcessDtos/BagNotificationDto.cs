using API.Entities;
using API.Entities.Administrative;

namespace API.Resources.Outgoing.OfficeMovementResources.CountingProcessDtos
{
    public class BagNotificationDto
    {
        public string Message { get; set; }

        public int Quantity { get; set; }
        public int Total { get; set; }
        
        public DenominationType DenominationType { get; set; }
        public NotificationType NotificationType { get; set; }
    }
}