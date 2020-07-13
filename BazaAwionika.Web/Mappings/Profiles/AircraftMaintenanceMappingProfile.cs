using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Model;

namespace BazaAwionika.Web
{
    public class AircraftMaintenanceMappingProfile : Profile
    {
        public AircraftMaintenanceMappingProfile()
        {
            //TODO: dodac mapowanie kolekcji
            (CreateMap<AircraftMaintenanceViewModel, AircraftMaintenanceModel>()
             .ForMember(a => a.Id, map => map.MapFrom(vm => vm.Id))
             .ForMember(a => a.Name, map => map.MapFrom(vm => vm.Name))
             .ForMember(a => a.AircraftId, map => map.MapFrom(vm => vm.AircraftId))
             .ForMember(a => a.DateExecution, map => map.MapFrom(vm => vm.DateExecution))
             .ForMember(a => a.DateExpiration, map => map.MapFrom(vm => vm.DateExpiration))
             .ForMember(a => a.FlightHoursExpiration, map => map.MapFrom(vm => vm.FlightHoursExpiration))
             .ForMember(a => a.FlightHoursExecutiion, map => map.MapFrom(vm => vm.FlightHoursExecutiion))
             .ForMember(a => a.IsActual, map => map.MapFrom(vm => vm.IsActual))
             .ForPath(a => a.Aircraft.TailNumber, map => map.MapFrom(vm => vm.AircraftName))
             .ForMember(a => a.AdditionalInformation, map => map.MapFrom(vm => vm.AdditionalInformation))
             ).ReverseMap();


        }

        public override string ProfileName
        {
            get { return "AircraftMaintenanceMappingProfile"; }
        }
    }
}