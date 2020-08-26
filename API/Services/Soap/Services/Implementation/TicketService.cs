using System;
using System.Xml;
using API.Repositories.Interfaces;
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
        private readonly ITicketDieboldRepository _ticketDieboldRepository;

        public TicketService(ITicketDieboldRepository ticketDieboldRepository)
        {
            _ticketDieboldRepository = ticketDieboldRepository;
        }
        public CreateTicket Create_Ticket(Resources.Incoming.CreateTicket createTicket)
        {
            // todo: verify credentials
            // todo: no existe el equipo en docbase
            // todo: verify campo type
            // todo: No existe el módulo en el equipo
            // todo: No se encontró generador de servicio activo
            // todo: No existe contrato para la línea de servicio
            // todo: Ya existe un ticket en Docbase para el ticket Cliente
            // todo: Ya existe un Ticket en Docbase para el módulo.
            _ticketDieboldRepository.CreateTicket(createTicket);
            return new CreateTicket();
        }

        public AcceptTicket Accepted_Ticket(Resources.Incoming.AcceptTicket acceptTicket)
        {
            return new AcceptTicket();
        }

        public CloseTicket Close_Ticket(Resources.Incoming.CloseTicket closeTicket)
        {
            return new CloseTicket();
        }

        public ChangeTicket Change_Ticket(Resources.Incoming.ChangeTicket changeTicket)
        {
            return new ChangeTicket();
        }

        public StatusTicket Status_Ticket(Resources.Incoming.StatusTicket statusTicket)
        {
            return new StatusTicket();
        }

        public ReadAtm Read_Ticket_Atm(Resources.Incoming.ReadAtm readAtm)
        {
            return new ReadAtm();
        }
    }
}