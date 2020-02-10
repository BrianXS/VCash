using API.Entities;
using API.Resources.Incoming;
using API.Resources.Outgoing;
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