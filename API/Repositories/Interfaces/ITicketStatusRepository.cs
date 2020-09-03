using System.Collections.Generic;
using API.Entities.Administrative;
using API.Entities.AtmMaintenance;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Incoming.AtmMaintenanceResources;
using API.Resources.Outgoing.AdministrativeResources;
using API.Resources.Outgoing.AtmMaintenanceResources;

namespace API.Repositories.Interfaces
{
    public interface ITicketStatusRepository
    {
        TicketStatusResponse FindTicketStatusResponseById(int id);
        TicketStatus FindTicketStatusById(int id);
        List<TicketStatusResponse> GetAllTicketStatuses();
        void CreateTicketStatus(TicketStatusRequest ticketStatus);
        void CreateTicketStatusesRange(List<TicketStatusRequest> ticketStatuses);
        TicketStatusResponse UpdateTicketStatus(int id, TicketStatusRequest updatedTicketStatus);
        void DeleteTicketStatus(TicketStatus ticketStatus);
    }
}