using System.Linq;
using API.Entities;
using API.Resources.Incoming;
using API.Resources.Outgoing;
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