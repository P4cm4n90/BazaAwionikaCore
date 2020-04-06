using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BazaAwionika.Model;
using BazaAwionika.Web.ViewModel;

namespace BazaAwionika.Web
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        public DomainToViewModelMappingProfile()
        {
            CreateMap<AircraftModel, AircraftViewModel>();
         ///   CreateMap<AircraftModel, AircraftExtendedViewModel>(); //TODO: sprawdzic coto
            CreateMap<AircraftStatusModel, AircraftStatusViewModel>();
            CreateMap<AircraftMaintenanceModel, AircraftMaintenanceViewModel>();
            CreateMap<AircraftBiuletinModel, AircraftBiuletinViewModel>();
            CreateMap<AlternatorModel, AlternatorViewModel>();
            CreateMap<BatteryModel, BatteryViewModel>();
            CreateMap<CountryModel, CountryViewModel>();
            CreateMap<EgpwsDatabaseModel, EgpwsDatabaseViewModel>();
            CreateMap<EltFunctionalTestModel, EltFunctionalTestViewModel>();
            CreateMap<EltOperationalTestModel, EltOperationalTestViewModel>();
            CreateMap<EmergencyLightsBatteryModel, EmergencyLightsBatteryViewModel>();
            CreateMap<FdrReadModel, FdrReadViewModel>();
            CreateMap<FlightModel, FlightViewModel>();
            CreateMap<GeneratorModel, GeneratorViewModel>();
            CreateMap<GipsenDatabaseModel, GipsenDatabaseViewModel>();
            CreateMap<GpsBatteriesModel, GpsBatteriesViewModel>();
            CreateMap<GpsPCodesModel, GpsPCodesViewModel>();
            CreateMap<MagneticCompassDeviationModel, MagneticCompassDeviationViewModel>();
            CreateMap<OxygenCylinderMainModel, OxygenCylinderMainViewModel>();
            CreateMap<OxygenCylinderPortableModel, OxygenCylinderPortableViewModel>();
            CreateMap<OxygenExchangeModel, OxygenExchangeViewModel>();
            CreateMap<PbeModel, PbeViewModel>();
            CreateMap<SettingsModel, SettingsViewModel>();
            CreateMap<TestDcfModel, TestDcfViewModel>();
            CreateMap<TestTruModel, TestTruViewModel>();
            CreateMap<TestEfisModel, TestEfisViewModel>();
            CreateMap<UlbCvrModel, UlbCvrViewModel>();
            CreateMap<UlbFdrModel, UlbFdrViewModel>();
            CreateMap<UlbTestModel, UlbTestViewModel>();
            CreateMap<UserModel, UserViewModel>();
        }
    }
}