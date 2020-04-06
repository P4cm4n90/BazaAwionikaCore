namespace BazaAwionika.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;



    [Table("User")]
    public partial class UserModel
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        public string PasswordHash { get; set; }

        [NotMapped]
        public string Password { get; set; }

        [Column(TypeName = "text")]
        [StringLength(50)]
        public string AdditionalInformation { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool AdminPriviliges { get; set; }

        public virtual ICollection<AircraftModel> Aircrafts { get; set; }

        public virtual ICollection<AircraftBiuletinModel> AircraftBiuletins { get; set; }

        public virtual ICollection<AircraftMaintenanceModel> AircraftMaintenances { get; set; }

        public virtual ICollection <AircraftStatusModel> AircraftStatuses { get; set; }

        public virtual ICollection<AlternatorModel> Alternators { get; set; }

        public virtual ICollection<BatteryModel> Batteries { get; set; }

        public virtual ICollection<CountryModel> Countries { get; set; }
        public virtual ICollection<EgpwsDatabaseModel> EgpwsDatabase { get; set; }

        public virtual ICollection<EltFunctionalTestModel> EltFunctionalTest { get; set; }

        public virtual ICollection<EltOperationalTestModel> EltOperationalTest { get; set; }

        public virtual ICollection<EmergencyLightsBatteryModel> EmergencyLightsBatteries { get; set; }

        public virtual ICollection<FdrReadModel> FdrRead { get; set; }

        public virtual ICollection<FlightModel> Flights { get; set; }

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

        public virtual ICollection<SettingsModel> Settings { get; set; }
    }
}
