using System.Linq;
using System.Web;
using AutoMapper;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Model;

namespace BazaAwionika.Web
{
    public class OxygenCylinderMainMappingProfile : Profile
    {
        public OxygenCylinderMainMappingProfile()
        {
            CreateMap<OxygenCylinderMainViewModel, OxygenCylinderMainModel>()
               .ForMember(a => a.Id, map => map.MapFrom(vm => vm.Id))
                .ForMember(a => a.DateExpiration, map => map.MapFrom(vm => vm.DateExpiration))
                .ForMember(a => a.DateDiscard, map => map.MapFrom(vm => vm.DateDiscard))
                .ForMember(a => a.SerialNumber, map => map.MapFrom(vm => vm.SerialNumber))
                .ForMember(a => a.AdditionalInformation, map => map.MapFrom(vm => vm.AdditionalInformation))
                .ForMember(a => a.IsInstalled, map => map.MapFrom(vm => vm.IsInstalled))
                .ForMember(a => a.IsActual, map => map.MapFrom(vm => vm.IsActual))
                .ForMember(a => a.UserId, map => map.MapFrom(vm => vm.UserId))
                .ForMember(a => a.UserId, map => map.MapFrom(vm => vm.UserId))
                .ForMember(a => a.AircraftId, map => map.MapFrom(vm => vm.AircraftId))
                .ForMember(a => a.SettingsId, map => map.MapFrom(vm => vm.SettingsId));


            CreateMap<OxygenCylinderMainModel, OxygenCylinderMainViewModel>()
                .ForMember(a => a.Id, map => map.MapFrom(vm => vm.Id))
                .ForMember(a => a.DateExpiration, map => map.MapFrom(vm => vm.DateExpiration))
                .ForMember(a => a.DateDiscard, map => map.MapFrom(vm => vm.DateDiscard))
                .ForMember(a => a.SerialNumber, map => map.MapFrom(vm => vm.SerialNumber))
                .ForMember(a => a.AdditionalInformation, map => map.MapFrom(vm => vm.AdditionalInformation))
                .ForMember(a => a.IsInstalled, map => map.MapFrom(vm => vm.IsInstalled))
                .ForMember(a => a.IsActual, map => map.MapFrom(vm => vm.IsActual))
                .ForMember(a => a.UserId, map => map.MapFrom(vm => vm.UserId))
                .ForMember(a => a.UserId, map => map.MapFrom(vm => vm.UserId))
                .ForMember(a => a.AircraftId, map => map.MapFrom(vm => vm.AircraftId))
                .ForMember(a => a.SettingsId, map => map.MapFrom(vm => vm.SettingsId))
                .ForPath(a => a.UserName, map => map.MapFrom(vm => vm.User.Name))
                .ForPath(a => a.AircraftName, map => map.MapFrom(vm => vm.Aircraft.FlightHours))
                .ForPath(a => a.SettingsDaysCaution, map => map.MapFrom(vm => vm.Settings.DaysCaution))
                .ForPath(a => a.SettingsDaysWarning, map => map.MapFrom(vm => vm.Settings.DaysWarning))
                .ForPath(a => a.SettingsDaysError, map => map.MapFrom(vm => vm.Settings.DaysError));

        }

        public override string ProfileName
        {
            get { return "OxygenCylinderMainMappingProfile"; }
        }
    }
}