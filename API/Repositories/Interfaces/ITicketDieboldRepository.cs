using System.Collections.Generic;
using CreateOutgoingTicket = API.Services.Soap.Resources.Outgoing.CreateTicket;
using CreateIncomingTicket = API.Services.Soap.Resources.Incoming.CreateTicket;

using AcceptOutgoingTicket = API.Services.Soap.Resources.Outgoing.AcceptTicket;
using AcceptIncomingTicket = API.Services.Soap.Resources.Incoming.AcceptTicket;

using FindOutgoingTicket = API.Services.Soap.Resources.Outgoing.StatusTicket;
using FindIncomingTicket = API.Services.Soap.Resources.Incoming.StatusTicket;

using ReadOutgoingAtm = API.Services.Soap.Resources.Outgoing.ReadAtm;
using ReadIncomingAtm = API.Services.Soap.Resources.Incoming.ReadAtm;

namespace API.Repositories.Interfaces
{
    public interface ITicketDieboldRepository
    {
        CreateOutgoingTicket CreateTicket(CreateIncomingTicket Ticket);
        AcceptOutgoingTicket AcceptTicket(AcceptIncomingTicket Ticket);
        FindOutgoingTicket FindTicket(FindIncomingTicket Ticket);
        ReadOutgoingAtm FindTicketsByAtm(ReadIncomingAtm Ticket);
    }
}