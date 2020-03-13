namespace BazaAwionika.Model




{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Generator")]
    public partial class GeneratorModel
    {
     
        [Key]
        public int Id{ get; set; }

        public int FlightHours { get; set; }
        [Required]
        public int FlightHoursBrushes { get; set; }
        [Required]
        public int FlightHoursBearing { get; set; }
        [Required]
        public int FlightHoursOverhaul { get; set; }
        [Required]
        public int FlightHoursAircraftInstallation { get; set; }

        [Required]
        [StringLength(50)]
        public string SerialNumber { get; set; }


        [StringLength(50)]
        public string AdditionalInformation { get; set; }

        public bool? IsActual { get; set; }

        public bool IsInstalled { get; set; } = false;

        [Display(Name = "Data modyfikacji")]
        [Column(TypeName = "smalldatetime")]
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
        public virtual UserModel Users { get; set; }

    }
}
