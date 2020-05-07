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
    [Route("api/batteries")]
    [ApiController]
    public class BatteriesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public BatteriesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Batteries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Batteries>>> GetBatteries()
        {
            return await _context.Batteries.ToListAsync();
        }

        // GET: api/Batteries/5


 //https://stackoverflow.com/questions/16507222/create-json-object-dynamically-via-javascript-without-concate-strings
 
//  return this.Content(returntext, "application/json");

        [HttpGet("{id}")]
        public async Task<ActionResult<Batteries>> GetBatteries(long id, string Status)
        {
            var batteries = await _context.Batteries.FindAsync(id);

            if (batteries == null)
            {
                return NotFound();
            }

            var jsonGet = new JObject ();
            jsonGet["status"] = batteries.status;
            return Content  (jsonGet.ToString(), "application/json");
        }

        // PUT: api/Batteries/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutBatteries(long id, Batteries batteries)
        // {
        //     if (id != batteries.id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(batteries).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!BatteriesExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }
            
        //     var jsonPut = new JObject ();
        //     jsonPut["Update"] = "Update done to batteries id : " + id;
        //     return Content  (jsonPut.ToString(), "application/json");

        // }



   [HttpPut("{id}")]
        public IActionResult PutBatteryStatus(long id, Batteries item)
        {
            var bat = _context.Batteries.Find(id); 
            if (bat == null)
            {
                return NotFound();
            }
            bat.status = item.status;

            _context.Batteries.Update(bat);
            _context.SaveChanges();
    
            var jsonPut = new JObject ();
            jsonPut["Update"] = "Update done to battery id : " + id + " to the status : " + bat.status;
            return Content  (jsonPut.ToString(), "application/json");
        
        }




        // POST: api/Batteries
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Batteries>> PostBatteries(Batteries batteries)
        {
            _context.Batteries.Add(batteries);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBatteries", new { id = batteries.id }, batteries);
        }

        // DELETE: api/Batteries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Batteries>> DeleteBatteries(long id)
        {
            var batteries = await _context.Batteries.FindAsync(id);
            if (batteries == null)
            {
                return NotFound();
            }

            _context.Batteries.Remove(batteries);
            await _context.SaveChangesAsync();

            return batteries;
        }

        private bool BatteriesExists(long id)
        {
            return _context.Batteries.Any(e => e.id == id);
        }
    }
}
