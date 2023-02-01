using API_Models;
using API_Models.Context;
using API_Models.Models.VModels;
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
            var res = appContext.Books.ToListAsync();
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

        public async Task RemoveBook(Guid id)
        {
            //var result = await appContext.Books.
            //    FindAsync(id);
            //    appContext.Books.Remove(result);
            //    await appContext.SaveChangesAsync();
            //return result;

            //appContext.Remove( new Book {Id = id });
            //await appContext.SaveChangesAsync();
            var result = await appContext.Books.FirstOrDefaultAsync(o => o.Id == id);
            if (result != null )
            {
                appContext.Books.Remove(result);
                appContext.SaveChangesAsync();
            }
                
                
            
            


        }

        
    }

    }