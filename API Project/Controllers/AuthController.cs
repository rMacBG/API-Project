using API_Models.Models;
using API_Models.Models.AuthRequests;
using API_Project.Services.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthController(UserManager<User> userManager)
        {
            UserManager = userManager;
        }

        [HttpPost]
        public ActionResult<RegisterVModel>Register (RegisterVModel model)
        {
            var userCheck = UserManager.FindByEmailAsync(model.Email);
        }

    }
}
