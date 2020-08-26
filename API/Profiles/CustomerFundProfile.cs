using API.Entities;
using API.Entities.Administrative;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;
using AutoMapper;

namespace API.Profiles
{
    public class CustomerFundProfile : Profile
    {
        public CustomerFundProfile()
        {
            CreateMap<CustomerFund, CustomerFundResponse>()
                .ForMember(to => to.Customer,
                from => from.MapFrom(x => x.Customer.Name))
                .ForMember(to => to.Office,
                    from => from.MapFrom(x => x.Office.Name));
            
            CreateMap<CustomerFundCreateRequest, CustomerFund>();
            CreateMap<CustomerFundUpdateRequest, CustomerFund>();
        }
    }
}