using API.Entities;
using API.Resources.Outgoing;
using AutoMapper;

namespace API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserResource>();
        }
    }
}