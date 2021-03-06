using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Entities.Administrative
{
    public class User : IdentityUser<int>
    {
        public string Names { get; set; }
        public string Surnames { get; set; }
        public string RefreshToken { get; set; }

        public List<UserBranch> UserBranches { get; set; }
    }
}