using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BazaAwionika.Model
{
    [Table("AircraftMaintenance")]
    public class AircraftMaintenanceModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Nazwa prac")]
        public string Name { get; set; }

        
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Data ważnosći")]
        public DateTime DateExpiration { get; set; }

        [Column(TypeName = "smalldatetime")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Data wykonania")]
        public DateTime DateExecution { get; set; }

        public bool IsActual { get; set; } = false;

        [MaxLength(100)]
        public string AdditionalInformation { get; set; }

        public int AircraftId { get; set; }

        public int UserId { get; set; }

        public int SettingsId { get; set; }

        [ForeignKey("AircraftId")]
        public virtual AircraftModel Aircraft { get; set; }

        [ForeignKey("UserId")]
        public virtual UserModel User { get; set; }

        [ForeignKey("SettingsId")]
        public virtual SettingsModel Settings { get; set; }
    }
}