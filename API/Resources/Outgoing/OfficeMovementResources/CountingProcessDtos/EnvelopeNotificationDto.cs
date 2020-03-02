using API.Entities;

namespace API.Resources.Outgoing.OfficeMovementResources.CountingProcessDtos
{
    public class EnvelopeNotificationDto
    {
        public string Message { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
        
        public DenominationType DenominationType { get; set; }
        public NotificationType NotificationType { get; set; }
    }
}