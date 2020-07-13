using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Model;

namespace BazaAwionika.Web
{
    public class AircraftBiuletinMappingProfile : Profile
    {
        public AircraftBiuletinMappingProfile()
        {
            //TODO: dodac mapowanie kolekcji
            (CreateMap<AircraftBiuletinViewModel, AircraftBiuletinModel>()
             .ForMember(a => a.Id, map => map.MapFrom(vm => vm.Id))
             .ForMember(a => a.Name, map => map.MapFrom(vm => vm.Name))
             .ForMember(a => a.AircraftId, map => map.MapFrom(vm => vm.AircraftId))
             .ForMember(a => a.DateExecution, map => map.MapFrom(vm => vm.DateExecution))
             .ForMember(a => a.DateExpiration, map => map.MapFrom(vm => vm.DateExpiration))
                .ForMember(a => a.FlightHoursExpiration, map => map.MapFrom(vm => vm.FlightHoursExpiration))
             .ForMember(a => a.FlightHoursExecutiion, map => map.MapFrom(vm => vm.FlightHoursExecutiion))
             .ForMember(a => a.IsActual, map => map.MapFrom(vm => vm.IsActual))
             .ForMember(a => a.IsRequired, map => map.MapFrom(vm => vm.IsRequired))
             .ForMember(a => a.AdditionalInformation, map => map.MapFrom(vm => vm.AdditionalInformation))
             .ForPath(a => a.Aircraft.TailNumber, map => map.MapFrom(vm => vm.AircraftName))
             ).ReverseMap();


        }

        public override string ProfileName
        {
            get { return "AircraftBiuletinMappingProfile"; }
        }
    }
}