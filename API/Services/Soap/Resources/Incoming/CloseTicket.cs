using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Xml.Serialization;

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
        public string DateTimeClosed { get; set; }
        
        [DataMember]
        public string Type { get; set; }
        
        [DataMember]
        public string User { get; set; }
        
        [DataMember]
        public string Password { get; set; }

        [XmlIgnore]
        public DateTime _dateTimeClosed
            => DateTime.ParseExact(DateTimeClosed, "yyyy-MM-dd hh:mm", CultureInfo.CurrentCulture);
    }
}