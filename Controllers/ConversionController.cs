using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UnitConverterAppAPI.Models;
using UnitConverterAppAPI.Services;

namespace UnitConverterAppAPI.Controllers
{
    [Route("api/conversion")]
    [ApiController]
    //[Authorize]
    public class ConversionController : ControllerBase
    {
        private readonly IConversionService _conversionService;

        public ConversionController(IConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        [HttpPost]
        public ActionResult CreateConversion([FromBody] CreateConversionDto dto)
        {
           var newConversionId = _conversionService.Create(dto);

            return Created($"api/conversion/{newConversionId}", null);
        }

        [HttpGet("{conversionId}")]
        public ActionResult<ConversionDto> Get([FromRoute] int conversionId)
        {
            var conversionDto = _conversionService.GetById(conversionId);
            return Ok(conversionDto);
        }

        [HttpGet]
        //[AllowAnonymous]
        public ActionResult<IEnumerable<ConversionDto>> GetAll()
        {
            var conversionDtos = _conversionService.GetAll();
            return Ok(conversionDtos);
        }

        [HttpDelete]
        [Authorize(Roles = "Admmin")]
        public ActionResult DeleteConversions()
        {
            _conversionService.RemoveAll();
            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteConversion([FromRoute] int id)
        {
            _conversionService.DeleteConversion(id);
            return NoContent();
        }

    }
}
