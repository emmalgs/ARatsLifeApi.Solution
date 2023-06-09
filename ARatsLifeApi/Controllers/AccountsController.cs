using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ARatsLifeApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ARatsLifeApi.DTO;
using System.Web;

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

  // [HttpGet("{id}")]
  // public async Task<ActionResult<ApplicationUser>> GetUser(int id)
  // {
  //   var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);

  // }


  // POST: api/accounts
  [HttpPost]
  public async Task<ActionResult<DTOGoodAccount>> RegisterAsync(DTORegisteredUser newUser)
  {
    var user = new ApplicationUser { UserName = newUser.Email};
    var result = await _userManager.CreateAsync(user, newUser.Password);

    if (result.Succeeded)
    {
      // TODO add identityOptions.User.RequireUniqueEmail
      var someUser = await _userManager.FindByNameAsync(newUser.Email);
      var token = await _userManager.GenerateUserTokenAsync(someUser, "Invitation", "Hummus");
      var isVerified = await _userManager.VerifyUserTokenAsync(someUser, "Invitation", "Hummus", token);

      var userConfirmed = new DTOGoodAccount 
      {
        Token = token,
        UserName = newUser.Email,
      };
      var header = "application/json";
      var json = System.Text.Json.JsonSerializer.Serialize(userConfirmed);
      Response.StatusCode = (int) HttpStatusCode.Accepted;

      // var domain = Request.Host.ToString();
      // var cookie = new Cookie("acceptMyDAMNCookie", token);
      // var cookieContainer = new CookieContainer();
      // cookieContainer.Add(new Uri($"http://{domain}"), cookie);
      Response.Cookies.Append("TokenCookie", token);
      

      return Content(json, header);
    }
      var errors = result.Errors.Select(e => e.Description);
      var bigErrorString = String.Join(" ", errors);

      return BadRequest(bigErrorString);
  }

  // [HttpPost]
  // public async Task<IActionResult> Login(string[] userInfo)
  // {
  //   Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(userInfo[0], userInfo[1], isPersistent: true, lockoutOnFailure: false);
  //   if (result.Succeeded)
  //   {
  //     var accessToken = GenerateJSONWebToken(userInfo[0]);
  //     SetJWTCookie(accessToken);
  //     return NoContent();
  //   }
  //   else
  //   {
  //     return BadRequest();
  //   }
  // }

  // private string GenerateJSONWebToken(string userEmail)
  // {
  //   var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MynameisJamesBond007"));
  //   var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
  //   var emailClaim = new Claim("email", userEmail);
  //   var claims = new List<Claim> { emailClaim };

  //   var token = new JwtSecurityToken(
  //       issuer: "http://localhost:5102",
  //       audience: "http://localhost:5257",
  //       expires: DateTime.Now.AddHours(3),
  //       signingCredentials: credentials,
  //       claims: claims
  //       );

  //   return new JwtSecurityTokenHandler().WriteToken(token);
  // }

  // private void SetJWTCookie(string token)
  // {
  //   var cookieOptions = new CookieOptions
  //   {
  //     HttpOnly = true,
  //     Expires = DateTime.UtcNow.AddHours(3),
  //   };
  //   Response.Cookies.Append("jwtCookie", token, cookieOptions);
  // }
}