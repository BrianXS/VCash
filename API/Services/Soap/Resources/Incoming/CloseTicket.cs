using System.Runtime.Serialization;

namespace API.Services.Soap.Resources.Incoming
{
    [DataContract]
    public class CloseTicket
    {
        public string TicketSourceNumber { get; set; }
        public string TicketNumberGenerated { get; set; }
        public string Comments { get; set; }
        public string DateTimeClosed { get; set; }
        public string Type { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}