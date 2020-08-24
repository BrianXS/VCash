using System.Runtime.Serialization;

namespace API.Services.Soap.Resources.Incoming
{
    [DataContract]
    public class StatusTicket
    {
        [DataMember]
        public string TicketSourceNumber { get; set; }

        [DataMember]
        public string TicketNumberGenerated { get; set; }

        [DataMember]
        public string User { get; set; }

        [DataMember]
        public string Password { get; set; }
    }
}