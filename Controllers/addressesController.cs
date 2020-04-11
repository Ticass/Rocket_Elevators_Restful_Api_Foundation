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
    [Route("api/adresses")]
    [ApiController]
    public class addressesController : ControllerBase
    {
        private readonly MysqlContext _context;

        public addressesController(MysqlContext context)
        {
            _context = context;
        }

        // GET: api/adresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<addresses>>> Getadresses()
        {
            return await _context.addresses.ToListAsync();
        }

        // GET: api/adresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<addresses>> Getadresses(long id)
        {
            var adresses = await _context.addresses.FindAsync(id);

            if (adresses == null)
            {
                return NotFound();
            }

            return adresses;
        }

        // PUT: api/adresses/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putadresses(long id, addresses adresses)
        {
            if (id != adresses.id)
            {
                return BadRequest();
            }

            _context.Entry(adresses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!adressesExists(id))
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

        // POST: api/adresses
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<addresses>> Postadresses(addresses adresses)
        {
            _context.addresses.Add(adresses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getadresses", new { id = adresses.id }, adresses);
        }

        // DELETE: api/adresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<addresses>> Deleteadresses(long id)
        {
            var adresses = await _context.addresses.FindAsync(id);
            if (adresses == null)
            {
                return NotFound();
            }

            _context.addresses.Remove(adresses);
            await _context.SaveChangesAsync();

            return adresses;
        }

        private bool adressesExists(long id)
        {
            return _context.addresses.Any(e => e.id == id);
        }
    }
}

