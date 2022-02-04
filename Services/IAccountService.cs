using UnitConverterAppAPI.Models;

namespace UnitConverterAppAPI.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
        string GenerateJwt(LoginDto dto);
    }
}