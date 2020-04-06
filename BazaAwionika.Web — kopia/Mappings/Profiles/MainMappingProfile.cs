using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Model;

namespace BazaAwionika.Web
{
    public class MainMappingProfile : Profile
    {


        public MainMappingProfile()
        {
     
                    CreateMap<AircraftStatusViewModel, AircraftStatusModel>().ReverseMap();
                    CreateMap<AircraftMaintenanceViewModel, AircraftMaintenanceModel>().ReverseMap();
                    CreateMap<AircraftBiuletinViewModel, AircraftBiuletinModel>().ReverseMap();
                    CreateMap<CountryViewModel, CountryModel>().ReverseMap();
                    CreateMap<EgpwsDatabaseViewModel, EgpwsDatabaseModel>().ForPath(a => a.Users.Name, map => map.MapFrom(vm => vm.UserName)).ReverseMap();
                    CreateMap<EltFunctionalTestViewModel, EltFunctionalTestModel>().ForPath(a => a.Users.Name, map => map.MapFrom(vm => vm.UserName)).ReverseMap();
                    CreateMap<EltOperationalTestViewModel, EltOperationalTestModel>().ForPath(a => a.Users.Name, map => map.MapFrom(vm => vm.UserName)).ReverseMap();
                    CreateMap<FdrReadViewModel, FdrReadModel>().ForPath(a => a.Users.Name, map => map.MapFrom(vm => vm.UserName)).ReverseMap();
                    CreateMap<FlightViewModel, FlightModel>().ReverseMap();
      
                    CreateMap<GipsenDatabaseViewModel, GipsenDatabaseModel>().ForPath(a => a.Users.Name, map => map.MapFrom(vm => vm.UserName)).ReverseMap();
                    CreateMap<GpsBatteriesViewModel, GpsBatteriesModel>().ForPath(a => a.Users.Name, map => map.MapFrom(vm => vm.UserName)).ReverseMap();
                    CreateMap<GpsPCodesViewModel, GpsPCodesModel>().ForPath(a => a.Users.Name, map => map.MapFrom(vm => vm.UserName)).ReverseMap();
                    CreateMap<MagneticCompassDeviationViewModel, MagneticCompassDeviationModel>().ForPath(a => a.Users.Name, map => map.MapFrom(vm => vm.UserName)).ReverseMap();
                    CreateMap<OxygenCylinderMainViewModel, OxygenCylinderMainModel>().ForPath(a => a.Users.Name, map => map.MapFrom(vm => vm.UserName)).ReverseMap();
                    CreateMap<OxygenCylinderPortableViewModel, OxygenCylinderPortableModel>().ForPath(a => a.Users.Name, map => map.MapFrom(vm => vm.UserName)).ReverseMap();
                    CreateMap<OxygenExchangeViewModel, OxygenExchangeModel>().ForPath(a => a.Users.Name, map => map.MapFrom(vm => vm.UserName)).ReverseMap();

                    CreateMap<PbeViewModel, PbeModel>().ForPath(a => a.Users.Name, map => map.MapFrom(vm => vm.UserName)).ReverseMap();
                    CreateMap<SettingsViewModel, SettingsModel>().ReverseMap();
                    CreateMap<TestDcfViewModel, TestDcfModel>().ForPath(a => a.Users.Name, map => map.MapFrom(vm => vm.UserName)).ReverseMap();
                    CreateMap<TestTruViewModel, TestTruModel>().ForPath(a => a.Users.Name, map => map.MapFrom(vm => vm.UserName)).ReverseMap();
                    CreateMap<TestEfisViewModel, TestEfisModel>().ForPath(a => a.Users.Name, map => map.MapFrom(vm => vm.UserName)).ReverseMap();
                    CreateMap<UlbCvrViewModel, UlbCvrModel>().ForPath(a => a.Users.Name, map => map.MapFrom(vm => vm.UserName)).ReverseMap();
                    CreateMap<UlbFdrViewModel, UlbFdrModel>().ForPath(a => a.Users.Name, map => map.MapFrom(vm => vm.UserName)).ReverseMap();
                    CreateMap<UlbTestViewModel, UlbTestModel>().ForPath(a => a.Users.Name, map => map.MapFrom(vm => vm.UserName)).ReverseMap();
                    CreateMap<UserViewModel, UserModel>().ReverseMap();
        }
        public override string ProfileName
        {
            get { return "MainMappingProfile"; }
        }

  
    }
}