using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BazaAwionika.Web.ViewModel
{
    public partial class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Password { get; set; }

        public string AdditionalInformation { get; set; }

        public bool AdminPriviliges { get; set; }

    }
}
