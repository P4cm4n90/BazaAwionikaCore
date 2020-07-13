using System;

namespace BazaAwionika.Web.ViewModel
{

    public class AircraftBiuletinViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime? DateExpiration { get; set; }

        public DateTime? DateExecution { get; set; }

        public int? FlightHoursExecution { get; set; }

        public int? FlightHoursExpiration { get; set; }

        public string AdditionalInformation { get; set; }

        public bool? IsRequired { get; set; }

        public bool IsActual { get; set; } = false;

        public int AircraftId { get; set; }

        public string AircraftName { get; set; }

    }
}