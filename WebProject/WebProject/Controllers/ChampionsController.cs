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
    public class ChampionsController : Controller
    {
        private readonly WebProjectContext _context;

        public ChampionsController(WebProjectContext context)
        {
            _context = context;
        }

        // GET: Champions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Champion.ToListAsync());
        }

        // GET: Champions/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var champion = await _context.Champion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (champion == null)
            {
                return NotFound();
            }

            return View(champion);
        }

        // GET: Champions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Champions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Key,Name,Title,Blurb")] Champion champion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(champion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(champion);
        }

        // GET: Champions/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var champion = await _context.Champion.FindAsync(id);
            if (champion == null)
            {
                return NotFound();
            }
            return View(champion);
        }

        // POST: Champions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Key,Name,Title,Blurb")] Champion champion)
        {
            if (id != champion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(champion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChampionExists(champion.Id))
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
            return View(champion);
        }

        // GET: Champions/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var champion = await _context.Champion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (champion == null)
            {
                return NotFound();
            }

            return View(champion);
        }

        // POST: Champions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var champion = await _context.Champion.FindAsync(id);
            _context.Champion.Remove(champion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChampionExists(string id)
        {
            return _context.Champion.Any(e => e.Id == id);
        }
    }
}
