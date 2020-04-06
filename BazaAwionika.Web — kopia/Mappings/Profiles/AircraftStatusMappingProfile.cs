using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Model;

namespace BazaAwionika.Web
{
    public class AircraftStatusMappingProfile : Profile
    {
        public AircraftStatusMappingProfile()
        {
            //TODO: dodac mapowanie kolekcji
            (CreateMap<AircraftStatusViewModel, AircraftStatusModel>()
             .ForMember(a => a.Id, map => map.MapFrom(vm => vm.Id))
             .ForMember(a => a.Name, map => map.MapFrom(vm => vm.Name))).ReverseMap();


        }

        public override string ProfileName
        {
            get { return "AircraftStatusMappingProfile"; }
        }
    }
}