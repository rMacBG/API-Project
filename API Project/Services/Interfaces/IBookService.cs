using API_Models;

namespace API_Project.Controllers
{
    public interface IBookService
    {
        
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBookByName(string name);
        Task<Book> AddBook(Book book);
        Task<Book> UpdateBook(Book book);
        Task<Book> RemoveBook(Guid id);
    }
}