using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class User : IdentityUser<int>
    {
        public string Names { get; set; }
        public string Surnames { get; set; }
        public string RefreshToken { get; set; }
    }
}