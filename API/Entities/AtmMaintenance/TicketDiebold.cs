using System;
using API.Entities.Administrative;

namespace API.Entities.AtmMaintenance
{
    public class TicketDiebold
    {
        public int Id { get; set; }

        public int View { get; set; } 
        public int Priority { get; set; } 

        public string TicketSourceNumber { get; set; } 
        public int TicketNumberGenerated { get; set; } 
        
        public bool IsAppointment { get; set; } 
        public DateTime AppointmentDate { get; set; } 

        public int ConceptId { get; set; } 
        public TicketConcept Concept { get; set; } 

        public int FailingModuleId { get; set; }
        public AtmModule FailingModule { get; set; }

        public int StatusId { get; set; }
        public TicketStatus Status { get; set; }

        public int OfficeId { get; set; }
        public Office Office { get; set; }
        
        public string ProblemDescription { get; set; } 

        public string EquipmentCode { get; set; } 
        public string CustomerCode { get; set; } 
        public string ServiceLine { get; set; }  
        public string ProductLine { get; set; } 
    }
}