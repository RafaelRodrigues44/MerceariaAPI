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

namespace MerceariaAPI.Areas.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthController> _logger;
        private readonly IUserRepository _userRepository;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration, ILogger<AuthController> logger, IUserRepository userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            _logger.LogInformation("Login attempt for user: {Username}", model.Username);

            // Obtenha as credenciais de login do repositório
            var (username, passwordHash) = await _userRepository.GetLoginCredentials(model.Username);

            if (username == null || passwordHash == null)
            {
                _logger.LogWarning("User not found: {Username}", model.Username);
                return Unauthorized("User not found.");
            }

            // Cria uma instância ApplicationUser com o nome de usuário e a senha
            var user = new ApplicationUser { UserName = username, PasswordHash = passwordHash };

            // Verifica se a senha fornecida corresponde à senha armazenada no banco de dados
            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            _logger.LogInformation("Password: {Password}", model.Password);

            if (!result.Succeeded)
            {
                _logger.LogWarning("Invalid password for user: {Username}", model.Username);
                _logger.LogWarning("Hash of user: {PasswordHash}", passwordHash);
                return Unauthorized("Invalid password.");
            }

            var token = GenerateJwtToken(username);
            _logger.LogInformation("Login successful for user: {Username}", model.Username);
            return Ok(new { token });
        }


        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        private string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, username)
            };

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
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
