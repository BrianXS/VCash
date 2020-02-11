using API.Entities;
using API.Resources.Incoming;
using API.Resources.Outgoing;
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