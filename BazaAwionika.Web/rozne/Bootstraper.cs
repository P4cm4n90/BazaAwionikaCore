using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using BazaAwionika.Data;
using BazaAwionika.Services;
using BazaAwionika.Model;
using BazaAwionika.Data.Infrastructure;
using BazaAwionika.Data.Repositories;
using System.Web.Mvc;

namespace BazaAwionika.Web
{
    public class Bootstraper
    {
        public static void Run()
        {
            SetAutoFacContainer();
        }

        private static void SetAutoFacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            #region Repositories
            builder.RegisterAssemblyTypes(typeof(AircraftBiuletinRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            /*
            builder.RegisterAssemblyTypes(typeof(AircraftLocationRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(AircraftMaintenanceRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(AircraftStatusRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(AircraftRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(AlternatorRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(BatteryRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(CountryRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(EgpwsDatabaseRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(EltFunctionalTestRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(EltOperationalTestRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(EmergencyLightsBatteryRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(FdrReadRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(FlightRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(GeneratorRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(GipsenDatabaseRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(GpsBatteriesRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(GpsPCodesRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(MagneticCompassDeviationRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(OxygenCylinderMainRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(OxygenCylinderPortableRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(OxygenExchangeRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(PbeRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(SettingsRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(TestDcfRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(TestEfisRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(TestTruRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(UlbCvrRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(UlbFdrRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(UlbTestRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();*/




            #endregion

            #region services

            builder.RegisterAssemblyTypes(typeof(AircraftBiuletinService).Assembly)
                            .Where(t => t.Name.EndsWith("Service"))
                            .AsImplementedInterfaces().InstancePerRequest();

     /*       builder.RegisterAssemblyTypes(typeof(AircraftLocationService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(AircraftMaintenanceService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(AircraftStatusService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(AircraftService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(AlternatorService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(BatteryService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(CountryService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(EgpwsDatabaseService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(EltFunctionalTestService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(EltOperationalTestService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(EmergencyLightsBatteryService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(FdrReadService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(FlightService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(GeneratorService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(GipsenDatabaseService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(GpsBatteriesService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(GpsPCodesService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(MagneticCompassDeviationService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(OxygenCylinderMainService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(OxygenCylinderPortableService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(OxygenExchangeService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(PbeService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(SettingsService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(TestDcfService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(TestEfisService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(TestTruService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(UlbCvrService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(UlbFdrService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(UlbTestService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(UserService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();*/
            #endregion

            builder.RegisterFilterProvider();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}

/*//
 * 
 * public static void Run()
        {
            SetAutofacContainer();
        }
 
        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
 
            // Repositories
            builder.RegisterAssemblyTypes(typeof(GadgetRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            // Services
            builder.RegisterAssemblyTypes(typeof(GadgetService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();
 
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
 * 
 */
