using API_Models.Context;
using API_Models.Models;
using API_Models.Models.AuthRequests;
using API_Models.Models.requests;
using API_Models.Models.VModels;
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
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;

        public AuthController(UserManager<User> userManager, IConfiguration configuration)
        {

            this.configuration = configuration;
            this.userManager = userManager;

        }
        [HttpPost]
        [Route ("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterVModel model)
        {

        //    var checkUser = await userManager.FindByEmailAsync(model.Email);
        //    if (checkUser == null)
        //    {
        //        var user = new User()
        //        {
        //            Email = model.Email,
        //            UserName = model.Username
        //        };
        //        var result = await userManager.CreateAsync(user, model.Password);
        //        if (result.Succeeded)
        //        {
        //            return Ok(result);
        //            var token = GenerateJwtToken(user);
        //            return Ok(new AuthResponse()
        //            {
        //                Token = token,
        //                Result = true,
        //            });
        //        }
        //        return BadRequest();
        //    }

        //    return Ok();


           
            if (ModelState.IsValid)
            {
                var checkUser = await userManager.FindByEmailAsync(model.Email);
                if (checkUser != null)
                {
                    return BadRequest(new AuthResponse()
        {
                        Result = true,
                        Errors = new List<string>()
                        {
                            "Email already exists!"
                        }
                    });
                }
                var user = new User()
                {
                    Email = model.Email,
                    UserName = model.Username,

                };
                var create = await userManager.CreateAsync(user, model.Password);
                
                if (create.Succeeded)
                {
                    var token = GenerateJwtToken(user);
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
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginVModel model)
        {       
            if (ModelState.IsValid)
            {
                var checkUser = await userManager.FindByNameAsync(model.Username);
                if (checkUser != null)
                {
                    var correct = await userManager.CheckPasswordAsync(checkUser, model.Password);
                    if (correct)
                    {
                        var token = GenerateJwtToken(checkUser);
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
                            "Username or Password are incorrect!"
                        }

                    });   
                }
              
            }
            return BadRequest();
        //    if (ModelState.IsValid)
        //    {
        //        var existingUser = await userManager.FindByNameAsync(model.Username);

        //        if (existingUser != null)
        //        {
        //            return BadRequest(new AuthResponse
        //            {

        //                Errors = new List<string>()
        //        {
        //            "Login unsuccessful!"
        //        },
        //                Result = false
        //            });
        //        }
        //        var Correct = await userManager.CheckPasswordAsync(existingUser, model.Password);
        //        if (!Correct)
        //        {
        //            return BadRequest(new AuthResponse()
        //            {
        //                Errors = new List<string>()
        //            {
        //                "Invalid Credentials"
        //            },
        //                Result = false
        //            });
        //        }
        //          var jwtToken = GenerateJwtToken(existingUser);
        //        return Ok(new AuthResponse()
        //        {
        //            Result = true,
        //            Token = jwtToken,
        //        });
        //    }
        //    return BadRequest();

        }

        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration.GetSection("Jwt:Secret").Value);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                }),
                Expires = DateTime.Now.AddMinutes(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);


        }

    }
}
