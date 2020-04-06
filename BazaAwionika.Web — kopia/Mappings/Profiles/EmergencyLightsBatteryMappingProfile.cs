using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Model;

namespace BazaAwionika.Web
{
    public class EmergencyLightsBatteryMappingProfile : Profile
    {
        public EmergencyLightsBatteryMappingProfile()
        {
            CreateMap<EmergencyLightsBatteryViewModel, EmergencyLightsBatteryModel>()
                .ForMember(a => a.Id, map => map.MapFrom(vm => vm.Id))
                .ForMember(a => a.DateExecution, map => map.MapFrom(vm => vm.DateExecution))
                .ForMember(a => a.SerialNumber, map => map.MapFrom(vm => vm.SerialNumber))
                .ForMember(a => a.AdditionalInformation, map => map.MapFrom(vm => vm.AdditionalInformation))
                .ForMember(a => a.IsInstalled, map => map.MapFrom(vm => vm.IsInstalled))
                .ForMember(a => a.IsActual, map => map.MapFrom(vm => vm.IsActual))
                .ForMember(a => a.UserId, map => map.MapFrom(vm => vm.UserId))
                .ForMember(a => a.UserId, map => map.MapFrom(vm => vm.UserId))
                .ForMember(a => a.AircraftId, map => map.MapFrom(vm => vm.AircraftId))
                .ForMember(a => a.SettingsId, map => map.MapFrom(vm => vm.SettingsId));

            CreateMap<EmergencyLightsBatteryModel, EmergencyLightsBatteryViewModel>()
                .ForMember(a => a.Id, map => map.MapFrom(vm => vm.Id))
                .ForMember(a => a.DateExecution, map => map.MapFrom(vm => vm.DateExecution))
                .ForMember(a => a.SerialNumber, map => map.MapFrom(vm => vm.SerialNumber))
                .ForMember(a => a.AdditionalInformation, map => map.MapFrom(vm => vm.AdditionalInformation))
                .ForMember(a => a.IsInstalled, map => map.MapFrom(vm => vm.IsInstalled))
                .ForMember(a => a.IsActual, map => map.MapFrom(vm => vm.IsActual))
                .ForMember(a => a.UserId, map => map.MapFrom(vm => vm.UserId))
                .ForMember(a => a.UserId, map => map.MapFrom(vm => vm.UserId))
                .ForMember(a => a.AircraftId, map => map.MapFrom(vm => vm.AircraftId))
                .ForMember(a => a.SettingsId, map => map.MapFrom(vm => vm.SettingsId))
                .ForPath(a => a.UserName, map => map.MapFrom(vm => vm.User.Name))
                .ForPath(a => a.AircraftName, map => map.MapFrom(vm => vm.Aircraft.TailNumber))
                .ForPath(a => a.SettingsServicePeriodTimeMonths, map => map.MapFrom(vm => vm.Settings.ServicePeriodTimeMonths))
                .ForPath(a => a.SettingsDaysCaution, map => map.MapFrom(vm => vm.Settings.DaysCaution))
                .ForPath(a => a.SettingsDaysWarning, map => map.MapFrom(vm => vm.Settings.DaysWarning))
                .ForPath(a => a.SettingsDaysError, map => map.MapFrom(vm => vm.Settings.DaysError));


        }

        public override string ProfileName
        {
            get { return "EmergencyLightsBatteryMappingProfile"; }
        }
    }
}