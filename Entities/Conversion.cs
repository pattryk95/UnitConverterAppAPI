using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnitConverterAppAPI.Entities
{
    public class Conversion
    {
        public int Id { get; set; }
        [Required]
        [Precision(38,19)]
        public decimal ConvertedValue { get; set; }
        [Required]
        [Precision(38, 19)]
        public decimal FinalValue { get; set; }
        public DateTime DateOfConversion { get; set; } = DateTime.Now;

        [ForeignKey("OriginalUnit")]
        [Required]
        public int OriginalUnitId { get; set; }
        [ForeignKey("TargetUnit")]
        [Required]
        public int TargetUnitId { get; set; }

        
        public virtual Unit OriginalUnit { get; set; }
        public virtual Unit TargetUnit { get; set; }
    }
}
