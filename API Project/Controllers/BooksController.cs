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
        [Route("Get All Books")]
        
        public async Task<IEnumerable<Book>> GetBooks()
        {
           return await bookService.GetBooks();
        }
        [HttpGet("Get Books by Id")]
        public async Task<ActionResult<Book>> GetBookById([FromRoute] string name)
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
        [Route("Create a Book")]
        public async Task<ActionResult<Book>> AddBook([FromRoute] Book book)
        {
           await bookService.AddBook(book);
            return Ok();
        }
        [HttpPut]
        [Route("Update a Book")]
        public async Task<ActionResult<Book>>UpdateBook([FromRoute] Book book)
        {
            if (book == null)
            {
                return NotFound();
            }
            await bookService.UpdateBook(book);
            return Ok();
        }
        [HttpDelete]
        [Route("Delete a Book")]
        public async Task<ActionResult<Book>> RemoveBook([FromRoute] Guid guid)
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
