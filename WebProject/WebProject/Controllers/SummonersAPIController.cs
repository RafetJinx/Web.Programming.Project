using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProject.Data;
using WebProject.Models;

namespace WebProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SummonersAPIController : ControllerBase
    {
        private readonly WebProjectContext _context;

        public SummonersAPIController(WebProjectContext context)
        {
            _context = context;
        }

        // GET: api/SummonersAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Summoner>>> GetSummoner()
        {
            return await _context.Summoner.ToListAsync();
        }

        // GET: api/SummonersAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Summoner>> GetSummoner(string id)
        {
            var summoner = await _context.Summoner.FindAsync(id);

            if (summoner == null)
            {
                return NotFound();
            }

            return summoner;
        }

        // PUT: api/SummonersAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSummoner(string id, Summoner summoner)
        {
            if (id != summoner.Id)
            {
                return BadRequest();
            }

            _context.Entry(summoner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SummonerExists(id))
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

        // POST: api/SummonersAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Summoner>> PostSummoner(Summoner summoner)
        {
            _context.Summoner.Add(summoner);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SummonerExists(summoner.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            //return CreatedAtAction("GetSummoner", new { id = summoner.Id }, summoner);
            return CreatedAtAction(nameof(GetSummoner), new { id = summoner.Id }, summoner);
        }

        // DELETE: api/SummonersAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSummoner(string id)
        {
            var summoner = await _context.Summoner.FindAsync(id);
            if (summoner == null)
            {
                return NotFound();
            }

            _context.Summoner.Remove(summoner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SummonerExists(string id)
        {
            return _context.Summoner.Any(e => e.Id == id);
        }
    }
}
