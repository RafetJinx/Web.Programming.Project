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
    public class SummonersController : Controller
    {
        private readonly WebProjectContext _context;

        public SummonersController(WebProjectContext context)
        {
            _context = context;
        }

        // GET: Summoners
        public async Task<IActionResult> Index()
        {
            return View(await _context.Summoner.ToListAsync());
        }

        // GET: Summoners/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var summoner = await _context.Summoner
                .FirstOrDefaultAsync(m => m.Id == id);
            if (summoner == null)
            {
                return NotFound();
            }

            return View(summoner);
        }

        // GET: Summoners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Summoners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AccountId,PuuId,Name,ProfileIconId,RevisionDate,SummonerLevel")] Summoner summoner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(summoner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(summoner);
        }

        // GET: Summoners/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var summoner = await _context.Summoner.FindAsync(id);
            if (summoner == null)
            {
                return NotFound();
            }
            return View(summoner);
        }

        // POST: Summoners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,AccountId,PuuId,Name,ProfileIconId,RevisionDate,SummonerLevel")] Summoner summoner)
        {
            if (id != summoner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(summoner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SummonerExists(summoner.Id))
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
            return View(summoner);
        }

        // GET: Summoners/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var summoner = await _context.Summoner
                .FirstOrDefaultAsync(m => m.Id == id);
            if (summoner == null)
            {
                return NotFound();
            }

            return View(summoner);
        }

        // POST: Summoners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var summoner = await _context.Summoner.FindAsync(id);
            _context.Summoner.Remove(summoner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SummonerExists(string id)
        {
            return _context.Summoner.Any(e => e.Id == id);
        }
    }
}
