using API.Entities;
using API.Resources.Incoming.OfficeMovementResources;
using API.Resources.Outgoing.OfficeMovementResources;
using AutoMapper;

namespace API.Profiles
{
    public class OfficeCheckInRepository : Profile
    {
        public OfficeCheckInRepository()
        {
            CreateMap<OfficeMovement, OfficeCheckInResponse>();
            CreateMap<OfficeCheckInRequest, OfficeMovement>();
        }
    }
}