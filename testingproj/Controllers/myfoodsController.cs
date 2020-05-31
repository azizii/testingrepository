using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using testingproj.Models;

namespace testingproj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class myfoodsController : ControllerBase
    {
        private readonly testingprojContext _context;

        public myfoodsController(testingprojContext context)
        {
            _context = context;
        }

        // GET: api/myfoods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<myfoods>>> Getfood()
        {
            string serverPathTowwwrootFolder = "images/";
            //All food table record
            var ad = _context.Myfoods.ToList();

            for (int i = 0; i < ad.Count; i++)
            {
                ad[i].photopath = serverPathTowwwrootFolder + ad[i].photopath;
            }

            return ad;
        }

        // GET: api/myfoods
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<myfoods>>> GetMyfoods()
        //{
        //    return await _context.Myfoods.ToListAsync();
        //}

        // GET: api/myfoods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<myfoods>> Getmyfoods(int id)
        {
            var myfoods = await _context.Myfoods.FindAsync(id);

            if (myfoods == null)
            {
                return NotFound();
            }

            return myfoods;
        }

        // PUT: api/myfoods/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putmyfoods(int id, myfoods myfoods)
        {
            if (id != myfoods.myfoodsId)
            {
                return BadRequest();
            }

            _context.Entry(myfoods).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!myfoodsExists(id))
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



        [HttpPost]
        public string Post([FromBody]check value)
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

        // POST: api/myfoods
        //[HttpPost]
        //public async Task<ActionResult<myfoods>> Postmyfoods(myfoods myfoods)
        //{
        //    _context.Myfoods.Add(myfoods);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("Getmyfoods", new { id = myfoods.myfoodsId }, myfoods);
        //}

        // DELETE: api/myfoods/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<myfoods>> Deletemyfoods(int id)
        {
            var myfoods = await _context.Myfoods.FindAsync(id);
            if (myfoods == null)
            {
                return NotFound();
            }

            _context.Myfoods.Remove(myfoods);
            await _context.SaveChangesAsync();

            return myfoods;
        }

        private bool myfoodsExists(int id)
        {
            return _context.Myfoods.Any(e => e.myfoodsId == id);
        }
    }
}
