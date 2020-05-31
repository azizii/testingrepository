using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using testingproj.Models;

namespace testingproj.Controllers
{
    public class azizsController : Controller
    {
        private readonly testingprojContext _context;

        public azizsController(testingprojContext context)
        {
            _context = context;
        }

        // GET: azizs
        public async Task<IActionResult> Index()
        {
            return View(await _context.aziz.ToListAsync());
        }

        // GET: azizs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aziz = await _context.aziz
                .FirstOrDefaultAsync(m => m.azizId == id);
            if (aziz == null)
            {
                return NotFound();
            }

            return View(aziz);
        }

        // GET: azizs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: azizs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("azizId,azizName")] aziz aziz)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aziz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aziz);
        }

        // GET: azizs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aziz = await _context.aziz.FindAsync(id);
            if (aziz == null)
            {
                return NotFound();
            }
            return View(aziz);
        }

        // POST: azizs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("azizId,azizName")] aziz aziz)
        {
            if (id != aziz.azizId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aziz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!azizExists(aziz.azizId))
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
            return View(aziz);
        }

        // GET: azizs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aziz = await _context.aziz
                .FirstOrDefaultAsync(m => m.azizId == id);
            if (aziz == null)
            {
                return NotFound();
            }

            return View(aziz);
        }

        // POST: azizs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aziz = await _context.aziz.FindAsync(id);
            _context.aziz.Remove(aziz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool azizExists(int id)
        {
            return _context.aziz.Any(e => e.azizId == id);
        }
    }
}
