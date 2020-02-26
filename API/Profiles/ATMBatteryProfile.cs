using System.Linq;
using API.Entities;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;
using AutoMapper;

namespace API.Profiles
{
    public class ATMBatteryProfile : Profile
    {
        public ATMBatteryProfile()
        {
            CreateMap<ATMBattery, ATMBatteryResponse>().ForMember(to => to.Atms,
                from => from.MapFrom(x =>  x.Atms.Select(atm => atm.Office.Name).ToList()));
            
            CreateMap<ATMBatteryCreateRequest, ATMBattery>();
            CreateMap<ATMBatteryUpdateRequest, ATMBattery>();
        }
    }
}