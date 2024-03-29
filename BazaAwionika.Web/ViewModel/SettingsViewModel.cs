using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BazaAwionika.Web.ViewModel
{

    public partial class SettingsViewModel
    {
        //ServicePeriodTimeMonths
        //ServicePeriodFlightHours 
        public int Id { get; set; }
        [Display(Name = "Nazwa ustawień")]
        public string SettingsName { get; set; }
        [Display(Name = "Resurs w godzinach lotu")]
        public short? ServicePeriodFlightHours  { get; set; }
        [Display(Name = "Resurs w miesiącach")]
        public short? ServicePeriodTimeMonths { get; set; }
        [Display(Name = "Pozostałośc nalotu do wydania ostrzeżenia 1")]
        public short? FlightHoursCaution { get; set; }
        [Display(Name = "Pozostałośc nalotu do wydania ostrzeżenia 2")]
        public short? FlightHoursWarning { get; set; }
        [Display(Name = "Pozostałośc nalotu do wydania ostrzeżenia 3")]
        public short? FlightHoursError { get; set; }
        [Display(Name = "Pozostałośc czasu do wydania ostrzeżenia 1")]
        public short? DaysCaution { get; set; }
        [Display(Name = "Pozostałośc czasu do wydania ostrzeżenia 2")]
        public short? DaysWarning { get; set; }
        [Display(Name = "Pozostałośc czasu do wydania ostrzeżenia 3")]
        public short? DaysError { get; set; }

        public int? UserId { get; set; }

        public string UserName { get; set; }

    }
}
