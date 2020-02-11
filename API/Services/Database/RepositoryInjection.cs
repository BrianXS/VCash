using API.Repositories.Implementations;
using API.Repositories.Interfaces;
using API.Resources.Incoming;
using Microsoft.Extensions.DependencyInjection;

namespace API.Services.Database
{
    public static class RepositoryInjection
    {
        public static void Initialize(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }
    }
}