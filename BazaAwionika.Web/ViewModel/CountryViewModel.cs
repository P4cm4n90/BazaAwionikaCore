using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaAwionika.Web.ViewModel
{

    public class CountryViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int GipsenDatabaseId { get; set; }

        public virtual GipsenDatabaseViewModel GipsenDatabase { get; set; }
    }
}
