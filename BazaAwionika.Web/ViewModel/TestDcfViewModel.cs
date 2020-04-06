using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BazaAwionika.Web.ViewModel
{

    public partial class TestDcfViewModel
    { 
        public int Id { get; set; }
        [Display(Name = "Nalot wykonania")]
        public int FlightHoursExecution { get; set; }
        [Display(Name = "Aktualne")]
        public bool IsActual { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh.mm dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateAdd { get; set; }

        #region Related to other tables
        [Display(Name = "Nr. samolotu")]
        public int AircraftId { get; set; }
        [Display(Name = "Samolot")]
        public string AircraftName { get; set; }
        [Display(Name = "Nalot samolotu")]
        public int AircraftFlightHours { get; set; }
        [Display(Name = "Nr. ustawieñ")]
        public int? SettingsId { get; set; }
        [Display(Name = "Resurs")]
        public int? SettingsServicePeriodFlightHours { get; set; }
        [Display(Name = "Przekroczenie nalotu 1")]
        public int? SettingsFlightHoursError { get; set; }
        [Display(Name = "Przekroczenie nalotu 2")]
        public int? SettingsFlightHoursCaution { get; set; }
        [Display(Name = "Przekroczenie nalotu 3")]
        public int? SettingsFlightHoursWarning { get; set; }

        [Display(Name = "Nr. u¿ytkownika")]
        public int? UserId { get; set; }
        [Display(Name = "Nazwa u¿ytkownika")]
        public string UserName { get; set; }

        #endregion



        #region additional properties

        public int FlightHoursExpiration
        {
            get
            {
                int fh = SettingsServicePeriodFlightHours ?? 50;
                return FlightHoursExecution + fh;
            }
        }

        public int FlightHoursRemaining
        {
            get
            {
                return FlightHoursExpiration - AircraftFlightHours;
            }
        }



        public MaintStatus MaintStatus
        {
            get
            {
                if (!IsActual)
                    return MaintStatus.Unknown;
                if (FlightHoursRemaining <= SettingsFlightHoursError)
                    return MaintStatus.Error;
                if (FlightHoursRemaining <= SettingsFlightHoursWarning)
                    return MaintStatus.Warning;
                if (FlightHoursRemaining <= SettingsFlightHoursCaution)
                    return MaintStatus.Caution;
                else return MaintStatus.Ok;
            }
        }

        #endregion

    }
}
