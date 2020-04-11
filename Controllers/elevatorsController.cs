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
    [Route("api/elevators")]
    [ApiController]
    public class elevatorsController : ControllerBase
    {
        private readonly MysqlContext _context;

        public elevatorsController(MysqlContext context)
        {
            _context = context;
        }

        // GET: api/elevators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<elevators>>> Getelevators()
        {
            return await _context.elevators.ToListAsync();
        }

        // GET: api/elevators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<elevators>> Getelevators(long id)
        {
            var elevators = await _context.elevators.FindAsync(id);

            if (elevators == null)
            {
                return NotFound();
            }

            return elevators;
        }

        // PUT: api/elevators/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putelevators(long id, elevators elevators)
        {
            if (id != elevators.Id)
            {
                return BadRequest();
            }

            _context.Entry(elevators).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!elevatorsExists(id))
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

        // POST: api/elevators
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<elevators>> Postelevators(elevators elevators)
        {
            _context.elevators.Add(elevators);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getelevators", new { id = elevators.Id }, elevators);
        }

        // DELETE: api/elevators/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<elevators>> Deleteelevators(long id)
        {
            var elevators = await _context.elevators.FindAsync(id);
            if (elevators == null)
            {
                return NotFound();
            }

            _context.elevators.Remove(elevators);
            await _context.SaveChangesAsync();

            return elevators;
        }

        private bool elevatorsExists(long id)
        {
            return _context.elevators.Any(e => e.Id == id);
        }
    }
}
