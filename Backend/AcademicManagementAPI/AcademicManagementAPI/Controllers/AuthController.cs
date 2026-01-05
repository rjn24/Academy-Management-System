using AcademicManagementAPI.Data;
using AcademicManagementAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;



[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
  private readonly ApplicationDbContext _context;
  private readonly IConfiguration _config;

  public AuthController(ApplicationDbContext context, IConfiguration config)
  {
    _context = context;
    _config = config;
  }

  [HttpPost("login")]
  public IActionResult Login(User login)
  {
    var user = _context.Users
        .FirstOrDefault(u =>
            u.Username == login.Username &&
            u.PasswordHash == login.PasswordHash);

    if (user == null)
      return Unauthorized("Invalid credentials");

    var claims = new[]
    {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
        };

    var key = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

    var token = new JwtSecurityToken(
        issuer: _config["Jwt:Issuer"],
        audience: _config["Jwt:Audience"],
        claims: claims,
        expires: DateTime.Now.AddMinutes(
            Convert.ToDouble(_config["Jwt:DurationInMinutes"])),
        signingCredentials: new SigningCredentials(
            key, SecurityAlgorithms.HmacSha256)
    );

    return Ok(new
    {
      token = new JwtSecurityTokenHandler().WriteToken(token)
    });
  }
}
