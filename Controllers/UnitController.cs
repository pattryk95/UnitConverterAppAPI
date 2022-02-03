using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UnitConverterAppAPI.Entities;
using UnitConverterAppAPI.Models;
using UnitConverterAppAPI.Services;

namespace UnitConverterAppAPI.Controllers
{
    [Route("api/unit")]
    [ApiController] // automatically invoke ModelState.IsValid
    public class UnitController : ControllerBase
    {
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

            return Ok(unitDto);
        }

        [HttpPost]
        public ActionResult AddNewUnit([FromBody] CreateUnitDto dto)
        {
            var id = _unitService.Create(dto);

            return Created($"/api/unit/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUnit([FromRoute] int id)
        {
            _unitService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult EditUnit([FromRoute] int id, [FromBody] UpdateUnitDto dto)
        {
           _unitService.Edit(id, dto);
            return Ok();
            
        }
    }
}
