namespace BazaAwionika.Web.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;



    public partial class BatteryViewModel
    {
        
        public int Id { get; set; }
        [Display(Name = "Wykonanie cyklu")]
        public DateTime DateExecution { get; set; }
        [Display(Name = "Wykonanie cyklu")]
        public int FlightHoursExecution { get; set; }
        [Display(Name = "Nalot przy zabudowie na samolot")]
        public int FlightHoursAircraftInstallation { get; set; }
        [Display(Name = "Nalot ca³kowity")]
        public int FlightHours { get; set; }
        [Display(Name = "Informacje dodatkowe")]
        public string AdditionalInformation { get; set; }
        [Display(Name = "Nalot przy zabudowie na samolot")]
        public bool IsActual { get; set; } = false;

        public bool IsInstalled { get; set; } = false;
        [Display(Name = "Nr. seryjny")]
        public string SerialNumber { get; set; }


        [DisplayFormat(DataFormatString = "{0:hh.mm dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateAdd { get; set; }

        #region Related to other tables

        public int AircraftId { get; set; }
        [Display(Name = "Nr. samolotu")]
        public string AircraftName { get; set; }
        [Display(Name = "Nalot samolotu")]
        public int AircraftFlightHours { get; set; }
        [Display(Name = "Ustawienia resursu")]
        public int? SettingsId { get; set; }

        public int? SettingsServicePeriodFlightHours { get; set; }

        public int? SettingsServicePeriodTimeMonths { get; set; }

        public int? SettingsDaysCaution { get; set; }

        public int? SettingsDaysWarning { get; set; }

        public int? SettingsDaysError { get; set; }

        public int? SettingsFlightHoursError { get; set; }

        public int? SettingsFlightHoursCaution { get; set; }

        public int? SettingsFlightHoursWarning { get; set; }

        public int? UserId { get; set; }
        [Display(Name = "U¿ytkownik edytuj¹cy")]
        public string UserName { get; set; }


        #endregion
        #region additional properties
        [Display(Name = "Nastêpny cykl")]
        public int FlightHoursExpiration
        {
            get
            {
                int fh = SettingsServicePeriodFlightHours ?? 300;
                return FlightHoursExecution + fh;
            }
        }
        [Display(Name = "Nastêpny cykl")]
        public DateTime DateExpiration
        {
            get
            {
                int months = SettingsServicePeriodTimeMonths ?? 8;
                return DateExecution.AddMonths(months);
            }
        }
        [Display(Name = "Pozosta³o nalotu")]
        public int FlightHoursRemaining
        {
            get
            {
                return FlightHoursExpiration - FlightHours;
            }
        }
        [Display(Name = "Pozosta³o dni")]
        public int DaysRemaining
        {
            get
            {
                return (int)(DateExpiration - DateTime.Now.Date).TotalDays;
            }
        }
        public MaintStatus MaintStatus
        {
            get
            {
                if (FlightHoursRemaining <= SettingsFlightHoursError || DaysRemaining <= SettingsDaysError)
                    return MaintStatus.Error;
                if (FlightHoursRemaining <= SettingsFlightHoursWarning || DaysRemaining <= SettingsDaysWarning)
                    return MaintStatus.Warning;
                if (FlightHoursRemaining <= SettingsFlightHoursCaution || DaysRemaining <= SettingsDaysCaution)
                    return MaintStatus.Caution;
                else return MaintStatus.Ok;
            }
        }

        #endregion

    }
}
