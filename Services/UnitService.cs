using AutoMapper;
using System.Linq;
using System.Linq.Expressions;
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
            var unit = GetUnit(id);

            var result = _mapper.Map<UnitDto>(unit);
            return result;
        }

        public PageResult<UnitDto> GetAll(UnitQuery query)
        {
            var baseQuery = _dbContext
                .Units
                .Where(u => query.SearchPhrase == null || (u.Name.ToLower().Contains(query.SearchPhrase.ToLower())));


            if (!string.IsNullOrEmpty(query.SortBy))
            {
                var columnsSelectors = new Dictionary<string, Expression<Func<Unit, object>>>
                {
                    {nameof(Unit.Name), u => u.Name}
                };

                var selectedColumn = columnsSelectors[query.SortBy];

                baseQuery = query.SortDirection == SortDirection.ASC ? baseQuery.OrderBy(selectedColumn) : baseQuery.OrderByDescending(selectedColumn);
            }

            var units = baseQuery
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Take(query.PageSize)
                .ToList();

            var totalItemsCount = baseQuery.Count();

            var unitDtos = _mapper.Map<List<UnitDto>>(units);

            var result = new PageResult<UnitDto>(unitDtos, totalItemsCount, query.PageSize, query.PageNumber);

            return result;
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
            var unit = GetUnit(id);

            _dbContext.Units.Remove(unit);
            _dbContext.SaveChanges();
        }

        public void Edit(int id, UpdateUnitDto dto)
        {
            var unit = GetUnit(id);

            unit.Name = dto.Name;
            unit.Factor = dto.Factor;

            _dbContext.SaveChanges();


        }

        private Unit GetUnit(int id)
        {
            var unit = _dbContext.Units.FirstOrDefault(x => x.Id == id);
            if (unit is null)
            {
                throw new NotFoundException("Unit not found");
            }

            return unit;
        }
    }
}
