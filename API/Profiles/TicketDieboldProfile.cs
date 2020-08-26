using API.Entities.AtmMaintenance;
using CreateIncomingTicket = API.Services.Soap.Resources.Incoming.CreateTicket;
using CreateOutgoingTicket = API.Services.Soap.Resources.Outgoing.CreateTicket;
using AutoMapper;

namespace API.Profiles
{
    public class TicketDieboldProfile : Profile
    {
        public TicketDieboldProfile()
        {
            CreateMap<CreateIncomingTicket, TicketDiebold>()
                .ForMember(to => to.View, from => from.MapFrom(src => src.IdVisita))
                .ForMember(to => to.Priority, from => from.MapFrom(src => src.IdPrioridad))
                .ForMember(to => to.IsAppointment, from => from.MapFrom(src => src._appointment))
                .ForMember(to => to.AppointmentDate, from => from.MapFrom(src => src._appoinmentDateTime));
                //.ForMember(to => to.Concept, from => from.Ignore());

            CreateMap<TicketDiebold, CreateOutgoingTicket>();
        }
    }
}