using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ARatsLifeApi.Models;
using Microsoft.AspNetCore.Identity;

namespace ARatsLifeApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
  private readonly ARatsLifeApiContext _context;
  private readonly UserManager<ApplicationUser> _userManager;
  private readonly SignInManager<ApplicationUser> _signInManager;

  public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ARatsLifeApiContext context)
  {
    _userManager = userManager;
    _signInManager = signInManager;
    _context = context;
  }

  // GET: api/Accounts
  [HttpGet]
  public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetUsers()
  {
    return await _context.Users.ToListAsync();
  }

  // GET: api/Accounts/5
  [HttpGet("{id}")]
  public async Task<ActionResult<ApplicationUser>> GetApplicationUser(string id)
  {
    var applicationUser = await _context.Users.FindAsync(id);

    if (applicationUser == null)
    {
      return NotFound();
    }

    return applicationUser;
  }

  // PUT: api/Accounts/5
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPut("{id}")]
  public async Task<IActionResult> PutApplicationUser(string id, ApplicationUser applicationUser)
  {
    if (id != applicationUser.Id)
    {
      return BadRequest();
    }

    _context.Entry(applicationUser).State = EntityState.Modified;

    try
    {
      await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!ApplicationUserExists(id))
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

  // POST: api/Accounts
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPost]
  public async Task<ActionResult<ApplicationUser>> PostApplicationUser(ApplicationUser applicationUser)
  {
    _context.Users.Add(applicationUser);
    try
    {
      await _context.SaveChangesAsync();
    }
    catch (DbUpdateException)
    {
      if (ApplicationUserExists(applicationUser.Id))
      {
        return Conflict();
      }
      else
      {
        throw;
      }
    }

    return CreatedAtAction("GetApplicationUser", new { id = applicationUser.Id }, applicationUser);
  }

  // DELETE: api/Accounts/5
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteApplicationUser(string id)
  {
    var applicationUser = await _context.Users.FindAsync(id);
    if (applicationUser == null)
    {
      return NotFound();
    }

    _context.Users.Remove(applicationUser);
    await _context.SaveChangesAsync();

    return NoContent();
  }

  private bool ApplicationUserExists(string id)
  {
    return _context.Users.Any(e => e.Id == id);
  }
}