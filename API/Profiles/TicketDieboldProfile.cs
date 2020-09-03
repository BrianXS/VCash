using API.Entities.AtmMaintenance;
using API.Services.Soap.Resources.Outgoing;
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
                .ForMember(to => to.AppointmentDate, from => from.MapFrom(src => src._appoinmentDateTime))
                .ForMember(to => to.TicketNumberGenerated, from =>
                    from.MapFrom(src =>
                        int.Parse(src.TicketNumberGenerated.Length == 0 ? "0" : src.TicketNumberGenerated)))
                .ForMember(to => to.Status, from => from.Ignore())
                .ForMember(to => to.Concept, from => from.Ignore())
                .ForMember(to => to.FailingModule, from => from.Ignore());

            CreateMap<TicketDiebold, CreateOutgoingTicket>();

            CreateMap<TicketDiebold, Ticket>()
                .ForMember(to => to.DateTimeATT,
                    from => from.MapFrom(src => src.AppointmentDate.ToString("yyy-MM-dd hh:ss")))
                .ForMember(to => to.Status, from => from.MapFrom(src => src.Status.Code))
                .ForMember(to => to.CodeStatus, from => from.MapFrom(src => src.Status.Description))
                .ForMember(to => to.ModuleCode, from => from.MapFrom(src => src.FailingModule.Description));
        }
    }
}