using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using BazaAwionika.Data;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using BazaAwionika.Services;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace BazaAwionika.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {


            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

         //   services.AddDbContext<MaintenanceEntities>(options =>
          //          options.UseSqlServer(Configuration.GetConnectionString("MaintenanceEntities")));
            services.AddHttpContextAccessor();
            services.AddControllersWithViews();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbFactory, DbFactory>();

            #region Repositories
            services.AddScoped<IAircraftBiuletinRepository, AircraftBiuletinRepository>();
            services.AddScoped<IAircraftMaintenanceRepository, AircraftMaintenanceRepository>();
            services.AddScoped<IAircraftRepository, AircraftRepository>();
            services.AddScoped<IAlternatorRepository, AlternatorRepository>();
            services.AddScoped<IBatteryRepository, BatteryRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IEgpwsDatabaseRepository, EgpwsDatabaseRepository>();
            services.AddScoped<IEltFunctionalTestRepository, EltFunctionalTestRepository>();
            services.AddScoped<IEltOperationalTestRepository, EltOperationalTestRepository>();
            services.AddScoped<IEmergencyLightsBatteryRepository, EmergencyLightsBatteryRepository>();
            services.AddScoped<IFdrReadRepository, FdrReadRepository>();
            services.AddScoped<IFlightRepository, FlightRepository>();
            services.AddScoped<IGeneratorRepository, GeneratorRepository>();
            services.AddScoped<IGipsenDatabaseRepository, GipsenDatabaseRepository>();
            services.AddScoped<IGpsBatteriesRepository, GpsBatteriesRepository>();
            services.AddScoped<IGpsPCodesRepository, GpsPCodesRepository>();
            services.AddScoped<IOxygenCylinderMainRepository, OxygenCylinderMainRepository>();
            services.AddScoped<IOxygenCylinderPortableRepository, OxygenCylinderPortableRepository>();
            services.AddScoped<IOxygenExchangeRepository, OxygenExchangeRepository>();
            services.AddScoped<IPbeRepository, PbeRepository>();
            services.AddScoped<ISettingsRepository, SettingsRepository>();
            services.AddScoped<ITestDcfRepository, TestDcfRepository>();
            services.AddScoped<ITestEfisRepository, TestEfisRepository>();
            services.AddScoped<ITestTruRepository, TestTruRepository>();
            services.AddScoped<IUlbCvrRepository, UlbCvrRepository>();
            services.AddScoped<IUlbFdrRepository, UlbFdrRepository>();
            services.AddScoped<IUlbTestRepository, UlbTestRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            #endregion

            #region services

                services.AddScoped<IAircraftBiuletinService, AircraftBiuletinService>();
                services.AddScoped<IAircraftMaintenanceService, AircraftMaintenanceService>();
                services.AddScoped<IAircraftService, AircraftService>();
                services.AddScoped<IAlternatorService, AlternatorService>();
                services.AddScoped<IBatteryService, BatteryService>();
                services.AddScoped<ICountryService, CountryService>();
                services.AddScoped<IEgpwsDatabaseService, EgpwsDatabaseService>();
                services.AddScoped<IEltFunctionalTestService, EltFunctionalTestService>();
                services.AddScoped<IEltOperationalTestService, EltOperationalTestService>();
                services.AddScoped<IEmergencyLightsBatteryService, EmergencyLightsBatteryService>();
                services.AddScoped<IFdrReadService, FdrReadService>();
                services.AddScoped<IFlightService, FlightService>();
                services.AddScoped<IGeneratorService, GeneratorService>();
                services.AddScoped<IGipsenDatabaseService, GipsenDatabaseService>();
                services.AddScoped<IGpsBatteriesService, GpsBatteriesService>();
                services.AddScoped<IGpsPCodesService, GpsPCodesService>();
                services.AddScoped<IOxygenCylinderMainService, OxygenCylinderMainService>();
                services.AddScoped<IOxygenCylinderPortableService, OxygenCylinderPortableService>();
                services.AddScoped<IOxygenExchangeService, OxygenExchangeService>();
                services.AddScoped<IPbeService, PbeService>();
                services.AddScoped<ISettingsService, SettingsService>();
                services.AddScoped<ITestDcfService, TestDcfService>();
                services.AddScoped<ITestEfisService, TestEfisService>();
                services.AddScoped<ITestTruService, TestTruService>();
                services.AddScoped<IUlbCvrService, UlbCvrService>();
                services.AddScoped<IUlbFdrService, UlbFdrService>();
                services.AddScoped<IUlbTestService, UlbTestService>();
                services.AddScoped<IUserService, UserService>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }
}
