using System.Collections.Generic;
using System.Security.Claims;

namespace API.Services.Policies
{
    public static class Policies
    {
        public static List<Claim> GetAllPolicies()
        {
            var policies = new List<Claim>
            {
                new Claim(ClaimTypes.Role, Constants.Roles.Administrator),
                new Claim(ClaimTypes.Role, Constants.Roles.CashCenterManager),
                new Claim(ClaimTypes.Role, Constants.Roles.LogisticsManager),
                new Claim(ClaimTypes.Role, Constants.Roles.MachineryManager),
                new Claim(ClaimTypes.Role, Constants.Roles.InvoicingManager),
                new Claim(ClaimTypes.Role, Constants.Roles.Employee)
            };

            return policies;
        }
    }
}