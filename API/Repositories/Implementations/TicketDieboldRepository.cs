using API.Entities.AtmMaintenance;
using API.Repositories.Interfaces;
using API.Services.Database;
using API.Services.Soap.Resources.Outgoing;
using AutoMapper;

namespace API.Repositories.Implementations
{
    public class TicketDieboldRepository : ITicketDieboldRepository
    {
        private readonly VcashDbContext _dbContext;
        private readonly IMapper _mapper;

        public TicketDieboldRepository(VcashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public CreateTicket CreateTicket(Services.Soap.Resources.Incoming.CreateTicket ticket)
        {
            _dbContext.TicketsDiebold.Add(_mapper.Map<TicketDiebold>(ticket));
            _dbContext.SaveChanges();
            
            return new CreateTicket();
        }
    }
}