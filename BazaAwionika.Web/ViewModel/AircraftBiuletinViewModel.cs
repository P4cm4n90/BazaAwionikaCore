using System;

namespace BazaAwionika.Web.ViewModel
{

    public class AircraftBiuletinViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime? DateExpiration { get; set; }

        public DateTime? DateExecution { get; set; }

        public int? FlightHoursExecution { get; set; } = 0;

        public int? FlightHoursExpiration { get; set; }

        public string AdditionalInformation { get; set; }

        public bool? IsRequired { get; set; }

        public bool IsActual { get; set; } = false;

        public int AircraftId { get; set; }

        public string AircraftName { get; set; }

        public int? AircraftFlightHours { get; set; }

        public int? FlightHoursRemaining { get
            {
                if (FlightHoursExecution != 0)
                    return FlightHoursExpiration - AircraftFlightHours;
                else
                    return 0;
            }
        }

        public int? DaysRemaining
        {
            get
            {
                if (DateExpiration == null)
                    return 0;
                else
                    return CalcHelper.CalcDaysBetweenDates((DateTime)DateExpiration, DateTime.Now.Date);
            }
        }

        public bool IsDone { get
            {
                if (FlightHoursExecution > 0 || DateExecution != null)
                    return true;
                else
                    return false;
            }
        }

    }
}