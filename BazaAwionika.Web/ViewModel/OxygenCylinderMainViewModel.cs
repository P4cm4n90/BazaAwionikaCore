using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BazaAwionika.Web.ViewModel
{

    public partial class OxygenCylinderMainViewModel
    {
        public int Id { get; set; }

        public DateTime DateExpiration { get; set; }

        public DateTime DateDiscard { get; set; }

        public string SerialNumber { get; set; }

        public string AdditionalInformation { get; set; }

        public bool IsInstalled { get; set; }

        public bool IsActual { get; set; } = false;

        [DisplayFormat(DataFormatString = "{0:hh.mm dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateAdd { get; set; }

        #region Related to other tables

        public int AircraftId { get; set; }

        public string AircraftName { get; set; }

        public int? SettingsId { get; set; }

        public int? SettingsDaysCaution { get; set; }

        public int? SettingsDaysWarning { get; set; }

        public int? SettingsDaysError { get; set; }

        public int? UserId { get; set; }

        public string UserName { get; set; }

        #endregion

        #region additional properties

        public int? DaysRemaining
        {
            get
            {
                return (int)(DateExpiration - DateTime.Now.Date).TotalDays;
            }
        }

        public int? DaysDiscardRemaining
        {
            get
            {
                return (int)(DateDiscard - DateTime.Now.Date).TotalDays;
            }
        }

        public MaintStatus MaintStatus
        {
            get
            {
                if (!IsActual)
                    return MaintStatus.Unknown;
                int? days = DaysRemaining < DaysDiscardRemaining ? DaysRemaining : DaysDiscardRemaining;
                if (days  <= SettingsDaysError)
                    return MaintStatus.Error;
                if (days <= SettingsDaysWarning)
                    return MaintStatus.Warning;
                if (days <= SettingsDaysCaution)
                    return MaintStatus.Caution;
                else return MaintStatus.Ok;
            }
        }


        #endregion

    }
}
