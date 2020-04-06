namespace BazaAwionika.Web.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;



    public partial class EltOperationalTestViewModel
    {


        public int Id { get; set; }

        public DateTime DateExecution { get; set; }

        public short FlightHoursExecution { get; set; }

        public bool IsActual { get; set; } = false;
        [DisplayFormat(DataFormatString = "{0:hh.mm dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateAdd { get; set; }

        #region Related to other tables

        public int AircraftId { get; set; }

        public string AircraftName { get; set; }

        public int AircraftFlightHours { get; set; }

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

        public string UserName { get; set; }

        #endregion

        #region additional properties

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Data wa¿noœci")]
        public DateTime DateExpiration
        {
            get
            {
                int months = SettingsServicePeriodTimeMonths ?? 3;
                return DateExecution.AddMonths(months);
            }
        }     

        public int DaysRemaining
        {
            get
            {
                return (int)(DateExpiration - DateTime.Now.Date).TotalDays;
            }
        }

        public int FlightHoursExpiration
        {
            get
            {
                int fh = SettingsServicePeriodFlightHours ?? 100;
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
                if (DaysRemaining <= SettingsDaysError || FlightHoursRemaining <= SettingsFlightHoursError)
                    return MaintStatus.Error;
                if (DaysRemaining <= SettingsDaysWarning || FlightHoursRemaining <= SettingsFlightHoursWarning)
                    return MaintStatus.Warning;
                if (DaysRemaining <= SettingsDaysCaution || FlightHoursRemaining <= SettingsFlightHoursCaution)
                    return MaintStatus.Caution;
                else return MaintStatus.Ok;
            }
        }

        #endregion




    }
}
