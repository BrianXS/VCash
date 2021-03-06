using API.Entities;
using API.Entities.Administrative;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;
using AutoMapper;

namespace API.Profiles
{
    public class OfficeProfile : Profile
    {
        public OfficeProfile()
        {
            CreateMap<Office, OfficeResponse>().ForMember(to => to.Customer,
                from => 
                    from.MapFrom(src => src.Customer.Name))
                .ForMember(to => to.City,
                    from => 
                        from.MapFrom(src => src.City.Name));
            
            CreateMap<OfficeCreateRequest, Office>();
            CreateMap<OfficeUpdateRequest, Office>();
        }
    }
}