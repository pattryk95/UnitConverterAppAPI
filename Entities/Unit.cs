
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UnitConverterAppAPI.Entities
{
    public class Unit
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        [Precision(38, 19)]
        public decimal Factor { get; set; }

       // public virtual ICollection<Conversion> OriginalUnitConversions { get; set; }
      //  public virtual ICollection<Conversion> TargetUnitConversions { get; set; }
    }
}
