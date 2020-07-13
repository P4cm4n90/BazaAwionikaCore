using System;
using System.Collections.Generic;

namespace BazaAwionika.Web.ViewModel
{

    public class AircraftBiuletinsViewModel
    {
        public string Name { get; set; }
        
        public IEnumerable<AircraftBiuletinViewModel> ListBiuletins { get; set; }

    }
}