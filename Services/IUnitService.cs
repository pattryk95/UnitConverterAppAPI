using UnitConverterAppAPI.Models;

namespace UnitConverterAppAPI.Services
{
    public interface IUnitService
    {
        int Create(CreateUnitDto dto);
        bool Delete(int id);
        bool Edit(int id, UpdateUnitDto dto);
        IEnumerable<UnitDto> GetAll();
        UnitDto GetById(int id);
    }
}