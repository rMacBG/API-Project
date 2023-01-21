using API_Models;

namespace API_Project.Repositories.IRepositories
{
    public interface IBookRepository
    {
        List<Book> GetBooks { get; }
        Book GetBooksById(Guid id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Guid id);
        void Save();

    }
}
