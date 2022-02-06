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
        public decimal ConversionResult { get; set; }
        public DateTime DateOfConversion { get; set; } = DateTime.Now;
        public int? CreatedById { get; set; }
        public virtual User CreatedBy { get; set; }


        [ForeignKey("OriginalUnit")]
        [Required]
        public int OriginalUnitId { get; set; }
        public virtual Unit OriginalUnit { get; set; }

        [ForeignKey("TargetUnit")]
        [Required]
        public int TargetUnitId { get; set; }
        public virtual Unit TargetUnit { get; set; }

        
    }
}
