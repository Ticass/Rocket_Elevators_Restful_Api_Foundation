using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Models;
using Newtonsoft.Json.Linq;

namespace RestApi.Controllers
{
    [Route("api/interventions")]
    [ApiController]
    public class InterventionsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public InterventionsController(DatabaseContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Interventions>>> GetInterventions()
        {
            return await _context.Interventions.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Interventions>> GetInterventions(long id, string Status)
        {
            var Interventions = await _context.Interventions.FindAsync(id);

            if (Interventions == null)
            {
                return NotFound();
            }

            var jsonGet = new JObject ();
            jsonGet["status"] = Interventions.status;
            return Content  (jsonGet.ToString(), "application/json");
        }





        [HttpPut("{id}")]
        public IActionResult PutInterventionstatus(long id, Interventions item)
        {
            var col = _context.Interventions.Find(id); 
            if (col == null)
            {
                return NotFound();
            }
            col.status = item.status;

            _context.Interventions.Update(col);
            _context.SaveChanges();

            var jsonPut = new JObject ();
            jsonPut["Update"] = "Update done to Interventions id : " + id + " to the status : " + col.status;
            return Content  (jsonPut.ToString(), "application/json");
        
        }


        [HttpPost]
        public async Task<ActionResult<Interventions>> PostInterventions(Interventions Interventions)
        {
            _context.Interventions.Add(Interventions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInterventions", new { id = Interventions.id }, Interventions);
        }

        // DELETE: api/Interventions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Interventions>> DeleteInterventions(long id)
        {
            var Interventions = await _context.Interventions.FindAsync(id);
            if (Interventions == null)
            {
                return NotFound();
            }

            _context.Interventions.Remove(Interventions);
            await _context.SaveChangesAsync();

            return Interventions;
        }

        private bool InterventionsExists(long id)
        {
            return _context.Interventions.Any(e => e.id == id);
        }
    









            // api/interventions/pending
            [HttpGet("pending")]
            public async Task<ActionResult<List<Interventions>>> GetInterventionPendingList() {
                
                var list =  await _context.Interventions.ToListAsync();

                if (list == null) {
                    return NotFound();
                }

                List<Interventions> listIntervention = new List<Interventions>();

                foreach (var intervention in list) {
                    if (intervention.status == "Pending" || intervention.start_date_time_intervention == null ) {
                        listIntervention.Add(intervention);
                    }
                }
                return listIntervention;
            }

            // api/interventions/inProgress/id
            [HttpPut("inProgress/{id}")]
            public IActionResult putInterventionStatusInProgress(long id, Interventions item) {
                
                var col = _context.Interventions.Find(keyValues: id); 
                
                if (col == null) {
                    return NotFound();
                }

                col.status = item.status;
                col.start_date_time_intervention = item.start_date_time_intervention;

                _context.Interventions.Update(col);
                _context.SaveChanges();

                var jsonPut = new JObject ();
                jsonPut["Update"] = "Update done to Interventions id : " + id + " to the status : " + col.status + "start at" + col.start_date_time_intervention;
                return Content  (jsonPut.ToString(), "application/json");
            }

            // api/interventions/completed/id
            [HttpPut("completed/{id}")]
            public IActionResult putInterventionStatusCompleted(long id, Interventions item) {
                
                var col = _context.Interventions.Find(id); 
                
                if (col == null) {
                    return NotFound();
                }

                col.status = item.status;
                col.end_date_time_intervention = item.end_date_time_intervention;

                _context.Interventions.Update(col);
                _context.SaveChanges();

                var jsonPut = new JObject ();
                jsonPut["Update"] = "Update done to Interventions id : " + id + " to the status : " + col.status + "start at" + col.end_date_time_intervention;
                return Content  (jsonPut.ToString(), "application/json");
            }
    }
}