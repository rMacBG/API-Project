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
        public async Task<IEnumerable<Book>> GetBookById(string name)
        {
            if (name == null)
            {
                return (IEnumerable<Book>)BadRequest();

            }
            await bookService.GetBookByName(name);
            return (IEnumerable<Book>)Ok(name);
        }
        [HttpPost]
        public async Task<IEnumerable<Book>> AddBook(Book book)
        {
           await bookService.AddBook(book);
            return (IEnumerable<Book>)Ok();
        }
        [HttpPut]
        public async Task<IEnumerable<Book>>UpdateBook(Book book)
        {
            await bookService.UpdateBook(book);
            return (IEnumerable<Book>)Ok();
        }
        [HttpDelete]
        public async Task<IEnumerable<Book>> RemoveBook(Guid guid)
        {
            bookService.RemoveBook(guid);
            return (IEnumerable<Book>)Ok();
        }
    }
}
