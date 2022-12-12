using API_Models;

namespace API_Project.Controllers
{
    public interface IBookService
    {
        
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBookById(Guid guid);
        Task<Book> AddBook(Book book);
        Task<Book> UpdateBook(Book book);
        void RemoveBook(Guid guid);
    }
}