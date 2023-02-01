using API_Models.Context;
using API_Models.Models;
using API_Models.Models.VModels.Authorization;
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
        private readonly IAuthService authService;
        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm]RegisterVModel model)
        {
                var result = await authService.Register(model);
                if (!result.Succeeded)
                {
                    return BadRequest(new AuthResponse()
                    {
                        Errors = new List<string>()
                        {
                            "Email Already exists!",
                        },
                        Result = false,
                    });    
                }
                return Ok(new AuthResponse()
                {
                    Result = true,
                });
            
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login ([FromForm] LoginVModel model)
        {
            var jwtResult = await authService.Login(model);
            return Ok(jwtResult);
        }




        //private readonly UserManager<User> userManager;
        //private readonly IConfiguration configuration;

        //public AuthController(UserManager<User> userManager, IConfiguration configuration)
        //{

        //    this.configuration = configuration;
        //    this.userManager = userManager;

        //}
        //[AllowAnonymous]
        //[HttpPost]
        //[Route("Register")]
        //public async Task<IActionResult> Register([FromForm] RegisterVModel model)
        //{
        //    var checkUser = await userManager.FindByEmailAsync(model.Email);
        //    if (checkUser != null)
        //    {
        //        return BadRequest(new AuthResponse()
        //        {
        //            Result = true,
        //            Errors = new List<string>()
        //                {
        //                    "Email already exists!"
        //                }
        //        });
        //    }
        //    var user = new User()
        //    {
        //        Email = model.Email,
        //        UserName = model.Username,

        //    };
        //    var create = await userManager.CreateAsync(user, model.Password);

        //    if (!create.Succeeded)
        //    {  
        //        return BadRequest(new AuthResponse()
        //        {
        //            Errors = new List<string>()
        //            {
        //                "Server Error"
        //            },

        //            Result = false,
        //        });
        //    }
        //    await userManager.AddToRoleAsync(user, "User");
        //    var token = GenerateJwtToken(user);
        //    return Ok(new AuthResponse()
        //    {

        //        Result = true,
        //        Token = token
        //    });
        //}
    

        
        //[AllowAnonymous]
        //[HttpPost]
        //[Route("login")]
        //public async Task<IActionResult> Login([FromForm] LoginVModel model)
        //{       
        //    if (ModelState.IsValid)
        //    {
        //        var user = await userManager.FindByNameAsync(model.Username);
        //        if (user != null)
        //        {
        //            var correct = await userManager.CheckPasswordAsync(user, model.Password);
        //            if (correct)
        //            {
                        
        //                var token = GenerateJwtToken(user);
        //                return Ok(new AuthResponse()
        //                {
        //                    Result = true,
        //                    Token = token,
        //                });
        //            }
        //            return BadRequest(new AuthResponse()
        //            {
        //                Errors = new List<string>() 
        //                { 
        //                    "Username or Password are incorrect!"
        //                }
                        
        //            });
                    
        //        }
        //    }
        //    return BadRequest();
        //}
        
        //private string GenerateJwtToken(User user)
        //{
        //    var role = userManager.GetRolesAsync(user);
        //    IdentityOptions options = new IdentityOptions();
        //    var jwtTokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(configuration.GetSection("Jwt:Secret").Value);

        //    var tokenDescriptor = new SecurityTokenDescriptor()
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim("UserId", user.Id.ToString()),
        //            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
        //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //            //  new Claim(JwtRegisteredClaimNames.Aud, configuration.GetSection("Jwt:ValidAudience").Value),
        //            new Claim(JwtRegisteredClaimNames.Iss, configuration["Jwt:ValidIssuer"]),
        //           // new Claim(options.ClaimsIdentity.RoleClaimType, role.FirstOrDefault()!)
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(1),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        //    };
        //    var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        //    return jwtTokenHandler.WriteToken(token);
        //
        //
        // }

    }
}
