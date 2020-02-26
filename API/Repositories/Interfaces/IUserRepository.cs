using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Entities;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;
using Microsoft.AspNetCore.Identity;

namespace API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> FindUserByUserName(string userName);
        Task<UserResponse> FindUserResponseById(string id);
        Task<User> FindUserById(string id);
        Task<IdentityResult> CreateUser(UserCreateRequest request);
        Task<IdentityResult> DeleteUser(User user);
        Task<List<string>> GetAllUserRoles(User user);
        Task<List<Claim>> GetUserClaims(User user);
        Task<IdentityResult> Update(User user);
        List<UserResponse> FindAll();

    }
}