using API_Models;
using API_Models.Models;
using API_Models.Models.VModels.CsvModels;
using API_Project.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService authorService;
        public AuthorsController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }
        [HttpGet("all")]
        public async Task<IEnumerable<Author>> GetAllAuthors() 
        { 
           return await authorService.GetAllAuthors();
           
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromRoute] AuthorVModel model)
        {
            if (model == null)
            {
                return NotFound();
            }
            var author = new Author
            {
                FullName = model.FullName,
            };
             var result = await authorService.Create(author);
            return CreatedAtAction(
                nameof(this.Create),
                new
                {
                    result = result.ToString()
                });

        }
        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] Author author)
        {
            if (author == null)
            {
                return NotFound();
            }
            await authorService.Update(author);
            return Ok(author);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete ([FromRoute] Guid id)
        {
            if (id != null)
            {
                await authorService.Delete(id);
                return Ok();
                
            }
            return NotFound();

        }
    }
}
