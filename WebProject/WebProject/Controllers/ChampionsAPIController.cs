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
    public class ChampionsAPIController : ControllerBase
    {
        private readonly WebProjectContext _context;

        public ChampionsAPIController(WebProjectContext context)
        {
            _context = context;
        }

        // GET: api/ChampionsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Champion>>> GetChampion()
        {
            return await _context.Champion.ToListAsync();
        }

        // GET: api/ChampionsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Champion>> GetChampion(string id)
        {
            var champion = await _context.Champion.FindAsync(id);

            if (champion == null)
            {
                return NotFound();
            }

            return champion;
        }

        // PUT: api/ChampionsAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChampion(string id, Champion champion)
        {
            if (id != champion.Id)
            {
                return BadRequest();
            }

            _context.Entry(champion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChampionExists(id))
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

        // POST: api/ChampionsAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Champion>> PostChampion(Champion champion)
        {
            _context.Champion.Add(champion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChampionExists(champion.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            //return CreatedAtAction("GetChampion", new { id = champion.Id }, champion);
            return CreatedAtAction(nameof(GetChampion), new { id = champion.Id }, champion);
        }

        // DELETE: api/ChampionsAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChampion(string id)
        {
            var champion = await _context.Champion.FindAsync(id);
            if (champion == null)
            {
                return NotFound();
            }

            _context.Champion.Remove(champion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChampionExists(string id)
        {
            return _context.Champion.Any(e => e.Id == id);
        }
    }
}
