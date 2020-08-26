using System;

namespace API.Entities.AtmMaintenance
{
    public class TicketDiebold
    {
        public int Id { get; set; }

        public int View { get; set; } // mapped
        public int Priority { get; set; } // mapped

        public string TicketSourceNumber { get; set; } // mapped
        public int TicketNumberGenerated { get; set; } // mapped
        
        public bool IsAppointment { get; set; } // mapped
        public DateTime AppointmentDate { get; set; } // mapped

        /*public int ConceptId { get; set; } 
        public TicketConcept Concept { get; set; } 

        public int FailingModuleId { get; set; }
        public AtmModule FailingModule { get; set; }*/
        
        public string Status { get; set; }
        public string ProblemDescription { get; set; } // mapped

        public string EquipmentCode { get; set; } // mapped
        public string CustomerCode { get; set; } // mapped
        public string ServiceLine { get; set; } // mapped 
        public string ProductLine { get; set; } // mapped
    }
}