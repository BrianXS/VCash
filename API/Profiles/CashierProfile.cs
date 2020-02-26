using API.Entities;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;
using AutoMapper;

namespace API.Profiles
{
    public class CashierProfile : Profile
    {
        public CashierProfile()
        {
            CreateMap<Cashier, CashierResponse>().ForMember(to => to.Customer,
                from => from.MapFrom(src => src.Customer.Name));
            
            CreateMap<CashierCreateRequest, Cashier>();
            CreateMap<CashierUpdateRequest, Cashier>();
        }
    }
}