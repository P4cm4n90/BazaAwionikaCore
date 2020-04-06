using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Model;

namespace BazaAwionika.Web
{
    public class FdrReadMappingProfile : Profile
    {
        public FdrReadMappingProfile()
        {
            CreateMap<FdrReadViewModel, FdrReadModel>()
                .ForMember(a => a.Id, map => map.MapFrom(vm => vm.Id))
                .ForMember(a => a.FlightHoursExecution, map => map.MapFrom(vm => vm.FlightHoursExecution))
                .ForMember(a => a.IsActual, map => map.MapFrom(vm => vm.IsActual))
                .ForMember(a => a.AdditionalInformation, map => map.MapFrom(vm => vm.AdditionalInformation))
                .ForMember(a => a.FlightHoursExecution, map => map.MapFrom(vm => vm.FlightHoursExecution))
                .ForMember(a => a.UserId, map => map.MapFrom(vm => vm.UserId))
                .ForMember(a => a.AircraftId, map => map.MapFrom(vm => vm.AircraftId))
                .ForMember(a => a.SettingsId, map => map.MapFrom(vm => vm.SettingsId));


            CreateMap<FdrReadModel, FdrReadViewModel>()
                .ForMember(a => a.Id, map => map.MapFrom(vm => vm.Id))
                .ForMember(a => a.FlightHoursExecution, map => map.MapFrom(vm => vm.FlightHoursExecution))
                .ForMember(a => a.IsActual, map => map.MapFrom(vm => vm.IsActual))
                .ForMember(a => a.AdditionalInformation, map => map.MapFrom(vm => vm.AdditionalInformation))
                .ForMember(a => a.FlightHoursExecution, map => map.MapFrom(vm => vm.FlightHoursExecution))
                .ForMember(a => a.UserId, map => map.MapFrom(vm => vm.UserId))
                .ForMember(a => a.AircraftId, map => map.MapFrom(vm => vm.AircraftId))
                .ForMember(a => a.SettingsId, map => map.MapFrom(vm => vm.SettingsId))
                .ForPath(a => a.UserName, map => map.MapFrom(vm => vm.User.Name))
                .ForPath(a => a.AircraftName, map => map.MapFrom(vm => vm.Aircraft.FlightHours))
                .ForPath(a => a.AircraftFlightHours, map => map.MapFrom(vm => vm.Aircraft.FlightHours))
                .ForPath(a => a.SettingsServicePeriodFlightHours, map => map.MapFrom(vm => vm.Settings.ServicePeriodFlightHours))
                .ForPath(a => a.SettingsFlightHoursCaution, map => map.MapFrom(vm => vm.Settings.FlightHoursCaution))
                .ForPath(a => a.SettingsFlightHoursWarning, map => map.MapFrom(vm => vm.Settings.FlightHoursWarning))
                .ForPath(a => a.SettingsFlightHoursError, map => map.MapFrom(vm => vm.Settings.FlightHoursError));


        }

        public override string ProfileName
        {
            get { return "FdrReadMappingProfile"; }
        }
    }
}
