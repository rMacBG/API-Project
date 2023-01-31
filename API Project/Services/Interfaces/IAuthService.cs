using API_Models.Models;
using API_Models.Models.VModels.Authorization;
using Microsoft.AspNetCore.Identity;

namespace API_Project.Services.Interfaces
{
    public interface IAuthService
    {
      public Task<IdentityResult?> Register (RegisterVModel model);
        public Task<string> Login(LoginVModel model);
        
        
    }
}
