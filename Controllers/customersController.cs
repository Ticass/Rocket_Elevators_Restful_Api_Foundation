using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class customersController : ControllerBase
    {
        private readonly MysqlContext _context;

        public customersController(MysqlContext context)
        {
            _context = context;
        }

        // GET: api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<customers>>> Getcustomers()
        {
            return await _context.customers.ToListAsync();
        }

        // GET: api/customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<customers>> Getcustomers(long id)
        {
            var customers = await _context.customers.FindAsync(id);

            if (customers == null)
            {
                return NotFound();
            }

            return customers;
        }

        // PUT: api/customers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcustomers(long id, customers customers)
        {
            if (id != customers.id)
            {
                return BadRequest();
            }

            _context.Entry(customers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!customersExists(id))
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

        // POST: api/customers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<customers>> Postcustomers(customers customers)
        {
            _context.customers.Add(customers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcustomers", new { id = customers.id }, customers);
        }

        // DELETE: api/customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<customers>> Deletecustomers(long id)
        {
            var customers = await _context.customers.FindAsync(id);
            if (customers == null)
            {
                return NotFound();
            }

            _context.customers.Remove(customers);
            await _context.SaveChangesAsync();

            return customers;
        }

        private bool customersExists(long id)
        {
            return _context.customers.Any(e => e.id == id);
        }
    }
}
