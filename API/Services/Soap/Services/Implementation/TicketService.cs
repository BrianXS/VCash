using System;
using System.Xml;
using API.Entities.AtmMaintenance;
using API.Enums.ATM;
using API.Repositories.Interfaces;
using API.Services.Soap.Resources.Incoming;
using API.Services.Soap.Services.Interfaces;
using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly ITicketDieboldRepository _ticketDieboldRepository;
        private readonly IAtmModuleRepository _atmModuleRepository;
        private readonly ITicketConceptRepository _ticketConceptRepository;

        public TicketService(IMapper mapper, 
            ITicketDieboldRepository ticketDieboldRepository,
            IAtmModuleRepository atmModuleRepository,
            ITicketConceptRepository ticketConceptRepository)
        {
            _mapper = mapper;
            _ticketDieboldRepository = ticketDieboldRepository;
            _atmModuleRepository = atmModuleRepository;
            _ticketConceptRepository = ticketConceptRepository;
        }
        
        //Todo: Add validations.
        public CreateTicket Create_Ticket(Resources.Incoming.CreateTicket createTicket)
        {
            return _ticketDieboldRepository.CreateTicket(createTicket);
        }
        
        //Todo: This method is not supposed to be received rather it is meant to be sent
        public AcceptTicket Accepted_Ticket(Resources.Incoming.AcceptTicket acceptTicket)
        {
            return _ticketDieboldRepository.AcceptTicket(acceptTicket);
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
            return _ticketDieboldRepository.FindTicketsByAtm(readAtm);
        }
    }
}