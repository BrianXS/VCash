using API.Entities.AtmMaintenance;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Incoming.AtmMaintenanceResources;
using AutoMapper;

namespace API.Profiles
{
    public class AtmModuleProfile : Profile
    {
        public AtmModuleProfile()
        {
            CreateMap<AtmModuleRequest, AtmModule>();
            CreateMap<AtmModule, AtmModuleRequest>();
        }
    }
}