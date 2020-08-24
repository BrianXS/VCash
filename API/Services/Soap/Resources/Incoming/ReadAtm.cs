using System.Runtime.Serialization;

namespace API.Services.Soap.Resources.Incoming
{
    [DataContract]
    public class ReadAtm
    {
        [DataMember]
        public string EquipmentCode { get; set; }

        [DataMember]
        public string CustomerCode { get; set; }

        [DataMember]
        public string ProductLine { get; set; }

        [DataMember]
        public string User { get; set; }

        [DataMember]
        public string Password { get; set; }
    }
}