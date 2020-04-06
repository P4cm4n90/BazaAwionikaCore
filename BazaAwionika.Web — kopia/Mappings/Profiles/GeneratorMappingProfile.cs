using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Model;

namespace BazaAwionika.Web
{
    public class GeneratorMappingProfile : Profile
    {
        public GeneratorMappingProfile()
        {

            CreateMap<GeneratorViewModel, GeneratorModel>()
                 .ForMember(a => a.Id, map => map.MapFrom(vm => vm.Id))
                 .ForMember(a => a.FlightHoursOverhaul, map => map.MapFrom(vm => vm.FlightHoursOverhaul))
                 .ForMember(a => a.FlightHoursBearing, map => map.MapFrom(vm => vm.FlightHoursBearings))
                 .ForMember(a => a.FlightHoursBrushes, map => map.MapFrom(vm => vm.FlightHoursBrushes))
                 .ForMember(a => a.FlightHours, map => map.MapFrom(vm => vm.FlightHours))
                 .ForMember(a => a.FlightHoursAircraftInstallation, map => map.MapFrom(vm => vm.FlightHoursAircraftInstallation))
                 .ForMember(a => a.SerialNumber, map => map.MapFrom(vm => vm.SerialNumber))
                 .ForMember(a => a.IsInstalled, map => map.MapFrom(vm => vm.IsInstalled))
                 .ForMember(a => a.IsActual, map => map.MapFrom(vm => vm.IsActual))
                 .ForMember(a => a.AircraftId, map => map.MapFrom(vm => vm.AircraftId))
                 .ForMember(a => a.UserId, map => map.MapFrom(vm => vm.UserId))
                 .ForMember(a => a.SettingsId, map => map.MapFrom(vm => vm.SettingsId))
                 .ForMember(a => a.AdditionalInformation, map => map.MapFrom(vm => vm.AdditionalInformation));

            CreateMap<GeneratorModel, GeneratorViewModel>()
                 .ForMember(a => a.Id, map => map.MapFrom(vm => vm.Id))
                 .ForMember(a => a.FlightHoursOverhaul, map => map.MapFrom(vm => vm.FlightHoursOverhaul))
                 .ForMember(a => a.FlightHoursBearings, map => map.MapFrom(vm => vm.FlightHoursBearing))
                 .ForMember(a => a.FlightHoursBrushes, map => map.MapFrom(vm => vm.FlightHoursBrushes))
                 .ForMember(a => a.FlightHours, map => map.MapFrom(vm => vm.FlightHours))
                 .ForMember(a => a.FlightHoursAircraftInstallation, map => map.MapFrom(vm => vm.FlightHoursAircraftInstallation))
                 .ForMember(a => a.SerialNumber, map => map.MapFrom(vm => vm.SerialNumber))
                 .ForMember(a => a.IsInstalled, map => map.MapFrom(vm => vm.IsInstalled))
                 .ForMember(a => a.IsActual, map => map.MapFrom(vm => vm.IsActual))
                 .ForMember(a => a.AircraftId, map => map.MapFrom(vm => vm.AircraftId))
                 .ForMember(a => a.UserId, map => map.MapFrom(vm => vm.UserId))
                 .ForMember(a => a.SettingsId, map => map.MapFrom(vm => vm.SettingsId))
                 .ForMember(a => a.AdditionalInformation, map => map.MapFrom(vm => vm.AdditionalInformation))
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
            get { return "GeneratorMappingProfile"; }
        }
    }
}