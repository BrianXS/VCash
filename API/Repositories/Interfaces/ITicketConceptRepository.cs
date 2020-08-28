using System.Collections.Generic;
using API.Entities.AtmMaintenance;
using API.Enums.ATM;
using API.Resources.Incoming.AtmMaintenanceResources;
using API.Resources.Outgoing.AtmMaintenanceResources;

namespace API.Repositories.Interfaces
{
    public interface ITicketConceptRepository
    {
        TicketConceptResponse FindTicketConceptResponseById(int id);
        TicketConcept FindTicketConceptById(int id);
        TicketConcept FindTicketConceptByCodeAndPlatform(string code, Brand platform);
        List<TicketConceptResponse> GetAllTicketConcepts();
        void CreateTicketConcept(TicketConceptRequest ticketConcept);
        void CreateTicketConceptsRange(List<TicketConceptRequest> ticketConcets);
        TicketConceptResponse UpdateTicketConcept(int id, TicketConceptRequest updatedTicketConcept);
        void DeleteTicketConcept(TicketConcept ticketConcept);
        int Count();
    }
}