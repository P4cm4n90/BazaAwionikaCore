using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Model;

namespace BazaAwionika.Web
{
    public class BatteryMappingProfile : Profile
    {
        public BatteryMappingProfile()
        {
            CreateMap<BatteryViewModel, BatteryModel>()
                .ForMember(a => a.Id, map => map.MapFrom(vm => vm.Id))
                .ForMember(a => a.FlightHoursExecution, map => map.MapFrom(vm => vm.FlightHoursExecution))
                .ForMember(a => a.FlightHours, map => map.MapFrom(vm => vm.FlightHours))
                .ForMember(a => a.DateExecution, map => map.MapFrom(vm => vm.DateExecution))
                .ForMember(a => a.SerialNumber, map => map.MapFrom(vm => vm.SerialNumber))
                .ForMember(a => a.IsActual, map => map.MapFrom(vm => vm.IsActual))
                .ForMember(a => a.IsInstalled, map => map.MapFrom(vm => vm.IsInstalled))
                .ForMember(a => a.AdditionalInformation, map => map.MapFrom(vm => vm.AdditionalInformation))
                .ForMember(a => a.UserId, map => map.MapFrom(vm => vm.UserId))
                .ForMember(a => a.AircraftId, map => map.MapFrom(vm => vm.AircraftId))
                .ForMember(a => a.SettingsId, map => map.MapFrom(vm => vm.SettingsId));

            CreateMap<BatteryModel, BatteryViewModel>()
                .ForMember(a => a.Id, map => map.MapFrom(vm => vm.Id))
                .ForMember(a => a.FlightHoursExecution, map => map.MapFrom(vm => vm.FlightHoursExecution))
                .ForMember(a => a.FlightHours, map => map.MapFrom(vm => vm.FlightHours))
                .ForMember(a => a.DateExecution, map => map.MapFrom(vm => vm.DateExecution))
                .ForMember(a => a.SerialNumber, map => map.MapFrom(vm => vm.SerialNumber))
                .ForMember(a => a.IsActual, map => map.MapFrom(vm => vm.IsActual))
                .ForMember(a => a.IsInstalled, map => map.MapFrom(vm => vm.IsInstalled))
                .ForMember(a => a.AdditionalInformation, map => map.MapFrom(vm => vm.AdditionalInformation))
                .ForMember(a => a.UserId, map => map.MapFrom(vm => vm.UserId))
                .ForMember(a => a.AircraftId, map => map.MapFrom(vm => vm.AircraftId))
                .ForMember(a => a.SettingsId, map => map.MapFrom(vm => vm.SettingsId))
                .ForPath(a => a.UserName, map => map.MapFrom(vm => vm.User.Name))
                .ForPath(a => a.AircraftName, map => map.MapFrom(vm => vm.Aircraft.TailNumber))
                .ForPath(a => a.AircraftFlightHours, map => map.MapFrom(vm => vm.Aircraft.FlightHours))
                .ForPath(a => a.SettingsServicePeriodFlightHours, map => map.MapFrom(vm => vm.Settings.ServicePeriodFlightHours))
                .ForPath(a => a.SettingsFlightHoursCaution, map => map.MapFrom(vm => vm.Settings.FlightHoursCaution))
                .ForPath(a => a.SettingsFlightHoursWarning, map => map.MapFrom(vm => vm.Settings.FlightHoursWarning))
                .ForPath(a => a.SettingsFlightHoursError, map => map.MapFrom(vm => vm.Settings.FlightHoursError))
                .ForPath(a => a.SettingsServicePeriodTimeMonths, map => map.MapFrom(vm => vm.Settings.ServicePeriodTimeMonths))
                .ForPath(a => a.SettingsDaysCaution, map => map.MapFrom(vm => vm.Settings.DaysCaution))
                .ForPath(a => a.SettingsDaysWarning, map => map.MapFrom(vm => vm.Settings.DaysWarning))
                .ForPath(a => a.SettingsDaysError, map => map.MapFrom(vm => vm.Settings.DaysError));


        }

        public override string ProfileName
        {
            get { return "BatteryMappingProfile"; }
        }
    }
}
