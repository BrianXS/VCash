using API.Entities;
using API.Entities.Administrative;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;
using AutoMapper;

namespace API.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityResponse>()
                .ForMember(to => to.State, from => 
                    from.MapFrom(src => src.State.Name))
                .ForMember(to => to.Country, from => 
                    from.MapFrom(src => src.State.Country.Name))
                .ForMember(to => to.Branch, from => 
                    from.MapFrom(src => src.Branch.Name));
            
            CreateMap<CityCreateRequest, City>();
            CreateMap<CityUpdateRequest, City>();
        }
    }
}