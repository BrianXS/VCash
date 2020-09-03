using System.Collections.Generic;
using System.Linq;
using API.Entities.Administrative;
using API.Entities.AtmMaintenance;
using API.Repositories.Interfaces;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Incoming.AtmMaintenanceResources;
using API.Resources.Outgoing.AdministrativeResources;
using API.Resources.Outgoing.AtmMaintenanceResources;
using API.Services.Database;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations
{
    public class TicketStatusRepository : ITicketStatusRepository
    {
        private readonly VcashDbContext _dbContext;
        private readonly IMapper _mapper;

        public TicketStatusRepository(VcashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public TicketStatusResponse FindTicketStatusResponseById(int id)
        {
            var ticketStatus = _dbContext.TicketStatuses.FirstOrDefault(x => x.Id.Equals(id));
            
            return _mapper.Map<TicketStatusResponse>(ticketStatus);
        }

        public TicketStatus FindTicketStatusById(int id)
        {
            return _dbContext.TicketStatuses.FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<TicketStatusResponse> GetAllTicketStatuses()
        {
            return _mapper.Map<List<TicketStatusResponse>>(_dbContext.TicketStatuses.ToList());
        }

        public void CreateTicketStatus(TicketStatusRequest ticketStatus)
        {
            _dbContext.TicketStatuses.Add(_mapper.Map<TicketStatus>(ticketStatus));
            _dbContext.SaveChanges();
        }

        public void CreateTicketStatusesRange(List<TicketStatusRequest> ticketStatuses)
        {
            _dbContext.TicketStatuses.AddRange(_mapper.Map<List<TicketStatus>>(ticketStatuses));
            _dbContext.SaveChanges();
        }

        public TicketStatusResponse UpdateTicketStatus(int id, TicketStatusRequest updatedTicketStatus)
        {
            var ticketStatusToBeUpdated = _dbContext.TicketStatuses.FirstOrDefault(x => x.Id.Equals(id));
            _mapper.Map(updatedTicketStatus, ticketStatusToBeUpdated);

            _dbContext.TicketStatuses.Update(ticketStatusToBeUpdated);
            _dbContext.SaveChanges();
            return _mapper.Map<TicketStatusResponse>(ticketStatusToBeUpdated);
        }

        public void DeleteTicketStatus(TicketStatus ticketStatus)
        {
            _dbContext.TicketStatuses.Remove(ticketStatus);
            _dbContext.SaveChanges();
        }
    }
}