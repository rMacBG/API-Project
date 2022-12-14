using API_Models;
using API_Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API_Project.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibContext _context;

        public BooksController(LibContext context)
        {
            _context = context;
        }

        [HttpGet]
        
      public ActionResult<IEnumerable<Book>> GetBooks() =>
         _context.Books;
        
    }
}
