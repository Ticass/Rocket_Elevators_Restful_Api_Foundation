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
    [Route("api/columns")]
    [ApiController]
    public class ColumnsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ColumnsController(DatabaseContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Columns>>> GetColumns()
        {
            return await _context.Columns.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Columns>> GetColumns(long id, string Status)
        {
            var Columns = await _context.Columns.FindAsync(id);

            if (Columns == null)
            {
                return NotFound();
            }

            var jsonGet = new JObject ();
            jsonGet["status"] = Columns.status;
            return Content  (jsonGet.ToString(), "application/json");
        }





   [HttpPut("{id}")]
        public IActionResult PutColumnStatus(long id, Columns item)
        {
            var col = _context.Columns.Find(id); 
            if (col == null)
            {
                return NotFound();
            }
            col.status = item.status;

            _context.Columns.Update(col);
            _context.SaveChanges();

            var jsonPut = new JObject ();
            jsonPut["Update"] = "Update done to columns id : " + id + " to the status : " + col.status;
            return Content  (jsonPut.ToString(), "application/json");
        
        }


        [HttpPost]
        public async Task<ActionResult<Columns>> PostColumns(Columns Columns)
        {
            _context.Columns.Add(Columns);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColumns", new { id = Columns.id }, Columns);
        }

        // DELETE: api/Columns/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Columns>> DeleteColumns(long id)
        {
            var Columns = await _context.Columns.FindAsync(id);
            if (Columns == null)
            {
                return NotFound();
            }

            _context.Columns.Remove(Columns);
            await _context.SaveChangesAsync();

            return Columns;
        }

        private bool ColumnsExists(long id)
        {
            return _context.Columns.Any(e => e.id == id);
        }
    


        [HttpGet("get/status/inactive")]

            public IEnumerable<Columns> GetColumnsInactive()
            {
            IQueryable<Columns> Columns =
            from col in _context.Columns
            where col.status == "Inactive"
            select col;
            return Columns.ToList();
            }

            [HttpGet("get/status/active")]
            public IEnumerable<Columns> GetColumnsActive()
            {
            IQueryable<Columns> Columns =
            from col in _context.Columns
            where col.status == "Active"
            select col;
            return Columns.ToList();
            }

            [HttpGet("get/status/intervention")]
            public IEnumerable<Columns> GetColumnsIntervention()
            {
            IQueryable<Columns> Columns =
            from col in _context.Columns
            where col.status == "Intervention"
            select col;
            return Columns.ToList();
            }

            [HttpGet("get/status/others")]
            public IEnumerable<Columns> GetColumnsOthers()
            {
            IQueryable<Columns> Columns =
            from col in _context.Columns
            where col.status != "Active" && col.status != "Inactive" && col.status != "Intervention"
            select col;
            return Columns.ToList();
            }




}
}