using System.Security.Claims;

namespace API.Utils.Claims
{
    public static class Logistics
    {
        public static Claim Access = new Claim(ClaimTypes.Role, "Logistics Access");
        public static Claim Create = new Claim(ClaimTypes.Role, "Logistics Create");
        public static Claim View = new Claim(ClaimTypes.Role, "Logistics View");
        public static Claim Edit = new Claim(ClaimTypes.Role, "Logistics Edit");
        public static Claim Disable = new Claim(ClaimTypes.Role, "Logistics Disable");
    }
}