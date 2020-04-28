using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BazaAwionika.Web.ViewModel
{
    public class AircraftFullViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nalot")]
        public int FlightHours { get; set; }

        [Display(Name = "Nr. ogonowy")]
        public string TailNumber { get; set; }

        [Display(Name = "Nr. ogonowy")]
        public string SerialNumber { get; set; }

        [Display(Name = "Informacje")]
        public string AdditionalInfo { get; set; }
        [Display(Name = "Położenie")]
        public string Location { get; set; }

        [Display(Name = "Data nalotu")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateFlightHours { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh.mm dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateAdd { get; set; }

        #region Related to other tables
        [Display(Name = "Data wylotu")]
        [DisplayFormat(DataFormatString = "{0:hh.mm dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateStart { get; set; }

        [Display(Name = "Data powrotu")]
        [DisplayFormat(DataFormatString = "{0:hh.mm dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateEnd { get; set; }

        [Display(Name = "Miejsce pobytu")]
        public string AircraftLocationName { get; set; }
        [Display(Name = "Status")]
        public string AircraftStatusName { get; set; }

        public int? AircraftStatusId { get; set; }

        public int? UserId { get; set; }

        public virtual ICollection<AlternatorViewModel> Alternators { get; set; }

        public virtual ICollection<BatteryViewModel> Batteries { get; set; }
        public virtual ICollection<EgpwsDatabaseViewModel> EgpwsDatabase { get; set; }

        public virtual ICollection<EltFunctionalTestViewModel> EltFunctionalTest { get; set; }

        public virtual ICollection<EltOperationalTestViewModel> EltOperationalTest { get; set; }

        public virtual ICollection<EmergencyLightsBatteryViewModel> EmergencyLightsBatteries { get; set; }

        public virtual ICollection<FdrReadViewModel> FdrRead { get; set; }

        public virtual ICollection<GeneratorViewModel> Generators { get; set; }

        public virtual ICollection<GipsenDatabaseViewModel> GipsenDatabase { get; set; }

        public virtual ICollection<GpsBatteriesViewModel> GpsBatteries { get; set; }

        public virtual ICollection<GpsPCodesViewModel> GpsPCodes { get; set; }

        public virtual ICollection<MagneticCompassDeviationViewModel> MagneticCompassDeviation { get; set; }

        public virtual ICollection<OxygenCylinderMainViewModel> OxygenCylinderMain { get; set; }

        public virtual ICollection<OxygenCylinderPortableViewModel> OxygenCylinderPortable { get; set; }

        public virtual ICollection<OxygenExchangeViewModel> OxygenExchange { get; set; }

        public virtual ICollection<PbeViewModel> Pbe { get; set; }
        public virtual ICollection<TestDcfViewModel> TestDcf { get; set; }

        public virtual ICollection<TestEfisViewModel> TestEfis { get; set; }

        public virtual ICollection<TestTruViewModel> TestTru { get; set; }

        public virtual ICollection<UlbCvrViewModel> UlbCvr { get; set; }
        public virtual ICollection<UlbFdrViewModel> UlbFdr { get; set; }

        public virtual ICollection<UlbTestViewModel> UlbTest { get; set; }

        public virtual ICollection<AircraftBiuletinViewModel> AircraftBiuletins { get; set; }

        public virtual ICollection<AircraftMaintenanceViewModel> AircraftMaintenances { get; set; }

        public virtual ICollection<FlightViewModel> Flights { get; set; }

        #endregion
    }
}