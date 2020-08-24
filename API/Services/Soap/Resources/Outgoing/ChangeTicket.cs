using System.Runtime.Serialization;

namespace API.Services.Soap.Resources.Outgoing
{
    [DataContract]
    public class ChangeTicket
    {
        [DataMember]
        public string ResultCode { get; set; }

        [DataMember]
        public string ResultDescription { get; set; }

        [DataMember]
        public string TicketNumberGenerated { get; set; }

        [DataMember]
        public string TicketSourceNumber { get; set; }

        [DataMember]
        public string DateTimeATT { get; set; }

        [DataMember]
        public string Responsable { get; set; }
    }
}