using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnitConverterAppAPI.Models
{
    public class CreateConversionDto
    {
        [Required]
        [Precision(38, 19)]
        public decimal ConvertedValue { get; set; }
        [Required]
        [Precision(38, 19)]
        public decimal ConversionResult { get; set; }
        public DateTime DateOfConversion { get; set; } = DateTime.Now;

        [Required]
        public int OriginalUnitId { get; set; }
        [Required]
        public int TargetUnitId { get; set; }
    }
}
