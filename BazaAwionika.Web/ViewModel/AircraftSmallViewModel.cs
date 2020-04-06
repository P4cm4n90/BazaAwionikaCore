using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BazaAwionika.Web.ViewModel
{
    public class AircraftSmallViewModel
    {
        [Display(Name = "Nalot")]
        public int FlightHours { get; set; }
        [Display(Name = "Nr. ogonowy")]
        public string TailNumber { get; set; }
        [Display(Name = "Status")]
        public string AircraftStatusName { get; set; }




    }
}