using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using API.Entities.AtmMaintenance;
using API.Enums.ATM;
using API.Repositories.Interfaces;
using API.Resources.Incoming.AtmMaintenanceResources;
using API.Resources.Outgoing.AtmMaintenanceResources;
using API.Services.Database;
using AutoMapper;

namespace API.Repositories.Implementations
{
    public class TicketConceptRepository : ITicketConceptRepository
    {
        private readonly VcashDbContext _dbContext;
        private readonly IMapper _mapper;

        public TicketConceptRepository(VcashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public TicketConceptResponse FindTicketConceptResponseById(int id)
        {
            return _mapper.Map<TicketConceptResponse>(_dbContext.TicketConcepts.FirstOrDefault(x => x.Id == id));
        }

        public TicketConcept FindTicketConceptById(int id)
        {
            return _dbContext.TicketConcepts.FirstOrDefault(x => x.Id == id);
        }

        public TicketConcept FindTicketConceptByCodeAndPlatform(string code, Brand platform)
        {
            return _dbContext.TicketConcepts.FirstOrDefault(x => x.Code == code && x.Platform == platform);
        }

        public List<TicketConceptResponse> GetAllTicketConcepts()
        {
            return _mapper.Map<List<TicketConceptResponse>>(_dbContext.TicketConcepts.ToList());
        }

        public void CreateTicketConcept(TicketConceptRequest ticketConcept)
        {
            _dbContext.TicketConcepts.Add(_mapper.Map<TicketConcept>(ticketConcept));
            _dbContext.SaveChanges();
        }

        public void CreateTicketConceptsRange(List<TicketConceptRequest> ticketConcepts)
        {
            _dbContext.TicketConcepts.AddRange(_mapper.Map<List<TicketConcept>>(ticketConcepts));
            _dbContext.SaveChanges();
        }

        public TicketConceptResponse UpdateTicketConcept(int id, TicketConceptRequest updatedTicketConcept)
        {
            var ticketToChange = _dbContext.TicketConcepts.FirstOrDefault(x => x.Id == id);
            _mapper.Map(ticketToChange, updatedTicketConcept);

            _dbContext.TicketConcepts.Update(ticketToChange);
            _dbContext.SaveChanges();
            
            return _mapper.Map<TicketConceptResponse>(ticketToChange);
        }

        public void DeleteTicketConcept(TicketConcept ticketConcept)
        {
            _dbContext.TicketConcepts.Remove(ticketConcept);
            _dbContext.SaveChanges();
        }

        public int Count()
        {
            return _dbContext.TicketConcepts.Count();
        }
    }
}