using System;
using System.Runtime.Serialization;

namespace API.Services.Soap.Resources.Incoming
{
    [DataContract]
    public class CloseTicket
    {
        [DataMember]
        public string TicketSourceNumber { get; set; }
        
        [DataMember]
        public int TicketNumberGenerated { get; set; }
        
        [DataMember]
        public string Comments { get; set; }
        
        [DataMember]
        public DateTime DateTimeClosed { get; set; }
        
        [DataMember]
        public string Type { get; set; }
        
        [DataMember]
        public string User { get; set; }
        
        [DataMember]
        public string Password { get; set; }
    }
}