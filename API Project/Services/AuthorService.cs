using API_Models.Context;
using API_Models.Models;
using API_Project.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Project.Services
{
    public class AuthorService :IAuthorService
    {
        private readonly LibContext appContext;

        public AuthorService(LibContext appContext)
        {
            this.appContext = appContext;
        }
        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await appContext.Authors.ToListAsync();
        }

        public async Task<Author> Create(Author author)
        {
            author.Id = Guid.NewGuid();
            var result = await appContext.Authors.AddAsync(author);
            await appContext.SaveChangesAsync();
            return result.Entity;
        }


        public async Task<Author> Update(Author author)
        {
          var result = await appContext.Authors
                .FirstOrDefaultAsync(x => x.Id == author.Id);
            if (result != null) 
            {
                result.FullName = author.FullName;
                result.FullName = author.FullName;

                await appContext.SaveChangesAsync();
                return result;
            }
            return null;
            
        }
        public async Task<Author> Delete(Guid id)
        {
            var result = await appContext.Authors
                .FirstOrDefaultAsync(x => x.Id == id);
            if (id != null)
            {
                appContext.Authors.Remove(result);
                 await appContext.SaveChangesAsync();
            }
            return null;
        }
    }
}
