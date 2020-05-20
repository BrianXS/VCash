using API.Entities;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing.AdministrativeResources;
using AutoMapper;

namespace API.Profiles
{
    public class DrawerProfile : Profile
    {
        public DrawerProfile()
        {
            CreateMap<Drawer, DrawerResponse>()
                .ForMember(to => to.DrawerRange, from => 
                    from.MapFrom(src => src.DrawerRange.Code))
                .ForMember(to => to.DenominationType, from => 
                    from.MapFrom(src => src.DenominationType.Code));

            CreateMap<DrawerRequest, Drawer>();
        }
    }
}