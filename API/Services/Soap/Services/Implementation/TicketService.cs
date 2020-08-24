using System;
using System.Xml;
using API.Services.Soap.Resources.Incoming;
using API.Services.Soap.Services.Interfaces;
using AcceptTicket = API.Services.Soap.Resources.Outgoing.AcceptTicket;
using ChangeTicket = API.Services.Soap.Resources.Outgoing.ChangeTicket;
using CloseTicket = API.Services.Soap.Resources.Outgoing.CloseTicket;
using CreateTicket = API.Services.Soap.Resources.Outgoing.CreateTicket;
using ReadAtm = API.Services.Soap.Resources.Outgoing.ReadAtm;
using StatusTicket = API.Services.Soap.Resources.Outgoing.StatusTicket;

namespace API.Services.Soap.Services.Implementation
{
    public class TicketService : ITicketService
    {
        public CreateTicket Create_Ticket(Resources.Incoming.CreateTicket createTicket)
        {
            return new CreateTicket();
        }

        public AcceptTicket Accepted_Ticket(Resources.Incoming.AcceptTicket acceptTicket)
        {
            throw new NotImplementedException();
        }

        public CloseTicket Close_Ticket(Resources.Incoming.CloseTicket closeTicket)
        {
            throw new NotImplementedException();
        }

        public ChangeTicket Change_Ticket(Resources.Incoming.ChangeTicket changeTicket)
        {
            throw new NotImplementedException();
        }

        public StatusTicket Status_Ticket(Resources.Incoming.StatusTicket statusTicket)
        {
            throw new NotImplementedException();
        }

        public ReadAtm Read_Ticket_Atm(Resources.Incoming.ReadAtm readAtm)
        {
            throw new NotImplementedException();
        }
    }
}