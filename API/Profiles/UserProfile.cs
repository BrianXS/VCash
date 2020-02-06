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
            CreateMap<CreateUserRequest, User>();
            
            CreateMap<UpdateUserRequest, User>()
                .ForAllMembers(members => 
                    members.Condition((src, dest, srcMember) => 
                        string.IsNullOrEmpty(srcMember.ToString())));
        }
    }
}