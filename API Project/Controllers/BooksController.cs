using API_Models;
using Microsoft.AspNetCore.Mvc;



namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            return "I exist for now";
        }
    }
}
