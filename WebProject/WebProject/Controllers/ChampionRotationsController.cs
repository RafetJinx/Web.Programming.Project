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
    public class ChampionRotationsController : Controller
    {
        private readonly WebProjectContext _context;

        public ChampionRotationsController(WebProjectContext context)
        {
            _context = context;
        }

        // GET: ChampionRotations
        public async Task<IActionResult> Index()
        {
            var webProjectContext = _context.ChampionRotation.Include(c => c.Champion);
            return View(await webProjectContext.ToListAsync());
        }

        // GET: ChampionRotations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var championRotation = await _context.ChampionRotation
                .Include(c => c.Champion)
                .FirstOrDefaultAsync(m => m.ChampionId == id);
            if (championRotation == null)
            {
                return NotFound();
            }

            return View(championRotation);
        }

        // GET: ChampionRotations/Create
        public IActionResult Create()
        {
            ViewData["ChampionId"] = new SelectList(_context.Champion, "Id", "Id");
            return View();
        }

        // POST: ChampionRotations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChampionId")] ChampionRotation championRotation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(championRotation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChampionId"] = new SelectList(_context.Champion, "Id", "Id", championRotation.ChampionId);
            return View(championRotation);
        }

        // GET: ChampionRotations/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var championRotation = await _context.ChampionRotation.FindAsync(id);
            if (championRotation == null)
            {
                return NotFound();
            }
            ViewData["ChampionId"] = new SelectList(_context.Champion, "Id", "Id", championRotation.ChampionId);
            return View(championRotation);
        }

        // POST: ChampionRotations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ChampionId")] ChampionRotation championRotation)
        {
            if (id != championRotation.ChampionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(championRotation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChampionRotationExists(championRotation.ChampionId))
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
            ViewData["ChampionId"] = new SelectList(_context.Champion, "Id", "Id", championRotation.ChampionId);
            return View(championRotation);
        }

        // GET: ChampionRotations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var championRotation = await _context.ChampionRotation
                .Include(c => c.Champion)
                .FirstOrDefaultAsync(m => m.ChampionId == id);
            if (championRotation == null)
            {
                return NotFound();
            }

            return View(championRotation);
        }

        // POST: ChampionRotations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var championRotation = await _context.ChampionRotation.FindAsync(id);
            _context.ChampionRotation.Remove(championRotation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChampionRotationExists(string id)
        {
            return _context.ChampionRotation.Any(e => e.ChampionId == id);
        }
    }
}
