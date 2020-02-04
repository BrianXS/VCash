namespace API.Entities
{
    public class BagNotification
    {
        public int Id { get; set; }
        public string Message { get; set; }

        public int Quantity { get; set; }
        public int Total { get; set; }

        public int DenominationTypeId { get; set; }
        public DenominationType DenominationType { get; set; }

        public int NotificationTypeId { get; set; }
        public NotificationType NotificationType { get; set; }

        public int BagId { get; set; }
        public Bag Bag { get; set; }
    }
}