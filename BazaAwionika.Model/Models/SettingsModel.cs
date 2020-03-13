namespace BazaAwionika.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Settings")]
    public partial class SettingsModel
    {

        [Key]
        public int Id { get; set; }

        public short? ServicePeriodFlightHours { get; set; }

        public short? ServicePeriodTimeMonths { get; set; }

        [Required]
        [MaxLength(50)]
        public string SettingsName { get; set; }
        [Display(Name = "Nalot upomnienie")]
        public short? FlightHoursCaution { get; set; }
        [Display(Name = "Nalot ostrze¿enie")]
        public short? FlightHoursWarning { get; set; }
        [Display(Name = "Nalot przekroczony")]
        public short? FlightHoursError { get; set; }

        [Display(Name = "Dni upomnienie")]
        public short? DaysCaution { get; set; }
        [Display(Name = "Dni ostrze¿enie")]
        public short? DaysWarning { get; set; }
        [Display(Name = "Dni przekroczenie")]
        public short? DaysError { get; set; }

        public int? UserId { get; set; }

        [Display(Name = "Data modyfikacji")]
        [Column(TypeName = "smalldatetime")]
        [DisplayFormat(DataFormatString = "{0:hh.mm dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateAdd { get; set; } = DateTime.Now;

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

        public virtual ICollection<UlbFdrModel> UlbFdr{ get; set; }

        public virtual ICollection<UlbTestModel> UlbTest { get; set; }

        [ForeignKey("UserId")]
        public virtual UserModel Users { get; set; }
    }
}
