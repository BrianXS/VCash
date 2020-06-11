using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Repositories.Interfaces;
using API.Services.Database;
using API.Services.Seeds;
using API.Services.Seeds.Logic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            Initializer(host);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }

        private static void Initializer(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
                SeedingClass.SeedRoles(roleManager).Wait();
                
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                SeedingClass.SeedUsers(userManager).Wait();

                var countryRepository = scope.ServiceProvider.GetRequiredService<ICountryRepository>();
                CountrySeed.SeedCountries(countryRepository);
                
                var statesRepository = scope.ServiceProvider.GetRequiredService<IStateRepository>();
                StateSeed.SeedStates(statesRepository);
                
                var branchRepository = scope.ServiceProvider.GetRequiredService<IBranchRepository>();
                BranchSeed.SeedBranches(branchRepository);

                //var cityRepository = scope.ServiceProvider.GetRequiredService<ICityRepository>();
                //CitySeed.SeedCities(cityRepository);
                
                //var employeeRepository = scope.ServiceProvider.GetRequiredService<IEmployeeRepository>();
                //EmployeeSeed.SeedEmployees(employeeRepository);
                
                //var vehicleRepository = scope.ServiceProvider.GetRequiredService<IVehicleRepository>();
                //VehicleSeed.SeedVehicles(vehicleRepository);
                
                
            }
        }
    }
}