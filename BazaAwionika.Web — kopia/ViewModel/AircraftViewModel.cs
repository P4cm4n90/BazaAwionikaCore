using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BazaAwionika.Model;

namespace BazaAwionika.Web.ViewModel
{
    public class AircraftViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nalot")]
        public int FlightHours { get; set; }

        [Display(Name = "Nr. ogonowy")]
        public string TailNumber { get; set; }

        [Display(Name = "Nr. ogonowy")]
        public string SerialNumber { get; set; }

        [Display(Name = "Informacje")]
        public string AdditionalInfo { get; set; }
        [Display(Name = "Położenie")]
        public string Location { get; set; }

        [Display(Name = "Data nalotu")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateFlightHours { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh.mm dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateAdd { get; set; }

        #region Related to other tables
        [Display(Name = "Data wylotu")]
        [DisplayFormat(DataFormatString = "{0:hh.mm dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateStart { get; set; }

        [Display(Name = "Data powrotu")]
        [DisplayFormat(DataFormatString = "{0:hh.mm dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateEnd { get; set; }

        [Display(Name = "Miejsce pobytu")]
        public string AircraftLocationName { get; set; }
        [Display(Name = "Status")]
        public string AircraftStatusName { get; set; }

        public int? AircraftStatusId { get; set; }

        public int? UserId { get; set; }


        #endregion




    }
}

