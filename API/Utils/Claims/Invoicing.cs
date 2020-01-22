using System.Security.Claims;

namespace API.Utils.Claims
{
    public static class Invoicing
    {
        public static Claim Access = new Claim(ClaimTypes.Role, "Invoicing Access");
        public static Claim Create = new Claim(ClaimTypes.Role, "Invoicing Create");
        public static Claim View = new Claim(ClaimTypes.Role, "Invoicing View");
        public static Claim Edit = new Claim(ClaimTypes.Role, "Invoicing Edit");
        public static Claim Disable = new Claim(ClaimTypes.Role, "Invoicing Disable");
    }
}