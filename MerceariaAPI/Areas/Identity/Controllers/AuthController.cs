using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using System.Threading.Tasks;
using MerceariaAPI.Areas.Identity.Models;
using Microsoft.Extensions.Logging;
using MerceariaAPI.Areas.Identity.Repositories.User;
using MerceariaAPI.Areas.Identity.Repositories.Role;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace MerceariaAPI.Areas.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration, ILogger<AuthController> logger, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _logger = logger;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View("/Views/Auth/Login.cshtml");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var (username, passwordHash) = await _userRepository.GetLoginCredentials(model.Username);

            if (username == null || passwordHash == null)
            {
                return Unauthorized("User not found.");
            }

            var user = new ApplicationUser { UserName = username, PasswordHash = passwordHash };

            var passwordMatched = await _userRepository.CheckPasswordAsync(user, model.Password);

            if (passwordMatched)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var token = GenerateJwtToken(username, roles);

                HttpContext.Session.SetString("Token", token);
                HttpContext.Session.SetString("Username", username);

                var response = new
                {
                    Token = token,
                    Username = username
                };
                _logger.LogInformation("Response {response}", response);
                return Ok(response);
            }
            else
            {
                return Unauthorized("Invalid password.");
            }
        }

        private string GenerateJwtToken(string username, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, username)
            };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            try
            {
                // Realiza o logout do usuário
                await _signInManager.SignOutAsync();

                // Limpa a sessão
                HttpContext.Session.Clear();

                // Invalida o token JWT no cliente (opcional, dependendo de como você está gerenciando o token)
                // Por exemplo, você pode limpar cookies ou localStorage do lado do cliente

                _logger.LogInformation("User logged out successfully.");

                // Redireciona para a página inicial ou outra página após o logout
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during logout.");
                return StatusCode(500, "Internal server error");
            }
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class TokenModel
    {
        public string Token { get; set; }
        public string Username { get; set; }
    }
}

