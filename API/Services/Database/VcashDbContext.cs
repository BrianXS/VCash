using System;
using System.Linq;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Services.Database
{
    public class VcashDbContext : IdentityDbContext<User, Role, int>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public VcashDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public DbSet<Branch> Branches { get; set; }

        public DbSet<UserBranch> UserBranches { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<CustomerFund> OfficesAndFunds { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<ATM> ATMs { get; set; }
        public DbSet<ATMBattery> AtmBatteries { get; set; }
        public DbSet<BusinessType> BusinessTypes { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cashier> Cashiers { get; set; }
        
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        
        public DbSet<Failure> Failures { get; set; }


        public DbSet<OfficeMovement> OfficeMovements { get; set; }
        public DbSet<Cheque> Cheques { get; set; }

        public DbSet<Bag> Bags { get; set; }
        public DbSet<BagDenomination> BagDenominations { get; set; }
        public DbSet<BagNotification> BagNotifications { get; set; }

        public DbSet<Envelope> Envelopes { get; set; }
        public DbSet<EnvelopeDenomination> EnvelopeDenominations { get; set; }
        public DbSet<EnvelopeNotification> EnvelopeNotifications { get; set; }
        
        

        public DbSet<DrawerRange> DrawerRanges { get; set; }
        public DbSet<Drawer> Drawers { get; set; }
        
        public DbSet<DenominationType> DenominationTypes { get; set; }
        public DbSet<NotificationType> NotificationTypes { get; set; }
        
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
            
            
            builder.Entity<UserBranch>()
                .HasKey(entity => new { entity.UserId, entity.BranchId });

            builder.Entity<UserBranch>()
                .HasOne(internalEntity => internalEntity.User)
                .WithMany(externalEntity => externalEntity.UserBranches);
            
            builder.Entity<UserBranch>()
                .HasOne(internalEntity => internalEntity.Branch)
                .WithMany(externalEntity => externalEntity.UserBranches);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            
            var modified = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added 
                            || x.State == EntityState.Modified 
                            || x.State == EntityState.Deleted);
            
            var updatingUser = _httpContextAccessor.HttpContext == null ? 
                "SYSTEM" : _httpContextAccessor.HttpContext.User.Identity.Name;

            foreach (var item in modified)
            {
                if (item.Entity is IAuditable entity)
                {
                    item.CurrentValues[nameof(IAuditable.UpdatedBy)] = updatingUser;
                    item.CurrentValues[nameof(IAuditable.UpdatedOn)] = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}