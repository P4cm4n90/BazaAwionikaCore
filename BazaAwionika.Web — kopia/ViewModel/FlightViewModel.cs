using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaAwionika.Web.ViewModel
{ // TODO: opracować bo nic nie zrobione prawie
    public class FlightViewModel
    {
        public int Id { get; set; }

        public DateTime DateTimeStart { get; set; }

        public DateTime DateTimeEnd { get; set; }

        
        [DisplayFormat(DataFormatString = "{0:hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Start")]
        [NotMapped]
        public DateTime TimeStart
        {
            get
            {
                return DateTimeStart;
            }
        }

        
        [DisplayFormat(DataFormatString = "{0:hh:mm}")]
        [DataType(DataType.Date)]
        [Display(Name = "Powrót")]
        [NotMapped]
        public DateTime TimeEnd
        {
            get
            {
                return DateTimeEnd;
            }
        }
        public string Destination { get; set; }

        public string AdditionalInfo { get; set; }

        public int AircraftId { get; set; } 

        public virtual AircraftViewModel Aircraft { get; set; }

    }
}
/*
 * 
        public EltFunctionalTestModel()
        {
      
        }
        [Key]
        public int Id { get; set; }


        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Data ważnosći")]
        public DateTime DateExpiration { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Data wykonania")]
        public DateTime DateExecution { get; set; }
        
        [Display(Name = "Wpis aktualny?")]
        public bool IsActual { get; set; } = false;

        [Display(Name = "Nr. boczny samolotu")]

        public int AircraftId { get; set; }

        [Display(Name = "Data modyfikacji")]
        
        [DisplayFormat(DataFormatString = "{0:hh.mm dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateAdd { get; set; }


        [Display(Name = "Użytkownik")]
        public int? UserId { get; set; }

        public int? SettingsId { get; set; }

        [ForeignKey("SettingsId")]
        public virtual SettingsModel Settings { get; set; }
        [ForeignKey("AircraftId")]
        public virtual AircraftModel Aircraft { get; set; }
        [ForeignKey("UserId")]
        public virtual UserModel Users { get; set; }

    }
 */
