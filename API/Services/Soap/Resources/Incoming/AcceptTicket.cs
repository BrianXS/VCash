using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace API.Services.Soap.Resources.Incoming
{
    [DataContract]
    public class AcceptTicket
    {
        [DataMember]
        public string TicketSourceNumber { get; set; }

        [DataMember]
        public int TicketNumberGenerated { get; set; }

        [DataMember]
        public string DateTimeAccepted { get; set; }

        [DataMember]
        public string User { get; set; }

        [DataMember]
        public string Password { get; set; }

        [XmlIgnore]
        public DateTime _dateTimeAccepted
            => DateTime.ParseExact(DateTimeAccepted, "yyyy-MM-dd hh:mm", CultureInfo.InvariantCulture);
    }
}