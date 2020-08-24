using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace API.Services.Soap.Resources.Incoming
{
    [DataContract]
    public class ChangeTicket
    {
        [DataMember]
        public string TicketSourceNumber { get; set; }
        
        [DataMember]
        public int TicketNumberGenerated { get; set; }

        [DataMember]
        public string AppoinmentDateTime { get; set; }
        
        [DataMember]
        public string ProblemDescription { get; set; }
        
        [DataMember]
        public string Type { get; set; }
        
        [DataMember]
        public string User { get; set; }
        
        [DataMember]
        public string Password { get; set; }
    }
}