using System;
using API.Entities.AtmMaintenance;
using API.Enums.ATM;
using API.Repositories.Interfaces;
using API.Services.Database;
using API.Services.Soap.Resources.Outgoing;
using AutoMapper;

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
        
        public CreateTicket CreateTicket(Services.Soap.Resources.Incoming.CreateTicket ticket)
        {
            var ticketToBeStored = _mapper.Map<TicketDiebold>(ticket);
            
            ticketToBeStored.ConceptId = _ticketConceptRepository
                .FindTicketConceptByCodeAndPlatform(ticket.Concept, Brand.Diebold).Id;
            
            ticketToBeStored.FailingModuleId = _atmModuleRepository
                .FindAtmModuleByNameAndPlatform(ticket.ModuleCode, Brand.Diebold).Id;
            
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
    }
}