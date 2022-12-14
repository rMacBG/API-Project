using API_Models;
using API_Models.Context;
using Microsoft.EntityFrameworkCore;

namespace API_Project.Controllers
{
    public class BookService : IBookService
    {
        private readonly LibContext appContext;
        public BookService(LibContext appContext)
        {
            this.appContext = appContext;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await appContext.Books.ToListAsync();
        }

        public async Task<Book> GetBookById(Guid guid)
        {
            return await appContext.Books
                .FirstOrDefaultAsync(e => e.Id == guid);
        }

        public async Task<Book> AddBook(Book book)
        {
            var result = await appContext.Books.AddAsync(book);
             await appContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Book> UpdateBook(Book book)
        {
           var result = await appContext.Books
                .FirstOrDefaultAsync(e => e.Id == book.Id);
            if (result != null) 
            {
                result.Name= book.Name;
                result.Author= book.Author;
                result.Description= book.Description;
                result.BookPages= book.BookPages;
                result.ReleaseYear= book.ReleaseYear;
                
                await appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async void RemoveBook(Guid guid)
        {
            var result = await appContext.Books
                .FirstOrDefaultAsync(e => e.Id == guid);
        }

       

       
    }




}