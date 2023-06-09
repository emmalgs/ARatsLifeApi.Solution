using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ARatsLifeApi.Models;

namespace ARatsLifeApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class RatsController : ControllerBase
  {
    private readonly ARatsLifeApiContext _context;

    public RatsController(ARatsLifeApiContext context)
    {
      _context = context;
    }

    // GET: api/Rats
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Rat>>> GetRatsAsync()
    {
      return await _context.Rats.ToListAsync();
    }

    // GET: api/Rats/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Rat>> GetRat(int id)
    {
      var rat = await _context.Rats.FindAsync(id);

      if (rat == null)
      {
        return NotFound();
      }

      return rat;
    }

    // PUT: api/Rats/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRat(int id, Rat rat)
    {
      if (id != rat.RatId)
      {
        return BadRequest();
      }

      _context.Entry(rat).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!RatExists(id))
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

    // POST: api/Rats
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Rat>> PostRat(Rat rat)
    {
      _context.Rats.Add(rat);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetRat", new { id = rat.RatId }, rat);
    }

    // DELETE: api/Rats/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRat(int id)
    {
      var rat = await _context.Rats.FindAsync(id);
      if (rat == null)
      {
        return NotFound();
      }

      _context.Rats.Remove(rat);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool RatExists(int id)
    {
      return _context.Rats.Any(e => e.RatId == id);
    }
  }
}
