namespace BazaAwionika.Web.ViewModel




{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class GeneratorViewModel
    {

        public int Id{ get; set; }

        public string SerialNumber { get; set; }

        public int FlightHours { get; set; }

        public int FlightHoursBrushes { get; set; }

        public int FlightHoursBearings { get; set; }

        public int FlightHoursOverhaul { get; set; }

        public int FlightHoursAircraftInstallation { get; set; }

        public string AdditionalInformation { get; set; }

        public bool? IsActual { get; set; }

        public bool IsInstalled { get; set; } = false;

        [DisplayFormat(DataFormatString = "{0:hh.mm dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateAdd { get; set; }

        #region Related to other tables

        public int AircraftId { get; set; }

        public string AircraftName { get; set; }

        public int AircraftFlightHours { get; set; }

        public int? SettingsId { get; set; }

        public int? SettingsServicePeriodFlightHours { get; set; }

        public int? SettingsFlightHoursError { get; set; }

        public int? SettingsFlightHoursCaution { get; set; }

        public int? SettingsFlightHoursWarning { get; set; }

        public int? UserId { get; set; }

        public string UserName { get; set; }


        #endregion
        #region additional properties

        public int ServicePeriodFlightHours
        {
            get
            {
                return SettingsServicePeriodFlightHours ?? 600;
            }
        }

        public int FlightHoursBrushesExpiration
        {
            get
            {
                return (ServicePeriodFlightHours - FlightHoursBrushes) + FlightHoursAircraftInstallation;
            }
        }

        public int FlightHoursBearingExpiration
        {
            get
            {
                return (ServicePeriodFlightHours*2 - FlightHoursBearings) + FlightHoursAircraftInstallation;
            }
        }

        public int FlightHoursOverhaulExpiration
        {
            get
            {

                return (ServicePeriodFlightHours * 4 - FlightHoursOverhaul) + FlightHoursAircraftInstallation;
            }
        }

        public int? FlightHoursBrushesRemaining
        {
            get
            {
                return FlightHoursBrushesExpiration - AircraftFlightHours;

            }
        }

        public int? FlightHoursBearingRemaining
        {
            get
            {
                return FlightHoursBearingExpiration - AircraftFlightHours;
            }
        }

        public int? FlightHoursOverhaulRemaining
        {
            get
            {
                return FlightHoursOverhaulExpiration - AircraftFlightHours;
            }
        }

        public MaintStatus MaintStatus
        {
            get
            {
                if (!IsInstalled)
                    return MaintStatus.Unknown;
                var check_list = new List<int?> { FlightHoursOverhaulRemaining, FlightHoursBearingRemaining, FlightHoursBrushesRemaining };
                int check = check_list.Max(c => c.Value);
                if (check <= SettingsFlightHoursError)
                    return MaintStatus.Error;
                if (check <= SettingsFlightHoursWarning)
                    return MaintStatus.Warning;
                if (check <= SettingsFlightHoursCaution)
                    return MaintStatus.Caution;
                else return MaintStatus.Ok;
            }
        }

        #endregion


    }
}
