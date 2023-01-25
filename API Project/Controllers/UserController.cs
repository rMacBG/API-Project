using API_Models.Models;
using API_Models.Requests.Authentication_Requests;
using API_Project.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService= userService;
        }
        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Authentication(AuthenticationRequest user)
        {
            var result = _userService.Authenticate(user);
            if (result == null) {
                return BadRequest(new { message = "Username or password is incorrect"}); 
            }
            return Ok(result);
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetAll() 
        { 
            var users = _userService.GetAll();
            return Ok(users);
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public  IActionResult Register(RegisterRequest model) 
        {
            _userService.Register(model);
            return Ok(new { message = "Registration Successful!" });

        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }
        [HttpPut("{id}")]
        public IActionResult Update(UpdateRequest user, Guid id)
        {
            _userService.Update(id, user);
            return Ok(new { message = "User update successful!"});
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _userService.Delete(id);
            return Ok(new {message = "User deleted successfully!"});
        }

    }
}
