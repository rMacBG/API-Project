using API_Models.Configs;
using API_Models.Models;
using API_Models.Models.AuthRequests;
using API_Models.Models.requests;
using API_Project.Services.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;
        public AuthController(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromRoute] RegisterVModel model)
        {
           
            if (ModelState.IsValid)
            {
                var userExists = await userManager.FindByEmailAsync(model.Email);
                if (userExists != null)
                {
                    return BadRequest(new AuthResponse()
                    {
                        Result= true,
                        Errors = new List<string>()
                        {
                            "Email already exists!"
                        }
                    });
                }
                var newUser = new IdentityUser()
                {
                    Email = model.Email,
                    UserName = model.Username,
               
                };
                var isCreated = await userManager.CreateAsync(newUser, model.Password);
                if (isCreated.Succeeded)
                {
                    var token = GenerateJwtToken(newUser);
                    return Ok(new AuthResponse()
                    {
                        Result = true,
                        Token = token,
                    });
                }
                return BadRequest(new AuthResponse()
                {
                    Errors = new List<string>()
                    {
                        "Server Error"
                    },
                    Result = false
                });

            }

            return BadRequest();
        }
        [HttpGet]
        [Route("login")]
        public Task<IActionResult> Login([FromRoute])

        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(configuration.GetSection("JwtConfig:Secret").Value);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Email, value:user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString())
                }),
                Expires = DateTime.Now.AddMinutes(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token =  jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);

           
        }

    }
}
