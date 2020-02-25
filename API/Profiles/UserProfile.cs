using API.Entities;
using API.Resources.Incoming;
using API.Resources.Outgoing;
using AutoMapper;

namespace API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserResponse>();
            
            CreateMap<UserCreateRequest, User>();
            CreateMap<UserUpdateRequest, User>();
        }
    }
}