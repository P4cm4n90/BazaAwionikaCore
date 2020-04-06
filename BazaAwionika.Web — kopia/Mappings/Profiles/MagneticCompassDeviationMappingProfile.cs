using System.Linq;
using System.Web;
using AutoMapper;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Model;

namespace BazaAwionika.Web
{
    public class MagneticCompassDeviationMappingProfile : Profile
    {
        public MagneticCompassDeviationMappingProfile()
        {
            CreateMap<MagneticCompassDeviationViewModel, MagneticCompassDeviationModel>()
               .ForMember(a => a.Id, map => map.MapFrom(vm => vm.Id))
                .ForMember(a => a.DateExecution, map => map.MapFrom(vm => vm.DateExecution))
                .ForMember(a => a.Performer, map => map.MapFrom(vm => vm.Performer))
                .ForMember(a => a.IsActual, map => map.MapFrom(vm => vm.IsActual))
                .ForMember(a => a.UserId, map => map.MapFrom(vm => vm.UserId))
                .ForMember(a => a.UserId, map => map.MapFrom(vm => vm.UserId))
                .ForMember(a => a.AircraftId, map => map.MapFrom(vm => vm.AircraftId))
                .ForMember(a => a.SettingsId, map => map.MapFrom(vm => vm.SettingsId));

            CreateMap<MagneticCompassDeviationModel, MagneticCompassDeviationViewModel>()
               .ForMember(a => a.Id, map => map.MapFrom(vm => vm.Id))
                .ForMember(a => a.DateExecution, map => map.MapFrom(vm => vm.DateExecution))
                .ForMember(a => a.Performer, map => map.MapFrom(vm => vm.Performer))
                .ForMember(a => a.IsActual, map => map.MapFrom(vm => vm.IsActual))
                .ForMember(a => a.UserId, map => map.MapFrom(vm => vm.UserId))
                .ForMember(a => a.UserId, map => map.MapFrom(vm => vm.UserId))
                .ForMember(a => a.AircraftId, map => map.MapFrom(vm => vm.AircraftId))
                .ForMember(a => a.SettingsId, map => map.MapFrom(vm => vm.SettingsId))
                .ForPath(a => a.UserName, map => map.MapFrom(vm => vm.User.Name))
                .ForPath(a => a.AircraftName, map => map.MapFrom(vm => vm.Aircraft.FlightHours))
                .ForPath(a => a.SettingsServicePeriodTimeMonths, map => map.MapFrom(vm => vm.Settings.ServicePeriodTimeMonths))
                .ForPath(a => a.SettingsDaysCaution, map => map.MapFrom(vm => vm.Settings.DaysCaution))
                .ForPath(a => a.SettingsDaysWarning, map => map.MapFrom(vm => vm.Settings.DaysWarning))
                .ForPath(a => a.SettingsDaysError, map => map.MapFrom(vm => vm.Settings.DaysError));

        }

        public override string ProfileName
        {
            get { return "MagneticCompassDeviationMappingProfile"; }
        }
    }
}