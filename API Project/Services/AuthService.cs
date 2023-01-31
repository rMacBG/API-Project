using API_Models.Context;
using API_Models.Models;
using API_Models.Models.VModels.Authorization;
using API_Project.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace API_Project.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;
        public AuthService(UserManager<User> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }
        public async Task<IdentityResult> Register(RegisterVModel model)
        {
            var user = new User
            {
                UserName = model.Username,
                Email = model.Email,

            };
            var result = await userManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                return result;
            }
            await userManager.AddToRoleAsync(user, "User");
            return result;
        }
        public async Task<string> Login(LoginVModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (!(user != null || await userManager.CheckPasswordAsync(user, model.Password)))
            {
                return null;
            }
            var role = await userManager.GetRolesAsync(user);

            IdentityOptions options = new IdentityOptions();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration.GetSection("Jwt:Secret").Value);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserId", user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),   
                    new Claim(JwtRegisteredClaimNames.Iss, configuration["Jwt:ValidIssuer"]),
                    new Claim(options.ClaimsIdentity.RoleClaimType, role.FirstOrDefault()!)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var jwtToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(jwtToken);

            return token;
        }
    }
}
