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
            services.AddScoped<IATMRepository, ATMRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<IDrawerRepository, DrawerRepository>();
            services.AddScoped<IOfficeRepository, OfficeRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IFailureRepository, FailureRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<ICashierRepository, CashierRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IATMBatteryRepostiory, ATMBatteryRepository>();
            services.AddScoped<IDrawerRangeRepository, DrawerRangeRepository>();
            services.AddScoped<IBusinessTypeRepository, BusinessTypeRepository>();
            services.AddScoped<ICustomerFundRepository, CustomerFundRepository>();
            services.AddScoped<IOfficeCheckInRepository, OfficeCheckInRepository>();
            services.AddScoped<ITicketDieboldRepository, TicketDieboldRepository>();
            services.AddScoped<INotificationTypeRepository, NotificationTypeRepository>();
            services.AddScoped<IDenominationTypeRepository, DenominationTypeRepository>();
        }
    }
}
