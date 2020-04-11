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
    [Route("api/quotes")]
    [ApiController]
    public class quotesController : ControllerBase
    {
        private readonly MysqlContext _context;

        public quotesController(MysqlContext context)
        {
            _context = context;
        }

        // GET: api/quotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<quotes>>> Getquotes()
        {
            return await _context.quotes.ToListAsync();
        }

        // GET: api/quotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<quotes>> Getquotes(long id)
        {
            var quotes = await _context.quotes.FindAsync(id);

            if (quotes == null)
            {
                return NotFound();
            }

            return quotes;
        }

        // PUT: api/quotes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putquotes(long id, quotes quotes)
        {
            if (id != quotes.id)
            {
                return BadRequest();
            }

            _context.Entry(quotes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!quotesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/quotes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<quotes>> Postquotes(quotes quotes)
        {
            _context.quotes.Add(quotes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getquotes", new { id = quotes.id }, quotes);
        }

        // DELETE: api/quotes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<quotes>> Deletequotes(long id)
        {
            var quotes = await _context.quotes.FindAsync(id);
            if (quotes == null)
            {
                return NotFound();
            }

            _context.quotes.Remove(quotes);
            await _context.SaveChangesAsync();

            return quotes;
        }

        private bool quotesExists(long id)
        {
            return _context.quotes.Any(e => e.id == id);
        }
    }
}
