using API.Entities;
using AutoMapper;

namespace API.Profiles
{
    public class BagProfile : Profile
    {
        public BagProfile()
        {
            CreateMap<Resources.Incoming.OfficeMovementResources.CountingProcessDtos.BagDto, Bag>();
            CreateMap<Bag, Resources.Outgoing.OfficeMovementResources.CountingProcessDtos.BagDto>();
        }
    }
}