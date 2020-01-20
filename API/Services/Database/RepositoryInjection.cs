using API.Repositories.Implementations;
using API.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace API.Services.Database
{
    public static class RepositoryInjection
    {
        public static void Initialize(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}