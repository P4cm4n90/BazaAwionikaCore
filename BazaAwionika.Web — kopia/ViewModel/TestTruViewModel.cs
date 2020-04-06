using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BazaAwionika.Web.ViewModel
{
    public partial class TestTruViewModel
    {
        public int Id { get; set; }
 
        public int FlightHoursExecution { get; set; }

        public bool IsActual { get; set; }

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

        public int FlightHoursExpiration
        {
            get
            {
                int fh = SettingsServicePeriodFlightHours ?? 300;
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
