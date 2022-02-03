using Microsoft.AspNetCore.Identity;
using UnitConverterAppAPI.Entities;
using UnitConverterAppAPI.Models;

namespace UnitConverterAppAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly UnitConverterDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountService(UnitConverterDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }
        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                Email = dto.Email,
                NickName = dto.NickName,
                RoleId = dto.RoleId

            };
            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);
            newUser.PasswordHash = hashedPassword;
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
    }
}
