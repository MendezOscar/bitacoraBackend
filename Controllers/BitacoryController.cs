using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bitacorabackend.Data;
using bitacorabackend.Models;

namespace bitacorabackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BitacoryController : ControllerBase
    {
        private readonly DataContext _context;

        public BitacoryController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Bitacory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bitacory>>> GetBitacories()
        {
            return await _context.Bitacories.ToListAsync();
        }

        // GET: api/Bitacory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bitacory>> GetBitacory(int id)
        {
            var bitacory = await _context.Bitacories.FindAsync(id);

            if (bitacory == null)
            {
                return NotFound();
            }

            return bitacory;
        }

        [HttpGet("get-by-date/")]
        public async Task<ActionResult<Bitacory>> GetBitacoryByDate(DateTime date)
        {
            var bitacory = await _context.Bitacories.SingleOrDefaultAsync(x => x.date == date);

            if (bitacory == null)
            {
                return NotFound();
            }

            return bitacory;
        }

        [HttpGet("get-by-range-date/{date1}/{date2}")]
        public async Task<ActionResult<IEnumerable<Bitacory>>> GetBitacoryByRangeDate(string date1, string date2)
        {
            
            string date_ = date1.Substring(0,4) + '-' + date1.Substring(4,2) + '-' + date1.Substring(6,2);
            DateTime time1 = DateTime.Parse(date_);
            Console.WriteLine(time1);

            string date__ = date2.Substring(0,4) + '-' + date2.Substring(4,2) + '-' + date2.Substring(6,2);
            DateTime time2 = DateTime.Parse(date__);
            Console.WriteLine(time2);

            var bitacory = await _context.Bitacories.Where(x => x.InitialDate > time1 && x.FinalDate < time2).ToListAsync();

            if (bitacory == null)
            {
                return NotFound();
            }

            return bitacory;
        }
        

        // PUT: api/Bitacory/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBitacory(int id, Bitacory bitacory)
        {
            if (id != bitacory.id)
            {
                return BadRequest();
            }

            _context.Entry(bitacory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BitacoryExists(id))
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

        // POST: api/Bitacory
        [HttpPost]
        public async Task<ActionResult<Bitacory>> PostBitacory(Bitacory bitacory)
        {
            _context.Bitacories.Add(bitacory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBitacory", new { id = bitacory.id }, bitacory);
        }

        // DELETE: api/Bitacory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bitacory>> DeleteBitacory(int id)
        {
            var bitacory = await _context.Bitacories.FindAsync(id);
            if (bitacory == null)
            {
                return NotFound();
            }

            _context.Bitacories.Remove(bitacory);
            await _context.SaveChangesAsync();

            return bitacory;
        }

        private bool BitacoryExists(int id)
        {
            return _context.Bitacories.Any(e => e.id == id);
        }
    }
}
