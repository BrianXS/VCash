using API.Entities;
using API.Resources.Incoming;
using API.Resources.Outgoing;
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