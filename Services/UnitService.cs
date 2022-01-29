using AutoMapper;
using UnitConverterAppAPI.Entities;
using UnitConverterAppAPI.Exceptions;
using UnitConverterAppAPI.Models;

namespace UnitConverterAppAPI.Services
{
    public class UnitService : IUnitService
    {
        private readonly UnitConverterDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<UnitService> _logger;

        public UnitService(UnitConverterDbContext dbContext, IMapper mapper, ILogger<UnitService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }
        public UnitDto GetById(int id)
        {
            var unit = _dbContext.Units.FirstOrDefault(x => x.Id == id);

            if (unit is null)
            {
                throw new NotFoundException("Restaurant not found");
            }

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

        public void Delete(int id)
        {
            _logger.LogError($"Unit with id: {id} DELETE action invoked");
            var unit = _dbContext.Units.FirstOrDefault(x => x.Id == id);

            if (unit is null)
            {
                throw new NotFoundException("Unit not found");
            }

            _dbContext.Units.Remove(unit);
            _dbContext.SaveChanges();
        }

        public void Edit(int id, UpdateUnitDto dto)
        {
            var unit = _dbContext.Units.FirstOrDefault(x => x.Id == id);
            if (unit is null) 
            {
                throw new NotFoundException("Unit not found");
            }

            unit.Name = dto.Name;
            unit.Factor = dto.Factor;

            _dbContext.SaveChanges();


        }
    }
}
