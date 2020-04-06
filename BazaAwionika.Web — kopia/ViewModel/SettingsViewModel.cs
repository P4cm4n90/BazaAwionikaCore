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
        [Display(Name = "Nazwa ustawieñ")]
        public string SettingsName { get; set; }
        [Display(Name = "Resurs w godzinach lotu")]
        public short? ServicePeriodFlightHours  { get; set; }
        [Display(Name = "Resurs w miesi¹cach")]
        public short? ServicePeriodTimeMonths { get; set; }
        [Display(Name = "Pozosta³oœc nalotu do wydania ostrze¿enia 1")]
        public short? FlightHoursCaution { get; set; }
        [Display(Name = "Pozosta³oœc nalotu do wydania ostrze¿enia 2")]
        public short? FlightHoursWarning { get; set; }
        [Display(Name = "Pozosta³oœc nalotu do wydania ostrze¿enia 3")]
        public short? FlightHoursError { get; set; }
        [Display(Name = "Pozosta³oœc czasu do wydania ostrze¿enia 1")]
        public short? DaysCaution { get; set; }
        [Display(Name = "Pozosta³oœc czasu do wydania ostrze¿enia 2")]
        public short? DaysWarning { get; set; }
        [Display(Name = "Pozosta³oœc czasu do wydania ostrze¿enia 3")]
        public short? DaysError { get; set; }

        public int? UserId { get; set; }

        public string UserName { get; set; }

    }
}
