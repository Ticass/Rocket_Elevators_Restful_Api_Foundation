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
    [Route("api/elevators")]
    [ApiController]
    public class ElevatorsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ElevatorsController(DatabaseContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Elevators>>> GetElevatorsList()
        {

          var list =  await _context.Elevators.ToListAsync();

               if (list == null)
            {
                return NotFound();
            }

     
        List<Elevators> listElevators = new List<Elevators>();



        foreach (var elevator in list){

            if (elevator.status == "Inactive" || elevator.status == "Intervention" ){
         
            listElevators.Add(elevator);



            }
        }


             return listElevators;

            }



        [HttpGet("{id}")]
        public async Task<ActionResult<Elevators>> GetElevators(long id, string Status)
        {
            var Elevators = await _context.Elevators.FindAsync(id);

            if (Elevators == null)
            {
                return NotFound();
            }

            var jsonGet = new JObject ();
            jsonGet["status"] = Elevators.status;
            return Content  (jsonGet.ToString(), "application/json");
        }





    [HttpGet("get/status/all")]

        public async Task<ActionResult<IEnumerable<Elevators>>> GetElevators()
        {
        return await _context.Elevators.ToListAsync();
        }


        [HttpGet("get/status/{id}")]
        public IEnumerable<Elevators> GetElevatorsId(long id)
        {
        IQueryable<Elevators> Elevators =
        from elev in _context.Elevators
        where elev.id == id
        select elev;
        return Elevators.ToList();
        }


        [HttpGet("get/status/inactive")]
        public IEnumerable<Elevators> GetElevatorsInactive()
        {
        IQueryable<Elevators> Elevators =
        from elev in _context.Elevators
        where elev.status == "Inactive"
        select elev;
        return Elevators.ToList();
        }


        [HttpGet("get/status/active")]
        public IEnumerable<Elevators> GetElevatorsActive()
        {
        IQueryable<Elevators> Elevators =
        from elev in _context.Elevators
        where elev.status == "Active"
        select elev;
        return Elevators.ToList();
        }


        [HttpGet("get/status/intervention")]
        public IEnumerable<Elevators> GetElevatorsIntervention()
        {
        IQueryable<Elevators> Elevators =
        from elev in _context.Elevators
        where elev.status == "Intervention"
        select elev;
        return Elevators.ToList();
        }


        [HttpGet("get/status/others")]
        public IEnumerable<Elevators> GetElevatorsOthers()
        {
        IQueryable<Elevators> Elevators =
        from elev in _context.Elevators
        where elev.status != "Active" && elev.status != "Inactive" && elev.status != "Intervention"
        select elev;
        return Elevators.ToList();

        }


    [HttpPut("{id}")]
        public IActionResult PutElevatorStatus(long id, Elevators item)
        {
            var ele = _context.Elevators.Find(id); 
            if (ele == null)
            {
                return NotFound();
            }
            ele.status = item.status;

            _context.Elevators.Update(ele);
            _context.SaveChanges();
    
            var jsonPut = new JObject ();
            jsonPut["Update"] = "Update done to elevator id : " + id + " to the status : " + ele.status;
            return Content  (jsonPut.ToString(), "application/json");
        
        }



        [HttpPost]
        public async Task<ActionResult<Elevators>> PostElevators(Elevators Elevators)
        {
            _context.Elevators.Add(Elevators);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElevators", new { id = Elevators.id }, Elevators);
        }

        // DELETE: api/Elevators/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Elevators>> DeleteElevators(long id)
        {
            var Elevators = await _context.Elevators.FindAsync(id);
            if (Elevators == null)
            {
                return NotFound();
            }

            _context.Elevators.Remove(Elevators);
            await _context.SaveChangesAsync();

            return Elevators;
        }

        private bool ElevatorsExists(long id)
        {
            return _context.Elevators.Any(e => e.id == id);
        }
    }
}
