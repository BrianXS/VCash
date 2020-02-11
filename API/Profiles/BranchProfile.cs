using API.Entities;
using API.Resources.Incoming;
using API.Resources.Outgoing;
using AutoMapper;

namespace API.Profiles
{
    public class BranchProfile : Profile
    {
        public BranchProfile()
        {
            CreateMap<Branch, BranchResponse>();
            CreateMap<BranchCreateRequest, Branch>();
            CreateMap<BranchUpdateRequest, Branch>();
        }
    }
}