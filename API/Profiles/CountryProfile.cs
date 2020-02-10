using System.Linq;
using API.Entities;
using API.Resources.Outgoing;
using AutoMapper;

namespace API.Profiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryResponse>()
                .ForMember(dest => dest.States, 
                    member => member.MapFrom(src 
                        => src.States.Select(s => s.Name)));
        }
    }
}