using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Services.Database
{
    public static class SeedingClass
    {
        public static async Task SeedUsers(UserManager<User> userManager)
        {
            var admin = new User {UserName = "ATIBOG0001"};
            await userManager.CreateAsync(admin, "123123");
        }
    }
}