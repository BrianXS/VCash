using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Entities;

namespace API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> FindUserByUserName(string userName);
        Task<List<Claim>> GetUserClaims(User user);
        Task Update(User user);
    }
}