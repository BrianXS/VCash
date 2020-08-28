using System.ServiceModel;

using CreateOutgoingTicket = API.Services.Soap.Resources.Outgoing.CreateTicket;
using AcceptOutgoingTicket = API.Services.Soap.Resources.Outgoing.AcceptTicket;
using ChangeOutgoingTicket = API.Services.Soap.Resources.Outgoing.ChangeTicket;
using CloseOutgoingTicket = API.Services.Soap.Resources.Outgoing.CloseTicket;
using StatusOutgoingTicket = API.Services.Soap.Resources.Outgoing.StatusTicket;
using ReadOutgoingATM = API.Services.Soap.Resources.Outgoing.ReadAtm;

using CreateIncomingTicket = API.Services.Soap.Resources.Incoming.CreateTicket;
using AcceptIncomingTicket = API.Services.Soap.Resources.Incoming.AcceptTicket;
using ChangeIncomingTicket = API.Services.Soap.Resources.Incoming.ChangeTicket;
using CloseIncomingTicket = API.Services.Soap.Resources.Incoming.CloseTicket;
using StatusIncomingTicket = API.Services.Soap.Resources.Incoming.StatusTicket;
using ReadIncomingAtm = API.Services.Soap.Resources.Incoming.ReadAtm;

namespace API.Services.Soap.Services.Interfaces
{
    [ServiceContract]
    public interface ITicketService
    {
        [OperationContract]
        CreateOutgoingTicket Create_Ticket(CreateIncomingTicket createTicket);

        [OperationContract]
        AcceptOutgoingTicket Accepted_Ticket(AcceptIncomingTicket acceptTicket);
        
        [OperationContract]
        CloseOutgoingTicket Close_Ticket(CloseIncomingTicket closeTicket);
        
        [OperationContract]
        ChangeOutgoingTicket Change_Ticket(ChangeIncomingTicket changeTicket);
        
        [OperationContract]
        StatusOutgoingTicket Status_Ticket(StatusIncomingTicket statusTicket);
        
        [OperationContract]
        ReadOutgoingATM Read_Ticket_Atm(ReadIncomingAtm readAtm);
    }
}