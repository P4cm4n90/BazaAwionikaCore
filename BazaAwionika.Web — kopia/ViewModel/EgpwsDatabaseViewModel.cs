using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BazaAwionika.Web.ViewModel
{ 

    public partial class EgpwsDatabaseViewModel
    {
      
        public int Id { get; set; }

        public DateTime DateExpiration { get; set; }

        public string DatabaseName { get; set; }

        public bool IsActual { get; set; } = false;

        [DisplayFormat(DataFormatString = "{0:hh.mm dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateAdd { get; set; }

        #region Related to other tables

        public int AircraftId { get; set; }

        public string AircraftName { get; set; }

        public int? SettingsId { get; set; }

        public int? SettingsServicePeriodTimeMonths { get; set; }

        public int? SettingsDaysCaution { get; set; }

        public int? SettingsDaysWarning { get; set; }

        public int? SettingsDaysError { get; set; }

        public int? UserId { get; set; }

        public string UserName { get; set; }

        #endregion

        #region additional properties

        public int DaysRemaining
        {
            get
            {
                return (int)(DateExpiration - DateTime.Now.Date).TotalDays;
            }
        }

        public MaintStatus MaintStatus
        {
            get
            {
                if (!IsActual)
                    return MaintStatus.Unknown;
                if (DaysRemaining <= SettingsDaysError)
                    return MaintStatus.Error;
                if (DaysRemaining <= SettingsDaysWarning)
                    return MaintStatus.Warning;
                if (DaysRemaining <= SettingsDaysCaution)
                    return MaintStatus.Caution;
                else return MaintStatus.Ok;
            }
        }

        #endregion


    }
}
