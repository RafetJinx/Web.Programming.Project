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
    public class SummonerRankedLeagueDetailsAPIController : ControllerBase
    {
        private readonly WebProjectContext _context;

        public SummonerRankedLeagueDetailsAPIController(WebProjectContext context)
        {
            _context = context;
        }

        // GET: api/SummonerRankedLeagueDetailsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SummonerRankedLeagueDetail>>> GetSummonerRankedLeagueDetail()
        {
            return await _context.SummonerRankedLeagueDetail.ToListAsync();
        }

        // GET: api/SummonerRankedLeagueDetailsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SummonerRankedLeagueDetail>> GetSummonerRankedLeagueDetail(string id)
        {
            var summonerRankedLeagueDetail = await _context.SummonerRankedLeagueDetail.FindAsync(id);

            if (summonerRankedLeagueDetail == null)
            {
                return NotFound();
            }

            return summonerRankedLeagueDetail;
        }

        // PUT: api/SummonerRankedLeagueDetailsAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSummonerRankedLeagueDetail(string id, SummonerRankedLeagueDetail summonerRankedLeagueDetail)
        {
            if (id != summonerRankedLeagueDetail.LeagueId)
            {
                return BadRequest();
            }

            _context.Entry(summonerRankedLeagueDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SummonerRankedLeagueDetailExists(id))
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

        // POST: api/SummonerRankedLeagueDetailsAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SummonerRankedLeagueDetail>> PostSummonerRankedLeagueDetail(SummonerRankedLeagueDetail summonerRankedLeagueDetail)
        {
            _context.SummonerRankedLeagueDetail.Add(summonerRankedLeagueDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SummonerRankedLeagueDetailExists(summonerRankedLeagueDetail.LeagueId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            //return CreatedAtAction("GetSummonerRankedLeagueDetail", new { id = summonerRankedLeagueDetail.LeagueId }, summonerRankedLeagueDetail);
            return CreatedAtAction(nameof(GetSummonerRankedLeagueDetail), new { id = summonerRankedLeagueDetail.LeagueId }, summonerRankedLeagueDetail);
        }

        // DELETE: api/SummonerRankedLeagueDetailsAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSummonerRankedLeagueDetail(string id)
        {
            var summonerRankedLeagueDetail = await _context.SummonerRankedLeagueDetail.FindAsync(id);
            if (summonerRankedLeagueDetail == null)
            {
                return NotFound();
            }

            _context.SummonerRankedLeagueDetail.Remove(summonerRankedLeagueDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SummonerRankedLeagueDetailExists(string id)
        {
            return _context.SummonerRankedLeagueDetail.Any(e => e.LeagueId == id);
        }
    }
}
