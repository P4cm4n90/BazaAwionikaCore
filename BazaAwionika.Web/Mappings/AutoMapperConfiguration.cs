using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BazaAwionika.Web
{
    public static class AutoMapperConfiguration
    {
        public static IMapper Mapper { get; private set; }
        public static MapperConfiguration MapperConfiguration { get; private set; }

        public static void Init()
        {
            Configuration();
            Mapper = MapperConfiguration.CreateMapper();
          //  Mapper.ConfigurationProvider.AssertConfigurationIsValid();
           
        }

        private static void Configuration()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BatteryMappingProfile>();
                cfg.AddProfile<GeneratorMappingProfile>();
                cfg.AddProfile<AlternatorMappingProfile>();
                cfg.AddProfile<AircraftMappingProfile>();
                cfg.AddProfile<EgpwsDatabaseMappingProfile>();
                cfg.AddProfile<EltFunctionalTestMappingProfile>();
                cfg.AddProfile<EltOperationalTestMappingProfile>();
                cfg.AddProfile<EmergencyLightsBatteryMappingProfile>();
                cfg.AddProfile<FdrReadMappingProfile>();
                cfg.AddProfile<GipsenDatabaseMappingProfile>();
                cfg.AddProfile<GpsBatteriesMappingProfile>();
                cfg.AddProfile<GpsPCodesMappingProfile>();
                cfg.AddProfile<MagneticCompassDeviationMappingProfile>();
                cfg.AddProfile<OxygenCylinderMainMappingProfile>();
                cfg.AddProfile<OxygenCylinderPortableMappingProfile>();
                cfg.AddProfile<OxygenExchangeMappingProfile>();
                cfg.AddProfile<PbeMappingProfile>();
                cfg.AddProfile<SettingsMappingProfile>();
                cfg.AddProfile<TestDcfMappingProfile>();
                cfg.AddProfile<TestEfisMappingProfile>();
                cfg.AddProfile<TestTruMappingProfile>();
                cfg.AddProfile<UlbCvrMappingProfile>();
                cfg.AddProfile<UlbFdrMappingProfile>();
                cfg.AddProfile<UlbTestMappingProfile>();
                cfg.AddProfile<UserMappingProfile>();
                cfg.AddProfile<AircraftMaintenanceMappingProfile>();
                cfg.AddProfile<AircraftStatusMappingProfile>();
                cfg.AddProfile<AircraftBiuletinMappingProfile>();
             //   cfg.AddProfile<TestEfisDcfTruMappingProfile>();


            });
        }
    }
}