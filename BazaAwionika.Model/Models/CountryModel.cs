using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaAwionika.Model
{
    [Table("Country")]
    public class CountryModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        public int GipsenDatabaseId { get; set; }

        public int UserId { get; set; }

        [ForeignKey("GipsenDatabaseId")]
        public virtual GipsenDatabaseModel GipsenDatabase { get; set; }

        [ForeignKey("UserId")]
        public virtual UserModel User { get; set; }
    }
}
