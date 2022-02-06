using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnitConverterAppAPI.Entities;
using UnitConverterAppAPI.Models;
using UnitConverterAppAPI.Services;

namespace UnitConverterAppAPI.Controllers
{
    [Route("api/unit")]
    [ApiController] // automatically invoke ModelState.IsValid
    [Authorize(Roles = "Admmin")] //[Authorize] || [Authorize(Roles = "Admmin, Manager")] on Controller for all actions or for particular actions
    public class UnitController : ControllerBase
    {
        private readonly IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<UnitDto>> GetAll()
        {
            var unitsDtos = _unitService.GetAll();

            return Ok(unitsDtos);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<Unit> Get([FromRoute] int id)
        {
            var unitDto = _unitService.GetById(id);

            return Ok(unitDto);
        }

        [HttpPost]
       // [Authorize(Roles = "Admmin")]
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
