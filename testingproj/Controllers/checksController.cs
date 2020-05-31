using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using testingproj.Models;

namespace testingproj.Controllers
{
    public class checksController : Controller
    {
        private readonly testingprojContext _context;

        public checksController(testingprojContext context)
        {
            _context = context;
        }

        // GET: checks
        public async Task<IActionResult> Index()
        {
            return View(await _context.check.ToListAsync());
        }

        // GET: checks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var check = await _context.check
                .FirstOrDefaultAsync(m => m.checkId == id);
            if (check == null)
            {
                return NotFound();
            }

            return View(check);
        }

        // GET: checks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: checks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("checkId,checkName")] check check)
        {
            if (ModelState.IsValid)
            {
                _context.Add(check);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(check);
        }

        // GET: checks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var check = await _context.check.FindAsync(id);
            if (check == null)
            {
                return NotFound();
            }
            return View(check);
        }

        // POST: checks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("checkId,checkName")] check check)
        {
            if (id != check.checkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(check);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!checkExists(check.checkId))
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
            return View(check);
        }

        // GET: checks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var check = await _context.check
                .FirstOrDefaultAsync(m => m.checkId == id);
            if (check == null)
            {
                return NotFound();
            }

            return View(check);
        }

        // POST: checks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var check = await _context.check.FindAsync(id);
            _context.check.Remove(check);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool checkExists(int id)
        {
            return _context.check.Any(e => e.checkId == id);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<check>>> Getdata()
        {
            //string serverPathTowwwrootFolder = "wwwroot/images/";
            //All food table record
            var ad = _context.check.ToList();



            return ad;
        }
        [HttpPost]
        public string Postdata([FromBody]check value)
        {
            if (!_context.check.Any(user => user.checkId.Equals(value.checkId)))
            {
                check tblUser = new check();
                // tblUser.checkId= value.checkId;
                tblUser.checkName = value.checkName;
                try
                {
                    _context.Add(tblUser);
                    _context.SaveChanges();
                    return JsonConvert.SerializeObject("register succefully");
                }
                catch (Exception ex)
                {
                    return JsonConvert.SerializeObject(ex.Message);
                }
            }
            else
            {
                return JsonConvert.SerializeObject("User is existing in database");
            }
        }

        [HttpPost]
        public string Postlogin([FromBody]check value)
        {
            if (_context.check.Any(user => user.checkName.Equals(value.checkName)))
            {
               check User = _context.check.Where(u => u.checkName.Equals(value.checkName)).First();

                if (value.checkName.Equals(User.checkName))
                {


                    return JsonConvert.SerializeObject(User);
                }
                else
                {


                    return JsonConvert.SerializeObject("wrong password");
                }
            }
            else
            {
                return JsonConvert.SerializeObject("user not exist");
            }
        }
    }
}
