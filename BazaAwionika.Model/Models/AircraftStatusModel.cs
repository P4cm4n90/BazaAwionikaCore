using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BazaAwionika.Model
{
    [Table("AircraftStatus")]
    public class AircraftStatusModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<AircraftModel> Aircrafts { get; set; }

        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserModel User { get; set; }
    }
}