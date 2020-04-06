namespace BazaAwionika.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Battery")]
    public partial class BatteryModel
    {
        
        public BatteryModel()
        {

        }
        [Key]
        public int Id { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Data wykonania")]
        public DateTime DateExecution { get; set; }

        public int FlightHoursExecution { get; set; }

        public int FlightHoursAircraftInstallation { get; set; }

        public int FlightHours { get; set; }

        [MaxLength(50)]
        public string SerialNumber { get; set; }

        [MaxLength(50)]
        public string AdditionalInformation { get; set; }

        public bool IsActual { get; set; } = false;

        public bool IsInstalled { get; set; } = false;

        [Display(Name = "Data modyfikacji")]
        [DisplayFormat(DataFormatString = "{0:hh.mm dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateAdd { get; set; } = DateTime.Now;

        public int AircraftId { get; set; }

        public int? UserId { get; set; }

        public int? SettingsId { get; set; }


        [ForeignKey("SettingsId")]
        public virtual SettingsModel Settings { get; set; }
        [ForeignKey("AircraftId")]
        public virtual AircraftModel Aircraft { get; set; }
        [ForeignKey("UserId")]
        public virtual UserModel User { get; set; }

    }
}
