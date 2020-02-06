using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Entities;
using API.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace API.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;

        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        
        public Task<User> FindUserByUserName(string userName)
        {
            return _userManager.FindByNameAsync(userName);
        }

        public async Task<List<Claim>> GetUserClaims(User user)
        {
            var result = await _userManager.GetClaimsAsync(user);
            return result.ToList();
        }

        public async Task Update(User user)
        {
            await _userManager.UpdateAsync(user);
        }

        public List<User> FindAll()
        {
            return _userManager.Users.ToList();
        }
    }
}