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
    [Route("api/buildings")]
    [ApiController]
    public class buildingsController : ControllerBase
    {
        private readonly MysqlContext _context;

        public buildingsController(MysqlContext context)
        {
            _context = context;
        }

        // GET: api/buildings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<buildings>>> Getbuildings()
        {
            return await _context.buildings.ToListAsync();
        }

        // GET: api/buildings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<buildings>> Getbuildings(long id)
        {
            var buildings = await _context.buildings.FindAsync(id);

            if (buildings == null)
            {
                return NotFound();
            }

            return buildings;
        }

        // PUT: api/buildings/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putbuildings(long id, buildings buildings)
        {
            if (id != buildings.id)
            {
                return BadRequest();
            }

            _context.Entry(buildings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!buildingsExists(id))
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

        // POST: api/buildings
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<buildings>> Postbuildings(buildings buildings)
        {
            _context.buildings.Add(buildings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getbuildings", new { id = buildings.id }, buildings);
        }

        // DELETE: api/buildings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<buildings>> Deletebuildings(long id)
        {
            var buildings = await _context.buildings.FindAsync(id);
            if (buildings == null)
            {
                return NotFound();
            }

            _context.buildings.Remove(buildings);
            await _context.SaveChangesAsync();

            return buildings;
        }

        private bool buildingsExists(long id)
        {
            return _context.buildings.Any(e => e.id == id);
        }
    }
}
