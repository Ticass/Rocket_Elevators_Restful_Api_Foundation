using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Models;
using Newtonsoft.Json.Linq;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace RestApi.Controllers
{
    [Route("api/buildings")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public BuildingsController(DatabaseContext context)
        {
            _context = context;
        }



    [HttpGet("intervention")]

    public  ActionResult<List<Buildings>> GetBuildingsWithProblems()
        {

        IQueryable<Buildings>  Building = 

        from bui in _context.Buildings
        join bat in _context.Batteries on bui.id equals bat.building_id
        join col in _context.Columns on bat.id equals col.battery_id
        join ele in _context.Elevators on col.id equals ele.column_id

        where bat.status == "Intervention" || col.status == "Intervention" || ele.status == "Intervention" // va tu les ajouter 3 fois sans specifier si col, ele ou bat ?
        select bui;
        
      
        return Building.ToList();

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Buildings>> GetBuildings(long id, string Status)
        {
            var Buildings = await _context.Buildings.FindAsync(id);

            if (Buildings == null)
            {
                return NotFound();
            }

    
            return Buildings;
        
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuildings(long id, Buildings Buildings)
        {
            if (id != Buildings.id)
            {
                return BadRequest();
            }

            _context.Entry(Buildings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuildingsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            var jsonPut = new JObject ();
            jsonPut["Update"] = "Update done to Buildings id : " + id;
            return Content  (jsonPut.ToString(), "application/json");

        }

 
        [HttpPost]
        public async Task<ActionResult<Buildings>> PostBuildings(Buildings Buildings)
        {
            _context.Buildings.Add(Buildings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuildings", new { id = Buildings.id }, Buildings);
        }

    
        [HttpDelete("{id}")]
        public async Task<ActionResult<Buildings>> DeleteBuildings(long id)
        {
            var Buildings = await _context.Buildings.FindAsync(id);
            if (Buildings == null)
            {
                return NotFound();
            }

            _context.Buildings.Remove(Buildings);
            await _context.SaveChangesAsync();

            return Buildings;
        }

        private bool BuildingsExists(long id)
        {
            return _context.Buildings.Any(e => e.id == id);
        }
    }
}
