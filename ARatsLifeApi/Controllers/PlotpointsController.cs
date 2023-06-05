// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ARatsLifeApi.Models;

namespace ARatsLifeApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlotpointsController : ControllerBase
{
  private readonly ARatsLifeApiContext _context;

  public PlotpointsController(ARatsLifeApiContext context)
  {
    _context = context;
  }

  // GET: api/Plotpoints
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Plotpoint>>> GetPlotpoints()
  {
    return await _context.Plotpoints.ToListAsync();
  }

  // GET: api/Plotpoints/5
  [HttpGet("{id}")]
  public async Task<ActionResult<Plotpoint>> GetPlotpoint(int id)
  {
    var plotpoint = await _context.Plotpoints.FindAsync(id);

    if (plotpoint == null)
    {
      return NotFound();
    }

    return plotpoint;
  }

  // PUT: api/Plotpoints/5
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPut("{id}")]
  public async Task<IActionResult> PutPlotpoint(int id, Plotpoint plotpoint)
  {
    if (id != plotpoint.PlotpointId)
    {
      return BadRequest();
    }

    _context.Entry(plotpoint).State = EntityState.Modified;

    try
    {
      await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!PlotpointExists(id))
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

  // POST: api/Plotpoints
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPost]
  public async Task<ActionResult<Plotpoint>> PostPlotpoint(Plotpoint plotpoint)
  {
    _context.Plotpoints.Add(plotpoint);
    await _context.SaveChangesAsync();

    return CreatedAtAction("GetPlotpoint", new { id = plotpoint.PlotpointId }, plotpoint);
  }

  // DELETE: api/Plotpoints/5
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeletePlotpoint(int id)
  {
    var plotpoint = await _context.Plotpoints.FindAsync(id);
    if (plotpoint == null)
    {
      return NotFound();
    }

    _context.Plotpoints.Remove(plotpoint);
    await _context.SaveChangesAsync();

    return NoContent();
  }

  private bool PlotpointExists(int id)
  {
    return _context.Plotpoints.Any(e => e.PlotpointId == id);
  }
}