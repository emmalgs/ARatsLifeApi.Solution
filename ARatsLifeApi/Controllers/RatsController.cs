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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Rat>>> GetRats()
    {
      return await _context.Rats
                              .Include(r => r.ItemInventory)
                              .Include(r => r.Journey)
                              .ToListAsync();
    }

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

    [HttpPost]
    public async Task<ActionResult<Rat>> PostRat(Rat rat)
    {
      _context.Rats.Add(rat);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetRat", new { id = rat.RatId }, rat);
    }

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

    // GET Journey
    [HttpGet("/{id}/journey")]
    public async Task<ActionResult<Journey>> GetJourney(int id)
    {
      return await _context.Journies
                                  .FirstOrDefaultAsync(e => e.RatId == id);
    }

    [HttpPost("{id}/journey")]
    public async Task<ActionResult<Journey>> PostJourney(Journey journey)
    {
      _context.Journies.Add(journey);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetRat", new { id = journey.JourneyId }, journey);
    }
    private bool RatExists(int id)
    {
      return _context.Rats.Any(e => e.RatId == id);
    }
  }
}
