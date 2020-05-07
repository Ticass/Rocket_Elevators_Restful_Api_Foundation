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
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public EmployeesController(DatabaseContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Employees>> GetEmployees(long id, string email, string job_title)
        {
            var Employees = await _context.Employees.FindAsync(id);

            if (Employees == null)
            {
                return NotFound();
            }

            var jsonGet = new JObject ();
            jsonGet["id"] = Employees.id;
            jsonGet["email"] = Employees.email;
            jsonGet["title"] = Employees.job_title;
            return Content  (jsonGet.ToString(), "application/json");
        }

        
        [HttpPost("{email}")]
        public async Task<ActionResult<IEnumerable<Employees>>> FindEmail(long email)
        {
            var EmployeesEmail = await _context.Employees.FindAsync(email);

            if (EmployeesEmail == null)
            {
                return NotFound();
            }

            var allo = new JObject();
 
            allo["email"] = EmployeesEmail.email;
            return Content(allo.ToString(), "application/json");
        }
        



        [HttpPut("{id}")]
        public IActionResult PutEmployees(long id, Employees item)
        {
            var emp = _context.Employees.Find(id); 
            if (emp == null)
            {
                return NotFound();
            }
            emp.job_title = item.job_title;

            _context.Employees.Update(emp);
            _context.SaveChanges();

            var jsonPut = new JObject ();
            jsonPut["Update"] = "Update done to Employees id : " + id + " to the title : " + emp.job_title;
            return Content  (jsonPut.ToString(), "application/json");
        
        }


      

        [HttpDelete("{id}")]
        public async Task<ActionResult<Employees>> DeleteEmployees(long id)
        {
            var Employees = await _context.Employees.FindAsync(id);
            if (Employees == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(Employees);
            await _context.SaveChangesAsync();

            return Employees;
        }

        private bool EmployeesExists(long id)
        {
            return _context.Employees.Any(e => e.id == id);
        }
    }
}
