using Microsoft.AspNetCore.Mvc;
using UnitConverterAppAPI.Entities;

namespace UnitConverterAppAPI.Controllers
{
    [Route("api/unitconverter")]
    public class UnitConverterController : ControllerBase
    {
        private readonly UnitConverterDbContext _dbContext;

        public UnitConverterController(UnitConverterDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public ActionResult<IEnumerable<Unit>> GetAll()
        {
            var units = _dbContext.Units.ToList();

            return Ok(units);
        }
    }
}
