using System.Runtime.Serialization;

namespace API.Services.Soap.Resources.Incoming
{
    [DataContract]
    public class CreateTicket
    {
        [DataMember]
        public string TicketSourceNumber { get; set; }
        
        [DataMember]
        public string AppoinmentDateTime { get; set; }
        
        [DataMember]
        public string Appoinment { get; set; }
        
        [DataMember]
        public string Concept { get; set; }
        
        [DataMember]
        public string EquipmentCode { get; set; }
        
        [DataMember]
        public string CustomerCode { get; set; }
        
        [DataMember]
        public string ServiceLine { get; set; }
        
        [DataMember]
        public string ProductLine { get; set; }
        
        [DataMember]
        public string ModuleCode { get; set; }
        
        [DataMember]
        public string ProblemDescription { get; set; }
        
        [DataMember]
        public string Type { get; set; }
        
        [DataMember]
        public string User { get; set; }
        
        [DataMember]
        public string Password { get; set; }
        
        [DataMember]
        public string IdVisita { get; set; }
        
        [DataMember]
        public string IdPrioridad { get; set; }
    }
}