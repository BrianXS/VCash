using API.Entities.AtmMaintenance;
using API.Resources.Incoming.AtmMaintenanceResources;
using API.Resources.Outgoing.AtmMaintenanceResources;
using AutoMapper;

namespace API.Profiles
{
    public class TicketStatusProfile : Profile
    {
        public TicketStatusProfile()
        {
            CreateMap<TicketStatusRequest, TicketStatus>();
            CreateMap<TicketStatus, TicketStatusResponse>();
        }
    }
}