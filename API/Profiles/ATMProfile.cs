using API.Entities;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;
using AutoMapper;

namespace API.Profiles
{
    public class ATMProfile : Profile
    {
        public ATMProfile()
        {
            CreateMap<ATM, ATMResponse>()
                .ForMember(to => to.AtmBattery, from => 
                    from.MapFrom(src => src.AtmBattery.Code))
                .ForMember(to => to.Office, from => 
                    from.MapFrom(src => src.Office.Name))
                .ForMember(to => to.DrawerRange, from => 
                    from.MapFrom(src => src.DrawerRange.Code));
            
            CreateMap<ATMCreateRequest, ATM>();
            CreateMap<ATMUpdateRequest, ATM>();
        }
    }
}