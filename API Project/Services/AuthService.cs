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
        public Task<RegisterVModel> Register(RegisterVModel model)
        {
            throw new NotImplementedException();
        }
    }
}
