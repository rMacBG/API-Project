using API_Models.Models;
using API_Models.Models.AuthRequests;

namespace API_Project.Services.Interfaces
{
    public interface IAuthService
    {
       Task<RegisterVModel> Register (RegisterVModel model);
    }
}
