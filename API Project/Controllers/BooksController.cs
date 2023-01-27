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
        private readonly IBookService bookService;
        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
           return await bookService.GetBooks();
        }
        [HttpGet("{name}")]
        public async Task<ActionResult<Book>> GetBookById(string name)
        {
            if (name == null)
            {
                return NotFound();
                    //(IEnumerable<Book>)BadRequest(); 

            }
            await bookService.GetBookByName(name);
            return Ok(name);
        }
        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(Book book)
        {
           await bookService.AddBook(book);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult<Book>>UpdateBook(Book book)
        {
            if (book == null)
            {
                return NotFound();
            }
            await bookService.UpdateBook(book);
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult<Book>> RemoveBook(Guid guid)
        {
            if (guid == null)
            {
                return NotFound();
            }
            bookService.RemoveBook(guid);
            return Ok();
        }
    }
}
