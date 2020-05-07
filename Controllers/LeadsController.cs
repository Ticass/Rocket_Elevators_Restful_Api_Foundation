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
    [Route("api/leads")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public LeadsController(DatabaseContext context)
        {
            _context = context;
        }

  
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Leads>>> GetLeads()
        {
            return await _context.Leads.ToListAsync();
        }


    [HttpGet("listofleads")]
        public  ActionResult<List<Leads>> GetLeadsWhoAreNotCustomer()
         {
           
   
            IQueryable<Leads> Lead =

            from lead in _context.Leads 
       
            where lead.customer_id == null && lead.created_at >= DateTime.Now.AddDays(-30)

            select lead; 

            if (Lead == null)
            {
                return NotFound();
            }


            return Lead.ToList();
        }




        [HttpGet("{id}")]
        public async Task<ActionResult<Leads>> GetLeads(long id)
        {
            var Leads = await _context.Leads.FindAsync(id);

            if (Leads == null)
            {
                return NotFound();
            }

        
            return Leads;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeads(long id, Leads Leads)
        {
            if (id != Leads.id)
            {
                return BadRequest();
            }

            _context.Entry(Leads).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeadsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            var jsonPut = new JObject ();
            jsonPut["Update"] = "Update done to Leads id : " + id;
            return Content  (jsonPut.ToString(), "application/json");

        }

        [HttpPost]
        public async Task<ActionResult<Leads>> PostLeads(Leads Leads)
        {
            _context.Leads.Add(Leads);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeads", new { id = Leads.id }, Leads);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Leads>> DeleteLeads(long id)
        {
            var Leads = await _context.Leads.FindAsync(id);
            if (Leads == null)
            {
                return NotFound();
            }

            _context.Leads.Remove(Leads);
            await _context.SaveChangesAsync();

            return Leads;
        }

        private bool LeadsExists(long id)
        {
            return _context.Leads.Any(e => e.id == id);
        }
    }
}
