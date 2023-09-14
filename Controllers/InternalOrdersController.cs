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
    public class InternalOrdersController : ControllerBase
    {
        private readonly FdwmrdjxContext _context;

        public InternalOrdersController(FdwmrdjxContext context)
        {
            _context = context;
        }

        // GET: api/InternalOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InternalOrder>>> GetInternalOrders()
        {
            if (_context.InternalOrders == null)
            {
                return NotFound();
            }
            return await _context.InternalOrders.ToListAsync();
        }

        // GET: api/InternalOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InternalOrder>> GetInternalOrder(decimal id)
        {
            if (_context.InternalOrders == null)
            {
                return NotFound();
            }
            var internalOrder = await _context.InternalOrders.FindAsync(id);

            if (internalOrder == null)
            {
                return NotFound();
            }

            return internalOrder;
        }

        // PUT: api/InternalOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[Route("updateinfo")]
        [HttpPut("{id}/updateinfo")]
        public async Task<IActionResult> PutInternalOrder(decimal id, InternalOrder internalOrder)
        {
            if (id != internalOrder.IntOrderid)
            {
                return BadRequest();
            }

            _context.Entry(internalOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InternalOrderExists(id))
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
      
        [HttpPut("{id}/update")]
        //made by saurav

        public async Task<IActionResult> updateOrderConfirmed(decimal id)
        {
            if (_context.InternalOrders == null)
            {
                return Problem("Entity set 'FdwmrdjxContext.InternalOrders'  is null.");
            }

            var internalOder = await _context.InternalOrders.FindAsync(id);
            internalOder.OrderConfirmed = true;
            try
            {

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;

            }
            return Ok();        



        }

        [HttpPut("{id}/updateproduct")]
        //made by BTuncle

        public async Task<IActionResult> updateProductDelivered(decimal id)
        {
            if (_context.InternalOrders == null)
            {
                return Problem("Entity set 'FdwmrdjxContext.InternalOrders'  is null.");
            }

            var internalOder = await _context.InternalOrders.FindAsync(id);
            internalOder.ProductDelivered = true;
            try
            {

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;

            }
            return Ok();

        }

        [HttpPut("{id}/updateorderdispatched")]
        //made by BTuncle

        public async Task<IActionResult> updateOrderDispatched(decimal id)
        {
            if (_context.InternalOrders == null)
            {
                return Problem("Entity set 'FdwmrdjxContext.InternalOrders'  is null.");
            }

            var internalOder = await _context.InternalOrders.FindAsync(id);
            internalOder.OrderDispatched = true;
            try
            {

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;

            }
            return Ok();

        }

        // POST: api/InternalOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InternalOrder>> PostInternalOrder(InternalOrder internalOrder)
        {
          if (_context.InternalOrders == null)
          {
              return Problem("Entity set 'FdwmrdjxContext.InternalOrders'  is null.");
          }
            _context.InternalOrders.Add(internalOrder);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InternalOrderExists(internalOrder.IntOrderid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInternalOrder", new { id = internalOrder.IntOrderid }, internalOrder);
        }

       

        // DELETE: api/InternalOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInternalOrder(decimal id)
        {
            if (_context.InternalOrders == null)
            {
                return NotFound();
            }
            var internalOrder = await _context.InternalOrders.FindAsync(id);
            if (internalOrder == null)
            {
                return NotFound();
            }

            _context.InternalOrders.Remove(internalOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InternalOrderExists(decimal id)
        {
            return (_context.InternalOrders?.Any(e => e.IntOrderid == id)).GetValueOrDefault();
        }
    }
}
