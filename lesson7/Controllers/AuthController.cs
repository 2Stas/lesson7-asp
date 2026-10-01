using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using lesson7.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace lesson7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        [HttpGet("/Auth/Login")]
        public IActionResult LoginView()
        {
            return View("Login");
        }

        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            if (user.Username != "qwe12" || user.Password != "qwerty123")
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secret_key228_qwerty123ytrewqzxcvbnmhgfdsa")
            );

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { Token = tokenString });
        }
    }
}