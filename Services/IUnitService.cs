using UnitConverterAppAPI.Models;

namespace UnitConverterAppAPI.Services
{
    public interface IUnitService
    {
        int Create(CreateUnitDto dto);
        void Delete(int id);
        void Edit(int id, UpdateUnitDto dto);
        PageResult<UnitDto> GetAll(UnitQuery query);
        UnitDto GetById(int id);
    }
}