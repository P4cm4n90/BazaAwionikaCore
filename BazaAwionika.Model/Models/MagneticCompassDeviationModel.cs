namespace BazaAwionika.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("MagneticCompassDeviation")]
    public partial class MagneticCompassDeviationModel
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{dd.MM.yyyy}")]
        public DateTime DateExecution { get; set; }

        [Column(TypeName = "text")]
        [StringLength(50)]
        public string Performer { get; set; }

        public bool IsActual { get; set; } = false;

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
