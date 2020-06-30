using System.Net.Sockets;
using API.Entities;
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

            var cityRepository = scope.ServiceProvider.GetRequiredService<ICityRepository>();
            Cities.SeedCities(cityRepository);
            
            var employeeRepository = scope.ServiceProvider.GetRequiredService<IEmployeeRepository>();
            Employees.SeedEmployees(employeeRepository);
            
            var vehicleRepository = scope.ServiceProvider.GetRequiredService<IVehicleRepository>();
            Vehicles.SeedVehicles(vehicleRepository);

            var customerRepository = scope.ServiceProvider.GetRequiredService<ICustomerRepository>();
            Customers.SeedCustomers(customerRepository);

            var cashierRepository = scope.ServiceProvider.GetRequiredService<ICashierRepository>();
            Cashiers.SeedCashiers(cashierRepository);

            var failureRepository = scope.ServiceProvider.GetRequiredService<IFailureRepository>();
            Failures.SeedFailures(failureRepository);

            var denominationTypeRepository = scope.ServiceProvider.GetRequiredService<IDenominationTypeRepository>();
            Denominations.SeedDenominations(denominationTypeRepository);

            var officesRepository = scope.ServiceProvider.GetRequiredService<IOfficeRepository>();
            Offices.SeedOffices(officesRepository);

            var drawerRangeRepository = scope.ServiceProvider.GetService<IDrawerRangeRepository>();
            Ranges.SeedRanges(drawerRangeRepository);

            /*var drawersRepository = scope.ServiceProvider.GetService<IDrawerRepository>();
            Drawers.SeedDrawers(drawersRepository);

            var batteriesRepository = scope.ServiceProvider.GetRequiredService<IATMBatteryRepostiory>();
            Batteries.SeedBatteries(batteriesRepository);

            var atmRepository = scope.ServiceProvider.GetRequiredService<IATMRepository>();
            Atm.SeedAtms(atmRepository);*/
        }
    }
}