using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Model;

namespace BazaAwionika.Web
{
    public class AircraftMappingProfile : Profile
    {
        public AircraftMappingProfile()
        { //TODO: poprawic mappingi tak zeby takie mappingi z settings albo location byly tylko w jedna strone. Pozdro 600



            //   .ForPath(a => a.AircraftLocation.Location, map => map.MapFrom(vm => vm.AircraftLocationName))
            //    .ForPath(a => a.AircraftStatus.Name, map => map.MapFrom(vm => vm.AircraftStatusName))).ReverseMap();

            CreateMap<AircraftViewModel, AircraftModel>()
             .ForMember(a => a.TailNumber, map => map.MapFrom(vm => vm.TailNumber))
             .ForMember(a => a.SerialNumber, map => map.MapFrom(vm => vm.SerialNumber))
             .ForMember(a => a.AdditionalInfo, map => map.MapFrom(vm => vm.AdditionalInfo))
             .ForMember(a => a.AircraftStatusId, map => map.MapFrom(vm => vm.AircraftStatusId))
             .ForMember(a => a.FlightHours, map => map.MapFrom(vm => vm.FlightHours))
             .ForMember(a => a.DateFlightHours, map => map.MapFrom(vm => vm.DateFlightHours))
             .ForMember(a => a.DateAdd, map => map.MapFrom(vm => vm.DateAdd))
             .ForMember(a => a.DateStart, map => map.MapFrom(vm => vm.DateStart))
             .ForMember(a => a.DateEnd, map => map.MapFrom(vm => vm.DateEnd))
             .ForMember(a => a.Location, map => map.MapFrom(vm => vm.Location))
             .ForMember(a => a.Id, map => map.MapFrom(vm => vm.Id)); 

            CreateMap<AircraftModel, AircraftViewModel>()
             .ForMember(a => a.TailNumber, map => map.MapFrom(vm => vm.TailNumber))
             .ForMember(a => a.SerialNumber, map => map.MapFrom(vm => vm.SerialNumber))
             .ForMember(a => a.AdditionalInfo, map => map.MapFrom(vm => vm.AdditionalInfo))
             .ForMember(a => a.AircraftStatusId, map => map.MapFrom(vm => vm.AircraftStatusId))
             .ForMember(a => a.FlightHours, map => map.MapFrom(vm => vm.FlightHours))
             .ForMember(a => a.DateFlightHours, map => map.MapFrom(vm => vm.DateFlightHours))
             .ForMember(a => a.DateAdd, map => map.MapFrom(vm => vm.DateAdd))
             .ForMember(a => a.Id, map => map.MapFrom(vm => vm.Id))
             .ForMember(a => a.DateStart, map => map.MapFrom(vm => vm.DateStart))
             .ForMember(a => a.DateEnd, map => map.MapFrom(vm => vm.DateEnd))
             .ForMember(a => a.Location, map => map.MapFrom(vm => vm.Location))
             .ForPath(a => a.AircraftStatusName, map => map.MapFrom(vm => vm.AircraftStatus.Name));

            CreateMap<AircraftModel, AircraftSmallViewModel>()
              .ForMember(a => a.TailNumber, map => map.MapFrom(vm => vm.TailNumber))           
              .ForMember(a => a.FlightHours, map => map.MapFrom(vm => vm.FlightHours))
              .ForPath(a => a.AircraftStatusName, map => map.MapFrom(vm => vm.AircraftStatus.Name));

            CreateMap<AircraftModel, AircraftFullViewModel>().ReverseMap();

        }

        public override string ProfileName
        {
            get { return "AircraftMappingProfile"; }
        }
    }
}