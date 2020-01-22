using System.Security.Claims;

namespace API.Utils.Claims
{
    public static class CashCenter
    {
        public static Claim Access = new Claim(ClaimTypes.Role, "CashCenter Access");
        public static Claim Create = new Claim(ClaimTypes.Role, "CashCenter Create");
        public static Claim View = new Claim(ClaimTypes.Role, "CashCenter View");
        public static Claim Edit = new Claim(ClaimTypes.Role, "CashCenter Edit");
        public static Claim Disable = new Claim(ClaimTypes.Role, "CashCenter Disable");
    }
}