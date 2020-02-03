using API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Database
{
    public class VcashDbContext : IdentityDbContext<User, Role, int>
    {
        public VcashDbContext(DbContextOptions options) : base(options) { }

        
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<CustomerFund> OfficesAndFunds { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<ATM> ATMs { get; set; }
        public DbSet<AtmBattery> AtmBatteries { get; set; }
        public DbSet<BusinessType> BusinessTypes { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cashier> Cashiers { get; set; }
        
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        
        public DbSet<Failure> Failures { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<CustomerFund>()
                .HasKey(entity => new { entity.CustomerId, entity.OfficeId });

            builder.Entity<CustomerFund>()
                .HasOne(internalEntity => internalEntity.Customer)
                .WithMany(externalEntity => externalEntity.CustomerFunds);
            
            builder.Entity<CustomerFund>()
                .HasOne(internalEntity => internalEntity.Office)
                .WithMany(externalEntity => externalEntity.CustomerFunds);
        }
    }
}