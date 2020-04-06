using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BazaAwionika.Web.ViewModel
{
    public class AircraftMaintenanceViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateExpiration { get; set; }

        public DateTime DateExecution { get; set; }

        [MaxLength(100)]
        public string AdditionalInformation { get; set; }

        public bool IsActual { get; set; } = false;

        public int AircraftId { get; set; }

        public string AircraftName { get; set; }
    }
}