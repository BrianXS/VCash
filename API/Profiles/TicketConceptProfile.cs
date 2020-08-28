using API.Entities.AtmMaintenance;
using API.Resources.Incoming.AtmMaintenanceResources;
using AutoMapper;

namespace API.Profiles
{
    public class TicketConceptProfile : Profile
    {
        public TicketConceptProfile()
        {
            CreateMap<TicketConceptRequest, TicketConcept>();
            CreateMap<TicketConcept, TicketConceptRequest>();
        }
    }
}