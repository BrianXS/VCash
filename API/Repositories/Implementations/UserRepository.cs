using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Entities;
using API.Entities.Administrative;
using API.Repositories.Interfaces;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace API.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserRepository(UserManager<User> userManager, 
                              IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        
        public Task<User> FindUserByUserName(string userName)
        {
            return _userManager.FindByNameAsync(userName);
        }

        public async Task<UserResponse> FindUserResponseById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return _mapper.Map<UserResponse>(user);
        }

        public async Task<User> FindUserById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<IdentityResult> CreateUser(UserCreateRequest request)
        {
            return await _userManager.CreateAsync(_mapper.Map<User>(request), request.PlainPassword);
        }

        public async Task<IdentityResult> DeleteUser(User user)
        {
            var result = await _userManager.DeleteAsync(user);
            return result;
        }

        public async Task<List<string>> GetAllUserRoles(User user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }

        public async Task<List<Claim>> GetUserClaims(User user)
        {
            var result = await _userManager.GetClaimsAsync(user);
            return result.ToList();
        }

        public async Task<IdentityResult> Update(User user)
        {
           return await _userManager.UpdateAsync(user);
        }

        public List<UserResponse> FindAll()
        {
            return _mapper.Map<List<UserResponse>>(_userManager.Users.ToList());
        }
    }
}