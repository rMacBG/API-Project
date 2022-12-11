using API_Models;

namespace API_Project.Controllers
{
    public interface IBookService
    {
        
        Task<List<Book>> GetBooks();
        Task<List<Book>> PostBooks();
        Task<List<Book>>GetBooksByName(string name); 
        void AddBook(Book book);
        void RemoveBook(Book book);
    }
}