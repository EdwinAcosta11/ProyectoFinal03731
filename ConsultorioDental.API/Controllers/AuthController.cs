using ConsultorioDental.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ConsultorioDental.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("registrar")]
        public IActionResult Registrar(Usuario usuario)
        {
            if (_context.Usuarios.Any(u => u.Correo == usuario.Correo))
                return BadRequest("Ese correo ya está registrado.");

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return Ok("Usuario registrado con éxito.");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Usuario usuario)
        {
            var usuarioExistente = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Correo == usuario.Correo && u.Clave == usuario.Clave);

            if (usuarioExistente == null)
            {
                return Unauthorized();
            }

            // Generar el token
            var claims = new[]
            {
        new Claim(ClaimTypes.Name, usuarioExistente.Nombre),
        new Claim(ClaimTypes.Email, usuarioExistente.Correo),
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
