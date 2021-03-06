using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace API.Services.Soap.Resources.Incoming
{
    [DataContract]
    public class CreateTicket
    {
        [DataMember]
        public string TicketSourceNumber { get; set; }

        [DataMember(IsRequired = false)]
        public string TicketNumberGenerated { get; set; }
        
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
        public int ServiceLine { get; set; }
        
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
        public int IdVisita { get; set; }
        
        [DataMember(IsRequired = false)]
        public int IdPrioridad { get; set; }
        
        
        //Casted Items
        
        [XmlIgnore] 
        public DateTime _appoinmentDateTime 
            => DateTime.ParseExact(AppoinmentDateTime, "yyyy-MM-dd hh:mm", CultureInfo.InvariantCulture);
        
        [XmlIgnore] 
        public bool _appointment 
            => bool.Parse(Appoinment.ToLower());
    }
}