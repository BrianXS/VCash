using API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Database
{
    public class VcashDbContext : IdentityDbContext<User, Role, int>
    {
        public VcashDbContext(DbContextOptions options) : base(options) { }
    }
}