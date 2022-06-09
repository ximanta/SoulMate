using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoulMate.API.data;

namespace SoulMate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoulMateController : ControllerBase
    {
        private readonly SoulMateDbContext _context;

        public SoulMateController(SoulMateDbContext context)
        {
            _context = context;
        }

        // GET: api/SoulMate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Soulmate>>> GetSoulMates()
        {
            return await _context.SoulMates.ToListAsync();
        }

        // GET: api/SoulMate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Soulmate>> GetSoulmate(int id)
        {
            var soulmate = await _context.SoulMates.FindAsync(id);

            if (soulmate == null)
            {
                return NotFound();
            }

            return soulmate;
        }

        // PUT: api/SoulMate/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoulmate(int id, Soulmate soulmate)
        {
            if (id != soulmate.Id)
            {
                return BadRequest();
            }

            _context.Entry(soulmate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoulmateExists(id))
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

        // POST: api/SoulMate
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Soulmate>> PostSoulmate(Soulmate soulmate)
        {
            _context.SoulMates.Add(soulmate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSoulmate", new { id = soulmate.Id }, soulmate);
        }

        // DELETE: api/SoulMate/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoulmate(int id)
        {
            var soulmate = await _context.SoulMates.FindAsync(id);
            if (soulmate == null)
            {
                return NotFound();
            }

            _context.SoulMates.Remove(soulmate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SoulmateExists(int id)
        {
            return _context.SoulMates.Any(e => e.Id == id);
        }
    }
}
