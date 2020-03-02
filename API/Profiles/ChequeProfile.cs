using API.Entities;
using AutoMapper;

namespace API.Profiles
{
    public class ChequeProfile : Profile
    {
        public ChequeProfile()
        {
            CreateMap<Resources.Incoming.OfficeMovementResources.CountingProcessDtos.ChequeDto, Cheque>();
            CreateMap<Cheque, Resources.Outgoing.OfficeMovementResources.CountingProcessDtos.ChequeDto>();
        }
    }
}