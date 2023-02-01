using API_Models;
using API_Models.Models;
using API_Models.Models.VModels;
using API_Project.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin, User")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] AutorVModel model)
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
        [Authorize(Roles = "Admin, User")]
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] Author author)
        {
            if (author == null)
            {
                return NotFound();
            }
            await authorService.Update(author);
            return Ok(author);
        }
        [Authorize(Roles = "Admin, User")]
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete ([FromForm] Guid id)
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
