using API_Models;
using API_Models.Context;
using API_Models.Models.VModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        [HttpGet]
        [Route("Get All Books")]
        
        public async Task<IEnumerable<Book>> GetBooks()
        {
           return await bookService.GetBooks();
        }
        [HttpGet("Get Books by Id")]
        [AllowAnonymous]
        public async Task<IActionResult> GetBookByName([FromBody] string name)
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
        public async Task<IActionResult> AddBook([FromForm] BookCreateVModel model)
        {
            var book = new Book
            {
                Name = model.Name,
                BookAuthor = model.BookAuthor,
                Description = model.Description,
                Category = model.Category,
                ReleaseYear = model.ReleaseYear,
                BookPages = model.BookPages,
            };
          var result = await bookService.AddBook(book);
            return CreatedAtAction(
                nameof(this.AddBook),
                new
                {
                    result = result.ToString()
                });
        }
        
        [HttpPut]
        [Route("Update a Book")]
        public async Task<IActionResult>UpdateBook([FromBody] Book book)
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
        public async Task<IActionResult> RemoveBook([FromBody] Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
           await bookService.RemoveBook(id);
            return Ok();
        }
    }
}
