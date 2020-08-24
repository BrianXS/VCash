using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.ServiceModel;
using System.Threading.Tasks;
using API.Entities;
using API.Services.Database;
using API.Services.Policies;
using API.Services.Soap.Services.Implementation;
using API.Services.Soap.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SoapCore;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<VcashDbContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("local-brian"));
            });

            services.AddIdentity<User, Role>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 3;
                    options.Password.RequiredUniqueChars = 0;

                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<VcashDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => { options.TokenValidationParameters = Utils.TokenUtility.TokenValidationParameters(); });

            services.AddAuthorization(options =>
            {
                foreach (var policy in Policies.GetAllPolicies())
                {
                    options.AddPolicy(policy.Value, p =>
                        p.RequireClaim(policy.Type, policy.Value));
                }
            });

            services.AddCors(policies => policies.AddDefaultPolicy(properties =>
            {
                properties.AllowAnyOrigin();
                properties.AllowAnyHeader();
                properties.AllowAnyMethod();
            }));
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddControllers();
            
            RepositoryInjection.Initialize(services);
            services.AddSingleton<ITicketService, TicketService>();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            
            app.UseRouting();
            
            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.UseSoapEndpoint<ITicketService>("/Service.asmx", 
                    new BasicHttpBinding(),
                    SoapSerializer.XmlSerializer);
            });
        }
    }
}
