using API.Entities;
using API.Entities.Administrative;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;
using AutoMapper;

namespace API.Profiles
{
    public class FailureProfile : Profile
    {
        public FailureProfile()
        {
            CreateMap<Failure, FailureResponse>();
            CreateMap<FailureCreateRequest, Failure>();
            CreateMap<FailureUpdateRequest, Failure>();
        }
    }
}