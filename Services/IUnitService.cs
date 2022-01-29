using UnitConverterAppAPI.Models;

namespace UnitConverterAppAPI.Services
{
    public interface IUnitService
    {
        int Create(CreateUnitDto dto);
        void Delete(int id);
        void Edit(int id, UpdateUnitDto dto);
        IEnumerable<UnitDto> GetAll();
        UnitDto GetById(int id);
    }
}