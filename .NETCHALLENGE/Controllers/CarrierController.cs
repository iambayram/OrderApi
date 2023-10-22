using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _NETCHALLENGE.Data;
using _NETCHALLENGE.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _NETCHALLENGE.Controllers
{
    [Route("api/CarrierAPI")]
    [ApiController]
    public class CarrierController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public CarrierController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Carrier>> GetCarriers()
        {

            return Ok(_db.Carriers.ToList());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Carrier> CreateCarrier([FromBody] Carrier carrier)
        {
            
            if (carrier == null)
            {
                return BadRequest(carrier);
            }
            if (carrier.CarrierId > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            _db.Carriers.Add(carrier);
            _db.SaveChanges();

            return CreatedAtRoute("GetCarriers", new { id = carrier.CarrierId }, carrier);

        }

        [HttpDelete("{id:int}", Name = "DeleteCarrier")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteCarrier(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var carrier = _db.Carriers.FirstOrDefault(u => u.CarrierId == id);
            if (carrier == null)
            {
                return NotFound();
            }
            _db.Carriers.Remove(carrier);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPost("{id:int}", Name = "UpdateCarrier")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateCarrier(int id, [FromBody] Carrier carrier)
        {
            if (carrier == null || carrier.CarrierId != id)
            {
                return BadRequest();
            }
            _db.Carriers.Update(carrier);
            _db.SaveChanges();
            return NoContent();

        }
    }
}
