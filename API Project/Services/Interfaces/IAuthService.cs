using API_Models.Models;
using API_Models.Models.VModels.Authorization;

namespace API_Project.Services.Interfaces
{
    public interface IAuthService
    {
       Task<RegisterVModel> Register (RegisterVModel model);
            
        
    }
}
