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
    [Route("api/Interventions")]
    [ApiController]
    public class InterventionsController : ControllerBase
    {
        private readonly MysqlContext _context;

        public InterventionsController(MysqlContext context)
        {
            _context = context;
        }

        // GET: api/Interventions
       /* [HttpGet]
        public async Task<ActionResult<IEnumerable<Interventions>>> GetInterventions()
        {
            return await _context.Interventions.ToListAsync();
        }

        // GET: api/Interventions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Interventions>> GetInterventions(long id)
        {
            var interventions = await _context.Interventions.FindAsync(id);

            if (interventions == null)
            {
                return NotFound();
            }

            return interventions;
        }
        */


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interventions>>> GetInterventions()
        {
            var interventions = await _context.Interventions.Where(s => s.intervention_status == "Pending" && s.intervention_start_date == null).ToListAsync();

            if (interventions == null)
            {
                return NotFound();
            }

            return interventions;
        }




        // PUT: api/Interventions/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<ActionResult<Interventions>> PutInterventions(long id, Interventions interventions)
        {
            var interventionsToUpdate = await _context.Interventions.FindAsync(id);

            if (interventionsToUpdate == null )
            {
                return NotFound();
            }

            interventionsToUpdate.intervention_status = interventions.intervention_status;
            interventionsToUpdate.intervention_start_date = interventions.intervention_start_date;
            interventionsToUpdate.intervention_end_date = interventions.intervention_end_date;

            await _context.SaveChangesAsync();


            return interventionsToUpdate;
        }

        // POST: api/Interventions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Interventions>> PostInterventions(Interventions interventions)
        {
            _context.Interventions.Add(interventions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInterventions", new { id = interventions.id }, interventions);
        }

        // DELETE: api/Interventions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Interventions>> DeleteInterventions(long id)
        {
            var interventions = await _context.Interventions.FindAsync(id);
            if (interventions == null)
            {
                return NotFound();
            }

            _context.Interventions.Remove(interventions);
            await _context.SaveChangesAsync();

            return interventions;
        }

        private bool InterventionsExists(long id)
        {
            return _context.Interventions.Any(e => e.id == id);
        }
    }
}
