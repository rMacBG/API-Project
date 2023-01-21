using API_Models;
using API_Models.Context;
using API_Models.Models;
using API_Project.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace API_Project.Repositories
{
    public class BookRepository : IBookRepository
    {
        private LibContext context;

        public BookRepository(LibContext context)
        {
            this.context = context;
        }

        public List<Book> GetBooks => throw new NotImplementedException();

        public void AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(Guid id)
        {
            Book book = context.Books.Find(id);
            context.Books.Remove(book);
        }

        //public List<Book> GetBooks => context.Books
        //    .Include(o => o.Author)
        //    .ThenInclude(o => o.FirstName)
        //    .Select(o => new Book()
        //    {
        //        Id = o.Id,
        //        Name = o.Name,
        //        Author = o.Author.Select(o => o.Author.FirstName).ToList(),
        //    }).ToList();


        //{
        //    return context.Books.ToList();
        //}

        public Book GetBooksById(Guid id)
        {
            return context.Books.Find(id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            throw new NotImplementedException(4);
        }
        public void UpdateBook(Book book)
        {
            throw new NotImplementedException(4);
        }
        public void UpdateBook(Book book)
        {
            throw new NotImplementedException(4);
        }
        public void UpdateBook(Book book)
        {
            throw new NotImplementedException(4);
        }
    }
}
