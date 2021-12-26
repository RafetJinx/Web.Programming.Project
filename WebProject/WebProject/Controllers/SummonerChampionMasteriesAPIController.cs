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
    public class SummonerChampionMasteriesAPIController : ControllerBase
    {
        private readonly WebProjectContext _context;

        public SummonerChampionMasteriesAPIController(WebProjectContext context)
        {
            _context = context;
        }

        // GET: api/SummonerChampionMasteriesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SummonerChampionMastery>>> GetSummonerChampionMastery()
        {
            return await _context.SummonerChampionMastery.ToListAsync();
        }

        // GET: api/SummonerChampionMasteriesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SummonerChampionMastery>> GetSummonerChampionMastery(string id)
        {
            var summonerChampionMastery = await _context.SummonerChampionMastery.FindAsync(id);

            if (summonerChampionMastery == null)
            {
                return NotFound();
            }

            return summonerChampionMastery;
        }

        // PUT: api/SummonerChampionMasteriesAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSummonerChampionMastery(string id, SummonerChampionMastery summonerChampionMastery)
        {
            if (id != summonerChampionMastery.ChampionId)
            {
                return BadRequest();
            }

            _context.Entry(summonerChampionMastery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SummonerChampionMasteryExists(id))
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

        // POST: api/SummonerChampionMasteriesAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SummonerChampionMastery>> PostSummonerChampionMastery(SummonerChampionMastery summonerChampionMastery)
        {
            _context.SummonerChampionMastery.Add(summonerChampionMastery);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SummonerChampionMasteryExists(summonerChampionMastery.ChampionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            //return CreatedAtAction("GetSummonerChampionMastery", new { id = summonerChampionMastery.ChampionId }, summonerChampionMastery);
            return CreatedAtAction(nameof(GetSummonerChampionMastery), new { id = summonerChampionMastery.ChampionId }, summonerChampionMastery);
        }

        // DELETE: api/SummonerChampionMasteriesAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSummonerChampionMastery(string id)
        {
            var summonerChampionMastery = await _context.SummonerChampionMastery.FindAsync(id);
            if (summonerChampionMastery == null)
            {
                return NotFound();
            }

            _context.SummonerChampionMastery.Remove(summonerChampionMastery);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SummonerChampionMasteryExists(string id)
        {
            return _context.SummonerChampionMastery.Any(e => e.ChampionId == id);
        }
    }
}
