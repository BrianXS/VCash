using API.Entities;
using API.Entities.Administrative;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;
using AutoMapper;

namespace API.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeResponse>().ForMember(to => to.Branch,
                from => from.MapFrom(src => src.Branch.Name));
            
            CreateMap<EmployeeCreateRequest, Employee>();
            CreateMap<EmployeeUpdateRequest, Employee>();
        }
    }
}