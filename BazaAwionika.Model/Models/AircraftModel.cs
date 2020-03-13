namespace BazaAwionika.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
 

    [Table("Aircraft")]
    public partial class AircraftModel
    {

        [Key]
        public int Id { get; set; }

        public int FlightHours { get; set; }

        public string TailNumber { get; set; }

        public string SerialNumber { get; set; }

        public int? AircraftStatusId { get; set; }

        public string Location { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateStart { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateEnd { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh.mm dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateAdd { get; set; } = DateTime.Now;

        [Column(TypeName = "smalldatetime")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateFlightHours { get; set; } = DateTime.Now;

        public string AdditionalInfo { get; set; }

        public int? UserId { get; set; }

        public virtual ICollection<AlternatorModel> Alternators { get; set; }

        public virtual ICollection<BatteryModel> Batteries { get; set; }
        public virtual ICollection<EgpwsDatabaseModel> EgpwsDatabase { get; set; }

        public virtual ICollection<EltFunctionalTestModel> EltFunctionalTest { get; set; }

        public virtual ICollection<EltOperationalTestModel> EltOperationalTest { get; set; }

        public virtual ICollection<EmergencyLightsBatteryModel> EmergencyLightsBatteries { get; set; }

        public virtual ICollection<FdrReadModel> FdrRead { get; set; }

        public virtual ICollection<GeneratorModel> Generators { get; set; }

        public virtual ICollection<GipsenDatabaseModel> GipsenDatabase { get; set; }

        public virtual ICollection<GpsBatteriesModel> GpsBatteries { get; set; }

        public virtual ICollection<GpsPCodesModel> GpsPCodes { get; set; }

        public virtual ICollection<MagneticCompassDeviationModel> MagneticCompassDeviation { get; set; }

        public virtual ICollection<OxygenCylinderMainModel> OxygenCylinderMain { get; set; }

        public virtual ICollection<OxygenCylinderPortableModel> OxygenCylinderPortable { get; set; }

        public virtual ICollection<OxygenExchangeModel> OxygenExchange { get; set; }

        public virtual ICollection<PbeModel> Pbe { get; set; }
        public virtual ICollection<TestDcfModel> TestDcf { get; set; }

        public virtual ICollection<TestEfisModel> TestEfis { get; set; }

        public virtual ICollection<TestTruModel> TestTru { get; set; }

        public virtual ICollection<UlbCvrModel> UlbCvr { get; set; }
        public virtual ICollection<UlbFdrModel> UlbFdr { get; set; }

        public virtual ICollection<UlbTestModel> UlbTest { get; set; }

        public virtual ICollection<AircraftBiuletinModel> AircraftBiuletins { get; set; }

        public virtual ICollection<AircraftMaintenanceModel> AircraftMaintenances { get; set; }

        public virtual ICollection<FlightModel> Flights { get; set; }

        [ForeignKey("UserId")]
        public virtual UserModel Users { get; set; }

        [ForeignKey("AircraftStatusId")]
        public virtual AircraftStatusModel AircraftStatus { get; set; }
    }
}
