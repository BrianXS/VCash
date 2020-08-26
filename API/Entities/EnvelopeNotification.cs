using System;
using API.Entities.Administrative;

namespace API.Entities
{
    public class EnvelopeNotification : IAuditable
    {
        public int Id { get; set; }
        public string Message { get; set; }

        public int Quantity { get; set; }
        public int Total { get; set; }

        public int DenominationTypeId { get; set; }
        public DenominationType DenominationType { get; set; }

        public int NotificationTypeId { get; set; }
        public NotificationType NotificationType { get; set; }
        
        public int EnvelopeId { get; set; }
        public Envelope Envelope { get; set; }
        
        
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}