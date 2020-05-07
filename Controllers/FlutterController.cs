using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using RestApi.Models;

namespace RestApi.Controllers
{
    [Route("api/flutter")]
    [ApiController]
    public class FlutterController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public FlutterController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Flutter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        // GET: api/Flutter/email@end.domain
        [HttpGet("{email}")]
        public async Task<ActionResult<IEnumerable<Employees>>> GetEmployees(string email)
        {
            var Employees = await _context.Employees.Where(x => x.email == email).ToListAsync();

            if (Employees == null)
            {
                return NotFound();
            }

            return Employees;
        }



        // POST: api/Flutter
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Employees>> PostEmployees(Employees employees, long email)
        {
           await _context.Employees.FindAsync(email);

            return CreatedAtAction("GetEmployees", new { email = employees.email }, employees);
        }

        // DELETE: api/Flutter/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employees>> DeleteEmployees(long id)
        {
            var employees = await _context.Employees.FindAsync(id);
            if (employees == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employees);
            await _context.SaveChangesAsync();

            return employees;
        }

        private bool EmployeesExists(long id)
        {
            return _context.Employees.Any(e => e.id == id);
        }
    }
}
