using API.Repositories.Interfaces;
using API.Services.Seeds.Logic;
using Microsoft.Extensions.DependencyInjection;

namespace API.Services.Seeds
{
    public static class Seed
    {
        public static void Data(IServiceScope scope)
        {
            var countryRepository = scope.ServiceProvider.GetRequiredService<ICountryRepository>();
            Countries.SeedCountries(countryRepository);
                
            var statesRepository = scope.ServiceProvider.GetRequiredService<IStateRepository>();
            States.SeedStates(statesRepository);
                
            var branchRepository = scope.ServiceProvider.GetRequiredService<IBranchRepository>();
            Branches.SeedBranches(branchRepository);

            /*var cityRepository = scope.ServiceProvider.GetRequiredService<ICityRepository>();
            Cities.SeedCities(cityRepository);
                
            var employeeRepository = scope.ServiceProvider.GetRequiredService<IEmployeeRepository>();
            Employees.SeedEmployees(employeeRepository);
                
            var vehicleRepository = scope.ServiceProvider.GetRequiredService<IVehicleRepository>();
            Vehicles.SeedVehicles(vehicleRepository);*/
        }
    }
}