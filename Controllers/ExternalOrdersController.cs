using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Petrol_Pump1.ModelPostgres;

namespace Petrol_Pump1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalOrdersController : ControllerBase
    {
        private  FdwmrdjxContext _context;

        public ExternalOrdersController(FdwmrdjxContext context)
        {
            _context = context;
        }

        // GET: api/ExternalOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExternalOrder>>> GetExternalOrders()
        {
          if (_context.ExternalOrders == null)
          {
              return NotFound();
          }
            return await _context.ExternalOrders.ToListAsync();
        }

        // GET: api/ExternalOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExternalOrder>> GetExternalOrder(decimal id)
        {
          if (_context.ExternalOrders == null)
          {
              return NotFound();
          }
            var externalOrder = await _context.ExternalOrders.FindAsync(id);

            if (externalOrder == null)
            {
                return NotFound();
            }

            return externalOrder;
        }

        // PUT: api/ExternalOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExternalOrder(decimal id, ExternalOrder externalOrder)
        {
            if (id != externalOrder.ExtOrderid)
            {
                return BadRequest();
            }

            _context.Entry(externalOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExternalOrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ExternalOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExternalOrder>> PostExternalOrder(ExternalOrder externalOrder)
        {
          if (_context.ExternalOrders == null)
          {
              return Problem("Entity set 'FdwmrdjxContext.ExternalOrders'  is null.");
          }


            var units = externalOrder.UnitsBought;

            var productid = externalOrder.ProductBought;

            var product = await _context.Products.FindAsync(productid);
            var units_stock = product.UnitsInStock;
            units_stock = (decimal)(units_stock - (units));
            Random random = new Random();

            if (units_stock < product.ThresholdUnits)
            {
                var internalorder = new InternalOrder
                {
                    IntOrderid = (int)random.NextDouble(),
                    SuppliedBy = product.SuppliedBy,
                    ProductBought = product.ProductId,
                    UnitsBought = product.ThresholdUnits * 5,
                    TotalPayable = units * product.PricePerUnit,
                    OrderConfirmed = false,
                    ProductDelivered = false,
                    OrderDispatched = false,
                    DateOrdered = DateOnly.FromDateTime(new DateTime())


                };


                var internalOrderControl = new InternalOrdersController(_context);
                await internalOrderControl.PostInternalOrder(internalorder);


            }

            _context.ExternalOrders.Add(externalOrder);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ExternalOrderExists(externalOrder.ExtOrderid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }


            return CreatedAtAction("GetExternalOrder", new { id = externalOrder.ExtOrderid }, externalOrder);
        }

       /* [HttpPost("{id}")]
        public async Task<ActionResult<ExternalOrder>> checkExternalOrder(ExternalOrder externalOrder)
        {
            if (_context.ExternalOrders == null)
            {
                return BadRequest();
            }
            else
            {
                
                if (ExternalOrder == null)
                {
                    return NotFound();
                }

                

                    

                    


               

                return Ok();

            }
        }*/

        // DELETE: api/ExternalOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExternalOrder(decimal id)
        {
            if (_context.ExternalOrders == null)
            {
                return NotFound();
            }
            var externalOrder = await _context.ExternalOrders.FindAsync(id);
            if (externalOrder == null)
            {
                return NotFound();
            }

            _context.ExternalOrders.Remove(externalOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExternalOrderExists(decimal id)
        {
            return (_context.ExternalOrders?.Any(e => e.ExtOrderid == id)).GetValueOrDefault();
        }
    }
}
