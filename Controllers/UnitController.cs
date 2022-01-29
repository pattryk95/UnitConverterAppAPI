using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UnitConverterAppAPI.Entities;
using UnitConverterAppAPI.Models;
using UnitConverterAppAPI.Services;

namespace UnitConverterAppAPI.Controllers
{
    [Route("api/unit")]
    public class UnitController : ControllerBase
    {
        private readonly UnitConverterDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UnitDto>> GetAll()
        {
            var unitsDtos = _unitService.GetAll();

            return Ok(unitsDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<Unit> Get([FromRoute] int id)
        {
            var unitDto = _unitService.GetById(id);

            if (unitDto == null) return NotFound();

            return Ok(unitDto);
        }

        [HttpPost]
        public ActionResult AddNewUnit([FromBody] CreateUnitDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _unitService.Create(dto);

            return Created($"/api/unit/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUnit([FromRoute] int id)
        {
           var isDeleted = _unitService.Delete(id);
            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult EditUnit([FromRoute] int id, [FromBody] UpdateUnitDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var isEdited = _unitService.Edit(id, dto);

            if (!isEdited)
            {
                return NotFound();
            }
            return Ok();
            
        }
    }
}
