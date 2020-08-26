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
    public class StateProfile : Profile
    {
        public StateProfile()
        {
            CreateMap<State, StateResponse>()
                .ForMember(to => to.Country, from => 
                    from.MapFrom(src => src.Country.Name))
                .ForMember(to => to.Cities, from => 
                    from.MapFrom(src => src.Cities.Select(x => x.Name).ToList()));

            CreateMap<StateCreateRequest, State>();
            CreateMap<StateUpdateRequest, State>();
        }
    }
}