using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Model;

namespace BazaAwionika.Web
{
    public class SettingsMappingProfile : Profile
    {
        public SettingsMappingProfile()
        { //TODO: do it


            CreateMap<SettingsViewModel, SettingsModel>()
                .ForMember(a => a.Id, map => map.MapFrom(vm => vm.Id))
                .ForMember(a => a.SettingsName, map => map.MapFrom(vm => vm.SettingsName))
                .ForMember(a => a.UserId, map => map.MapFrom(vm => vm.UserId))
                .ForMember(a => a.ServicePeriodFlightHours, map => map.MapFrom(vm => vm.ServicePeriodFlightHours))
                .ForMember(a => a.FlightHoursCaution, map => map.MapFrom(vm => vm.FlightHoursCaution))
                .ForMember(a => a.FlightHoursWarning, map => map.MapFrom(vm => vm.FlightHoursWarning))
                .ForMember(a => a.FlightHoursError, map => map.MapFrom(vm => vm.FlightHoursError))
                .ForMember(a => a.ServicePeriodTimeMonths, map => map.MapFrom(vm => vm.ServicePeriodTimeMonths))
                .ForMember(a => a.DaysCaution, map => map.MapFrom(vm => vm.DaysCaution))
                .ForMember(a => a.DaysWarning, map => map.MapFrom(vm => vm.DaysWarning))
                .ForMember(a => a.DaysError, map => map.MapFrom(vm => vm.DaysError));


            CreateMap<SettingsModel, SettingsViewModel>()
                .ForMember(a => a.Id, map => map.MapFrom(vm => vm.Id))
                .ForMember(a => a.SettingsName, map => map.MapFrom(vm => vm.SettingsName))
                .ForMember(a => a.UserId, map => map.MapFrom(vm => vm.UserId))
                .ForMember(a => a.ServicePeriodFlightHours, map => map.MapFrom(vm => vm.ServicePeriodFlightHours))
                .ForMember(a => a.FlightHoursCaution, map => map.MapFrom(vm => vm.FlightHoursCaution))
                .ForMember(a => a.FlightHoursWarning, map => map.MapFrom(vm => vm.FlightHoursWarning))
                .ForMember(a => a.FlightHoursError, map => map.MapFrom(vm => vm.FlightHoursError))
                .ForMember(a => a.ServicePeriodTimeMonths, map => map.MapFrom(vm => vm.ServicePeriodTimeMonths))
                .ForMember(a => a.DaysCaution, map => map.MapFrom(vm => vm.DaysCaution))
                .ForMember(a => a.DaysWarning, map => map.MapFrom(vm => vm.DaysWarning))
                .ForMember(a => a.DaysError, map => map.MapFrom(vm => vm.DaysError))
                .ForPath(a => a.UserName, map => map.MapFrom(vm => vm.User.Name));



        }

        public override string ProfileName
        {
            get { return "SettingsMappingProfile"; }
        }
    }
}
