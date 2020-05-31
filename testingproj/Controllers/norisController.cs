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
    public class norisController : Controller
    {
        private readonly testingprojContext _context;

        public norisController(testingprojContext context)
        {
            _context = context;
        }

        // GET: noris
        public async Task<IActionResult> Index()
        {
            return View(await _context.nori.ToListAsync());
        }

        // GET: noris/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nori = await _context.nori
                .FirstOrDefaultAsync(m => m.noriId == id);
            if (nori == null)
            {
                return NotFound();
            }

            return View(nori);
        }

        // GET: noris/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: noris/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("noriId,noriName")] nori nori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nori);
        }

        // GET: noris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nori = await _context.nori.FindAsync(id);
            if (nori == null)
            {
                return NotFound();
            }
            return View(nori);
        }

        // POST: noris/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("noriId,noriName")] nori nori)
        {
            if (id != nori.noriId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!noriExists(nori.noriId))
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
            return View(nori);
        }

        // GET: noris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nori = await _context.nori
                .FirstOrDefaultAsync(m => m.noriId == id);
            if (nori == null)
            {
                return NotFound();
            }

            return View(nori);
        }

        // POST: noris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nori = await _context.nori.FindAsync(id);
            _context.nori.Remove(nori);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool noriExists(int id)
        {
            return _context.nori.Any(e => e.noriId == id);
        }
    }
}
