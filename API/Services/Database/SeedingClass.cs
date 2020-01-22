using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Services.Database
{
    public static class SeedingClass
    {
        public static async Task SeedUsers(UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var admin = new User {UserName = "ATIBOG0001", Email = "test@gmail.com"};
                await userManager.CreateAsync(admin, "123123");
            }
        }

        public static async Task SeedRoles(RoleManager<Role> roleManager)
        {
            if(roleManager.Roles.Any())
                return;
            
            var roles = new List<Role>
            {
                new Role { Name = Constants.Roles.CashCenterManager },
                new Role { Name = Constants.Roles.MachineryManager },
                new Role { Name = Constants.Roles.LogisticsManager },
                new Role { Name = Constants.Roles.InvoicingManager },
                new Role { Name = Constants.Roles.Employee }
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }
        }
    }
}