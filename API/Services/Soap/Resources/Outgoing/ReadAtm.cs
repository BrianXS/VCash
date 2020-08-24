using System.Collections.Generic;
using System.Runtime.Serialization;

namespace API.Services.Soap.Resources.Outgoing
{
    [DataContract]
    public class ReadAtm
    {
        [DataMember]
        public string ResultCode { get; set; }
        
        [DataMember]
        public string ResultDescription { get; set; }

        [DataMember]
        public List<Ticket> Tickets { get; set; }
    }
}