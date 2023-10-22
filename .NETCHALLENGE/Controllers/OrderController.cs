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
    [Route("api/OrderAPI")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly CarrierConfiguration _carrierConfiguration;

        public OrderController(ApplicationDbContext db,CarrierConfiguration carrierConfiguration)
        {
            _db = db;
            _carrierConfiguration = carrierConfiguration;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {

            return Ok(_db.Orders.ToList());
        }

        [HttpPost("{desi:int}", Name = "CreateOrder")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Carrier> CreateOrder([FromBody] Order order,int desi)
        {

            if (order == null)
            {
                return BadRequest(order);
            }
            if (order.OrderId > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            var a = _db.CarrierConfigurations.FirstOrDefault(u => u.CarrierMinDesi <= desi);
            var b = _db.CarrierConfigurations.FirstOrDefault(u => u.CarrierMaxDesi > desi);

            if (a == b)
            {
                order.CarrierId = a.carrierId;
                order.OrderCarierCost = a.CarrierCost;
            }



            _db.Orders.Add(order);
            _db.SaveChanges();

            return CreatedAtRoute("GetOrders", new { id = order.OrderId }, order);

        }

        [HttpDelete("{id:int}", Name = "DeleteOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteOrder(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var order = _db.Orders.FirstOrDefault(u => u.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            _db.Orders.Remove(order);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPost("{id:int}", Name = "UpdateOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateOrder(int id, [FromBody] Order order,int desi)
        {
            if (order == null || order.OrderId != id)
            {
                return BadRequest();
            }

            var a = _db.CarrierConfigurations.FirstOrDefault(u => u.CarrierMinDesi <= desi);
            var b = _db.CarrierConfigurations.FirstOrDefault(u => u.CarrierMaxDesi > desi);

            if (a == b)
            {
                order.CarrierId = a.carrierId;
                order.OrderCarierCost = a.CarrierCost;
            }

            _db.Orders.Update(order);
            _db.SaveChanges();
            return NoContent();

        }
    }
}

