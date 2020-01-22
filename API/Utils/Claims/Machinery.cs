using System.Security.Claims;

namespace API.Utils.Claims
{
    public static class Machinery
    {
        public static Claim Access = new Claim(ClaimTypes.Role, "Machinery Access");
        public static Claim Create = new Claim(ClaimTypes.Role, "Machinery Create");
        public static Claim View = new Claim(ClaimTypes.Role, "Machinery View");
        public static Claim Edit = new Claim(ClaimTypes.Role, "Machinery Edit");
        public static Claim Disable = new Claim(ClaimTypes.Role, "Machinery Disable");
    }
}