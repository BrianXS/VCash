using CreateOutgoingTicket = API.Services.Soap.Resources.Outgoing.CreateTicket;
using CreateIncomingTicket = API.Services.Soap.Resources.Incoming.CreateTicket;

namespace API.Repositories.Interfaces
{
    public interface ITicketDieboldRepository
    {
        CreateOutgoingTicket CreateTicket(CreateIncomingTicket Ticket);
    }
}