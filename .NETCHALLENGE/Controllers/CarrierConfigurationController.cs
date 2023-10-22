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
    [Route("api/CarrierConfigurationAPI")]
    [ApiController]
    public class CarrierConfigurationController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public CarrierConfigurationController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<CarrierConfiguration>> GetCarrierConfigurations()
        {

            return Ok(_db.CarrierConfigurations.ToList());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Carrier> CreateCarrierConfigurations([FromBody] CarrierConfiguration carrierConfiguration)
        {
           
            if (carrierConfiguration == null)
            {
                return BadRequest(carrierConfiguration);
            }
            if (carrierConfiguration.CarrierConfigurationId > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            _db.CarrierConfigurations.Add(carrierConfiguration);
            _db.SaveChanges();

            return CreatedAtRoute("GetCarrierConfigurations", new { id = carrierConfiguration.CarrierConfigurationId }, carrierConfiguration);

        }

        [HttpDelete("{id:int}", Name = "DeleteCarrierConfiguration")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteCarrierConfiguration(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var carrierConfiguration = _db.CarrierConfigurations.FirstOrDefault(u => u.CarrierConfigurationId == id);
            if (carrierConfiguration == null)
            {
                return NotFound();
            }
            _db.CarrierConfigurations.Remove(carrierConfiguration);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPost("{id:int}", Name = "UpdateCarrierConfiguration")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateCarrierConfiguration(int id, [FromBody] CarrierConfiguration carrierConfiguration)
        {
            if (carrierConfiguration == null || carrierConfiguration.CarrierConfigurationId != id)
            {
                return BadRequest();
            }
            _db.CarrierConfigurations.Update(carrierConfiguration);
            _db.SaveChanges();
            return NoContent();

        }
    }
}

