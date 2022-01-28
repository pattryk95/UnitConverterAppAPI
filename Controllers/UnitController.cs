using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UnitConverterAppAPI.Entities;
using UnitConverterAppAPI.Models;

namespace UnitConverterAppAPI.Controllers
{
    [Route("api/unit")]
    public class UnitController : ControllerBase
    {
        private readonly UnitConverterDbContext _dbContext;
        private readonly IMapper _mapper;

        public UnitController(UnitConverterDbContext _dbContext, IMapper mapper)
        {
            this._dbContext = _dbContext;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<UnitDto>> GetAll()
        {
            var units = _dbContext.Units.ToList();

            var unitsDtos = _mapper.Map<List<UnitDto>>(units);

            return Ok(unitsDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<Unit> Get([FromRoute] int id)
        {
            var unit = _dbContext.Units.FirstOrDefault(x => x.Id == id);

            if (unit is null)
            {
                return NotFound();
            }
            var unitDto = _mapper.Map<UnitDto>(unit);
            return Ok(unitDto);
        }

        [HttpPost]
        public ActionResult AddNewUnit([FromBody] CreateUnitDto dto)
        {
            var unit = _mapper.Map<Unit>(dto);
            _dbContext.Units.Add(unit);
            _dbContext.SaveChanges();

            return Created($"/api/unit/{unit.Id}", null);
        }
    }
}
