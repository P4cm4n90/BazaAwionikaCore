namespace BazaAwionika.Web.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;



    public partial class AlternatorViewModel
    {

        public int Id { get; set; }
        [Display(Name = "Nr. Seryjny")]
        public string SerialNumber { get; set; }
        [Display(Name = "Nalot")]
        public int FlightHours { get; set; }
        [Display(Name = "Nalot agregatu przy monta¿u")]
        public int FlightHoursOverhaul { get; set; }
        [Display(Name = "Nalot samolotu przy monta¿u")]
        public int FlightHoursAircraftInstallation { get; set; }
        [Display(Name = "Dodatkowe informacje")]
        public string AdditionalInformation { get; set; }
        [Display(Name = "Aktualnoœæ wpisu")]
        public bool IsActual { get; set; }
        [Display(Name = "Czy zabudowany na samolocie")]
        public bool IsInstalled { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh.mm dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateAdd { get; set; }

        #region Related to other tables

        public int AircraftId { get; set; }
        [Display(Name = "Nr. samolotu")]
        public string AircraftName { get; set; }
        [Display(Name = "Nalot samolotu")]
        public int AircraftFlightHours { get; set; }
        [Display(Name = "Nr. ustawieñ")]
        public int? SettingsId { get; set; }

        public int? SettingsServicePeriodFlightHours { get; set; }

        public int? SettingsFlightHoursError { get; set; }

        public int? SettingsFlightHoursCaution { get; set; }

        public int? SettingsFlightHoursWarning { get; set; }


        public int? UserId { get; set; }
        [Display(Name = "U¿ytkownik")]
        public string UserName { get; set; }

        #endregion
        #region additional properties
        [Display(Name = "Resurs")]
        public int FlightHoursExpiration
        {
            get
            {
                
                int fh_period = SettingsServicePeriodFlightHours ?? 2000; 
                return (fh_period - FlightHoursOverhaul) + FlightHoursAircraftInstallation;
            }
        }
        [Display(Name = "Pozosta³oœæ resursu")]
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
                if (!IsInstalled)
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
