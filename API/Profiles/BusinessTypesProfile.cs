using API.Entities;
using API.Resources.Incoming;
using API.Resources.Outgoing;
using AutoMapper;

namespace API.Profiles
{
    public class BusinessTypesProfile : Profile
    {
        public BusinessTypesProfile()
        {
            CreateMap<BusinessType, BusinessTypeResponse>();
            CreateMap<BusinessTypeCreateRequest, BusinessType>();
            CreateMap<BusinessTypeUpdateRequest, BusinessType>();
        }
    }
}
