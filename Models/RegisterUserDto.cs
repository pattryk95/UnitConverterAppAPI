using System.ComponentModel.DataAnnotations;

namespace UnitConverterAppAPI.Models
{
    public class RegisterUserDto
    {
       // [Required]
        public string Email { get; set; }
      //  [Required]
      //  [MinLength(6)]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string NickName { get; set; }
        public int RoleId { get; set; } = 1;
    }
}
