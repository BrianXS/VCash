using API.Entities;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing.AdministrativeResources;
using AutoMapper;

namespace API.Profiles
{
    public class DrawerRangeProfile : Profile
    {
        public DrawerRangeProfile()
        {
            CreateMap<DrawerRange, DrawerRangeResponse>().ForMember(to => to.Customer,
                from => from.MapFrom(src => src.Customer.Name));
            CreateMap<DrawerRangeRequest, DrawerRange>();
        }
    }
}