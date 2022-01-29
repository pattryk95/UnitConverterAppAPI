using AutoMapper;
using UnitConverterAppAPI.Entities;
using UnitConverterAppAPI.Models;

namespace UnitConverterAppAPI.Services
{
    public class UnitService : IUnitService
    {
        private readonly UnitConverterDbContext _dbContext;
        private readonly IMapper _mapper;

        public UnitService(UnitConverterDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public UnitDto GetById(int id)
        {
            var unit = _dbContext.Units.FirstOrDefault(x => x.Id == id);

            if (unit is null) return null;

            var result = _mapper.Map<UnitDto>(unit);
            return result;
        }

        public IEnumerable<UnitDto> GetAll()
        {
            var units = _dbContext.Units.ToList();

            var unitDtos = _mapper.Map<List<UnitDto>>(units);
            return unitDtos;
        }

        public int Create(CreateUnitDto dto)
        {
            var unit = _mapper.Map<Unit>(dto);
            _dbContext.Units.Add(unit);
            _dbContext.SaveChanges();

            return unit.Id;
        }

        public bool Delete(int id)
        {
            var unit = _dbContext.Units.FirstOrDefault(x => x.Id == id);

            if (unit is null) return false;

            _dbContext.Units.Remove(unit);
            _dbContext.SaveChanges();
            return true;


        }

        public bool Edit(int id, UpdateUnitDto dto)
        {
            var unit = _dbContext.Units.FirstOrDefault(x => x.Id == id);
            if (unit is null) return false;

            unit.Name = dto.Name;
            unit.Factor = dto.Factor;

            _dbContext.SaveChanges();

            return true;


        }
    }
}
