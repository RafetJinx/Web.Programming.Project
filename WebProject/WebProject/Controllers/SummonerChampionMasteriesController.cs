using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProject.Data;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class SummonerChampionMasteriesController : Controller
    {
        private readonly WebProjectContext _context;

        public SummonerChampionMasteriesController(WebProjectContext context)
        {
            _context = context;
        }

        // GET: SummonerChampionMasteries
        public async Task<IActionResult> Index()
        {
            var webProjectContext = _context.SummonerChampionMastery.Include(s => s.Champion).Include(s => s.Summoner);
            return View(await webProjectContext.ToListAsync());
        }

        // GET: SummonerChampionMasteries/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var summonerChampionMastery = await _context.SummonerChampionMastery
                .Include(s => s.Champion)
                .Include(s => s.Summoner)
                .FirstOrDefaultAsync(m => m.ChampionId == id);
            if (summonerChampionMastery == null)
            {
                return NotFound();
            }

            return View(summonerChampionMastery);
        }

        // GET: SummonerChampionMasteries/Create
        public IActionResult Create()
        {
            ViewData["ChampionId"] = new SelectList(_context.Champion, "Id", "Id");
            ViewData["SummonerId"] = new SelectList(_context.Summoner, "Id", "Id");
            return View();
        }

        // POST: SummonerChampionMasteries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChampionId,ChampionLevel,ChampionPoint,LastPlayTime,ChestGranted,TokensEarned,SummonerId")] SummonerChampionMastery summonerChampionMastery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(summonerChampionMastery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChampionId"] = new SelectList(_context.Champion, "Id", "Id", summonerChampionMastery.ChampionId);
            ViewData["SummonerId"] = new SelectList(_context.Summoner, "Id", "Id", summonerChampionMastery.SummonerId);
            return View(summonerChampionMastery);
        }

        // GET: SummonerChampionMasteries/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var summonerChampionMastery = await _context.SummonerChampionMastery.FindAsync(id);
            if (summonerChampionMastery == null)
            {
                return NotFound();
            }
            ViewData["ChampionId"] = new SelectList(_context.Champion, "Id", "Id", summonerChampionMastery.ChampionId);
            ViewData["SummonerId"] = new SelectList(_context.Summoner, "Id", "Id", summonerChampionMastery.SummonerId);
            return View(summonerChampionMastery);
        }

        // POST: SummonerChampionMasteries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ChampionId,ChampionLevel,ChampionPoint,LastPlayTime,ChestGranted,TokensEarned,SummonerId")] SummonerChampionMastery summonerChampionMastery)
        {
            if (id != summonerChampionMastery.ChampionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(summonerChampionMastery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SummonerChampionMasteryExists(summonerChampionMastery.ChampionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChampionId"] = new SelectList(_context.Champion, "Id", "Id", summonerChampionMastery.ChampionId);
            ViewData["SummonerId"] = new SelectList(_context.Summoner, "Id", "Id", summonerChampionMastery.SummonerId);
            return View(summonerChampionMastery);
        }

        // GET: SummonerChampionMasteries/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var summonerChampionMastery = await _context.SummonerChampionMastery
                .Include(s => s.Champion)
                .Include(s => s.Summoner)
                .FirstOrDefaultAsync(m => m.ChampionId == id);
            if (summonerChampionMastery == null)
            {
                return NotFound();
            }

            return View(summonerChampionMastery);
        }

        // POST: SummonerChampionMasteries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var summonerChampionMastery = await _context.SummonerChampionMastery.FindAsync(id);
            _context.SummonerChampionMastery.Remove(summonerChampionMastery);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SummonerChampionMasteryExists(string id)
        {
            return _context.SummonerChampionMastery.Any(e => e.ChampionId == id);
        }
    }
}
