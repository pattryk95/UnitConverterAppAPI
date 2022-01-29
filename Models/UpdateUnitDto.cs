using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UnitConverterAppAPI.Models
{
    public class UpdateUnitDto
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        [Precision(38, 19)]
        public decimal Factor { get; set; }
    }
}
