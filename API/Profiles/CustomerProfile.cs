using System.Linq;
using API.Entities;
using API.Entities.Administrative;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;
using AutoMapper;

namespace API.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerResponse>()
                .ForMember(to => to.Headquarters,
                    from => from.MapFrom(src => src.Headquarters.Name))
                .ForMember(to => to.InvoicingCity,
                    from => from.MapFrom(src => src.InvoicingCity.Name))
                .ForMember(to => to.Cashiers,
                    from => from.MapFrom(src => src.Cashiers.Select(x => x.Document)))
                .ForMember(to => to.Offices,
                    from => from.MapFrom(src => src.Offices.Select(x => x.Name)));
            
            CreateMap<CustomerCreateRequest, Customer>();
            CreateMap<CustomerUpdateRequest, Customer>();
        }
    }
}