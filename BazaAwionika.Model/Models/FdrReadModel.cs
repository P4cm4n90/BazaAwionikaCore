namespace BazaAwionika.Model

{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FdrRead")]
    public partial class FdrReadModel
    {
      
        [Key]
        public int Id { get; set; }

        [Required]
        public int FlightHoursExecution { get; set; }

        public int FlightHours { get; set; }

        [Display(Name = "Data modyfikacji")]
        
        [DisplayFormat(DataFormatString = "{0:hh.mm dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateExecution { get; set; }

        public bool IsActual { get; set; } = false;

        [MaxLength(50)]
        public string AdditionalInformation { get; set; }

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
        public virtual UserModel User { get; set; }


    }
}
