namespace BazaAwionika.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
 

    [Table("Alternator")]
    public partial class AlternatorModel
    {
      
        [Key]
        public int Id { get; set; }

        public int FlightHoursOverhaul { get; set; }

        public int FlightHoursAircraftInstallation { get; set; }

        public int FlightHours { get; set; }

        [MaxLength(100)]
        public string AdditionalInformation { get; set; }
        [Required]
        [MaxLength(50)]
        public string SerialNumber { get; set; }

        public bool IsInstalled { get; set; } = false;
        
        public bool IsActual { get; set; } = false;

        [Column(TypeName = "smalldatetime")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Data modyfikacji")]
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

        //public virtual ICollection<AlternatorHistoryModel> AlternatorHistory { get; set; }

    }
}
