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
    public class ChampionRotationsAPIController : ControllerBase
    {
        private readonly WebProjectContext _context;

        public ChampionRotationsAPIController(WebProjectContext context)
        {
            _context = context;
        }

        // GET: api/ChampionRotationsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChampionRotation>>> GetChampionRotation()
        {
            return await _context.ChampionRotation.ToListAsync();
        }

        // GET: api/ChampionRotationsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChampionRotation>> GetChampionRotation(string id)
        {
            var championRotation = await _context.ChampionRotation.FindAsync(id);

            if (championRotation == null)
            {
                return NotFound();
            }

            return championRotation;
        }

        // PUT: api/ChampionRotationsAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChampionRotation(string id, ChampionRotation championRotation)
        {
            if (id != championRotation.ChampionId)
            {
                return BadRequest();
            }

            _context.Entry(championRotation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChampionRotationExists(id))
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

        // POST: api/ChampionRotationsAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChampionRotation>> PostChampionRotation(ChampionRotation championRotation)
        {
            _context.ChampionRotation.Add(championRotation);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChampionRotationExists(championRotation.ChampionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            //return CreatedAtAction("GetChampionRotation", new { id = championRotation.ChampionId }, championRotation);
            return CreatedAtAction(nameof(GetChampionRotation), new { id = championRotation.ChampionId }, championRotation);
        }

        // DELETE: api/ChampionRotationsAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChampionRotation(string id)
        {
            var championRotation = await _context.ChampionRotation.FindAsync(id);
            if (championRotation == null)
            {
                return NotFound();
            }

            _context.ChampionRotation.Remove(championRotation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChampionRotationExists(string id)
        {
            return _context.ChampionRotation.Any(e => e.ChampionId == id);
        }
    }
}
