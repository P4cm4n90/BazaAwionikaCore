using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Model;

namespace BazaAwionika.Web
{
    public class TestEfisDcfTruMappingProfile : Profile
    {
        public TestEfisDcfTruMappingProfile()
        {
  

        /*    CreateMap<TestEfisModel, TestEfisDcfTruViewModel>()
                 .ForPath(a => a.TestEfisViewModel.Id, map => map.MapFrom(vm => vm.Id))
                 .ForPath(a => a.TestEfisViewModel.FlightHoursExecution, map => map.MapFrom(vm => vm.FlightHoursExecution))
                 .ForPath(a => a.TestEfisViewModel.IsActual, map => map.MapFrom(vm => vm.IsActual))
                 .ForPath(a => a.TestEfisViewModel.AircraftId, map => map.MapFrom(vm => vm.AircraftId))
                 .ForPath(a => a.TestEfisViewModel.UserId, map => map.MapFrom(vm => vm.UserId))
                 .ForPath(a => a.TestEfisViewModel.SettingsId, map => map.MapFrom(vm => vm.SettingsId));

            CreateMap<TestDcfModel, TestEfisDcfTruViewModel>()
                     .ForPath(a => a.TestDcfViewModel.Id, map => map.MapFrom(vm => vm.Id))
                     .ForPath(a => a.TestDcfViewModel.FlightHoursExecution, map => map.MapFrom(vm => vm.FlightHoursExecution))
                     .ForPath(a => a.TestDcfViewModel.IsActual, map => map.MapFrom(vm => vm.IsActual))
                     .ForPath(a => a.TestDcfViewModel.AircraftId, map => map.MapFrom(vm => vm.AircraftId))
                     .ForPath(a => a.TestDcfViewModel.UserId, map => map.MapFrom(vm => vm.UserId))
                     .ForPath(a => a.TestDcfViewModel.SettingsId, map => map.MapFrom(vm => vm.SettingsId));

            CreateMap<TestTruModel, TestEfisDcfTruViewModel>()
                 .ForPath(a => a.TestTruViewModel.Id, map => map.MapFrom(vm => vm.Id))
                 .ForPath(a => a.TestTruViewModel.FlightHoursExecution, map => map.MapFrom(vm => vm.FlightHoursExecution))
                 .ForPath(a => a.TestTruViewModel.IsActual, map => map.MapFrom(vm => vm.IsActual))
                 .ForPath(a => a.TestTruViewModel.AircraftId, map => map.MapFrom(vm => vm.AircraftId))
                 .ForPath(a => a.TestTruViewModel.UserId, map => map.MapFrom(vm => vm.UserId))
                 .ForPath(a => a.TestTruViewModel.SettingsId, map => map.MapFrom(vm => vm.SettingsId));*/


        }

        public override string ProfileName
        {
            get { return "TestEfisDcfTruMappingProfile"; }
        }
    }
}