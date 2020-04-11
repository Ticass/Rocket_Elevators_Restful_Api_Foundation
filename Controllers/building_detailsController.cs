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
    [Route("api/building_details")]
    [ApiController]
    public class building_detailsController : ControllerBase
    {
        private readonly MysqlContext _context;

        public building_detailsController(MysqlContext context)
        {
            _context = context;
        }

        // GET: api/building_details
        [HttpGet]
        public async Task<ActionResult<IEnumerable<building_details>>> Getbuilding_details()
        {
            return await _context.building_details.ToListAsync();
        }

        // GET: api/building_details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<building_details>> Getbuilding_details(long id)
        {
            var building_details = await _context.building_details.FindAsync(id);

            if (building_details == null)
            {
                return NotFound();
            }

            return building_details;
        }

        // PUT: api/building_details/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putbuilding_details(long id, building_details building_details)
        {
            if (id != building_details.id)
            {
                return BadRequest();
            }

            _context.Entry(building_details).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!building_detailsExists(id))
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

        // POST: api/building_details
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<building_details>> Postbuilding_details(building_details building_details)
        {
            _context.building_details.Add(building_details);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getbuilding_details", new { id = building_details.id }, building_details);
        }

        // DELETE: api/building_details/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<building_details>> Deletebuilding_details(long id)
        {
            var building_details = await _context.building_details.FindAsync(id);
            if (building_details == null)
            {
                return NotFound();
            }

            _context.building_details.Remove(building_details);
            await _context.SaveChangesAsync();

            return building_details;
        }

        private bool building_detailsExists(long id)
        {
            return _context.building_details.Any(e => e.id == id);
        }
    }
}
