using System;
using System.Collections.Generic;
using System.Linq;
using API.Entities.AtmMaintenance;
using API.Enums.ATM;
using API.Repositories.Interfaces;
using API.Services.Database;
using API.Services.Soap.Resources.Outgoing;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations
{
    public class TicketDieboldRepository : ITicketDieboldRepository
    {
        private readonly VcashDbContext _dbContext;
        private readonly ITicketConceptRepository _ticketConceptRepository;
        private readonly IAtmModuleRepository _atmModuleRepository;
        private readonly IMapper _mapper;

        public TicketDieboldRepository(VcashDbContext dbContext, 
            ITicketConceptRepository ticketConceptRepository,
            IAtmModuleRepository atmModuleRepository, 
            IMapper mapper)
        {
            _dbContext = dbContext;
            _ticketConceptRepository = ticketConceptRepository;
            _atmModuleRepository = atmModuleRepository;
            _mapper = mapper;
        }
        
        //Todo: Add Validation
        public CreateTicket CreateTicket(Services.Soap.Resources.Incoming.CreateTicket ticket)
        {
            var ticketToBeStored = _mapper.Map<TicketDiebold>(ticket);
            
            ticketToBeStored.ConceptId = _ticketConceptRepository
                .FindTicketConceptByCodeAndPlatform(ticket.Concept, Brand.Diebold).Id;
            
            ticketToBeStored.FailingModuleId = _atmModuleRepository
                .FindAtmModuleByDescriptionAndPlatform(ticket.ModuleCode, Brand.Diebold).Id;

            ticketToBeStored.StatusId = _dbContext.TicketStatuses
                .FirstOrDefault(x => x.Code == "PDT").Id;

            //Todo: This should rather be looked for in the atm repository
            //Todo: Because Offices and ATMs are both different physical locations 
            //Todo: And serve different roles. It is done this way due to administrative pressures
            ticketToBeStored.OfficeId = _dbContext.Offices
                .FirstOrDefault(x => x.ClientCode == ticket.EquipmentCode).Id;
            
            _dbContext.TicketsDiebold.Add(ticketToBeStored);
            _dbContext.SaveChanges();
            
            return new CreateTicket
            {
                ResultCode = "1",
                ResultDescription = "OK",
                TicketSourceNumber = ticket.TicketSourceNumber,
                TicketNumberGenerated = ticket.TicketNumberGenerated,
                Responsable = "Diebold",
                DateTimeATT = DateTime.Now.ToString("yyyy-MM-dd hh:mm"),
            };
        }

        public AcceptTicket AcceptTicket(Services.Soap.Resources.Incoming.AcceptTicket ticket)
        {
            var ticketToBeModified = _dbContext
                .TicketsDiebold.FirstOrDefault(x => x.TicketNumberGenerated == ticket.TicketNumberGenerated);
            
            ticketToBeModified.StatusId = _dbContext.TicketStatuses.FirstOrDefault(x => x.Code == "ABT").Id;

            _dbContext.TicketsDiebold.Update(ticketToBeModified);
            _dbContext.SaveChanges();
            
            return new AcceptTicket
            {
                DateTimeATT = DateTime.Now.ToString("yyyy-MM-dd hh:mm"),
                Responsable = "Diebold",
                ResultCode = "1",
                ResultDescription = "Sin Problemas"
            };
        }

        public StatusTicket FindTicket(Services.Soap.Resources.Incoming.StatusTicket ticket)
        {
            var ticketToBeModified = _dbContext.TicketsDiebold
                .FirstOrDefault(x => x.TicketNumberGenerated == Int32.Parse(ticket.TicketNumberGenerated));
            
            return new StatusTicket
            {
                CodeStatus = ticketToBeModified.Status.Code,
                ResultCode = ticketToBeModified.Status.Description
            };
        }

        //Todo: Add validations
        public ReadAtm FindTicketsByAtm(Services.Soap.Resources.Incoming.ReadAtm ticket)
        {
            var results = _dbContext.TicketsDiebold
                .Where(x => x.EquipmentCode == ticket.EquipmentCode)
                .Include(x => x.FailingModule)
                .Include(x => x.Status)
                .ToList();
            
            return new ReadAtm
            {
                ResultCode = "1",
                ResultDescription = "OK",
                Tickets = _mapper.Map<List<TicketDiebold>, List<Ticket>>(results)
            };
        }
    }
}