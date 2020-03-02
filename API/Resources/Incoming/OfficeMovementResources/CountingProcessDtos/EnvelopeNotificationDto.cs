using API.Entities;

namespace API.Resources.Incoming.OfficeMovementResources.CountingProcessDtos
{
    public class EnvelopeNotificationDto
    {
        public string Message { get; set; }
        public int Quantity { get; set; }

        public int DenominationTypeId { get; set; }
        public int NotificationTypeId { get; set; }
    }
}