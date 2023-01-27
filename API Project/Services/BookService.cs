using API_Models;
using API_Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

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
            var res = appContext.Books.Select(x => new Book()
            {
                Name= x.Name
            }).ToListAsync();
            return await res;
        }

        public async Task<Book> GetBookByName(string name)
        {
            return await appContext.Books
                .FirstOrDefaultAsync(e => e.Name == name);
        }

        public async Task<Book> AddBook(Book book)
        {
            book.Id = Guid.NewGuid();
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
                result.Name = book.Name;
                result.Author = book.Author;
                result.BookPages = book.BookPages;
                result.ReleaseYear = book.ReleaseYear;

                await appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Book> RemoveBook(Guid id)
        {
            var result = await appContext.Books
                .FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {
                appContext.Books.Remove(result);
                await appContext.SaveChangesAsync();
            }
            return null;
            //         try
            //        {
            //            var owner = _repository.Owner.GetOwnerById(id);
            //            if (owner == null)
            //            {
            //                _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
            //                return NotFound();
            //            }
            //            _repository.Owner.DeleteOwner(owner);
            //            _repository.Save();
            //            return NoContent();
            //        }
            //catch (Exception ex)
            //        {
            //            _logger.LogError($"Something went wrong inside DeleteOwner action: {ex.Message}");
            //            return StatusCode(500, "Internal server error");
            //        }
        }

     

    
    }

    }