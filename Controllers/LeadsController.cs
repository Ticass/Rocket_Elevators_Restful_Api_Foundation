using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers {
    [Route ("api/leads")]
    [ApiController]
    public class LeadsController : ControllerBase {
        private readonly MysqlContext _context;
        public LeadsController (MysqlContext context) {
            _context = context;
        }

        // GET api/leads
       public async Task<ActionResult<IEnumerable<leads>>> GetTodoItems()
        {
            return await _context.leads.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<leads>> GetTodoItem(long id)
        {
            var todoItem = await _context.leads.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        
    }
}