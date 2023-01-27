using API_Models.Models;

namespace API_Project.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<Author> Create(Author author);
        Task<Author> Update(Author author);
        Task<Author> Delete(Guid id);
    }
}
