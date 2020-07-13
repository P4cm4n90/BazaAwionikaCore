using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BazaAwionika.Model
{
    [Table("AircraftBiuletin")]
    public class AircraftBiuletinModel
    {
        [Key]
        public int Id { get; set; }

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

        public int? FlightHoursExecution { get; set; }

        public int? FlightHoursExpiration { get; set; }

        public string AdditionalInformation { get; set; }

        public bool? IsRequired {get; set;}

        public bool IsActual { get; set; } = false;

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