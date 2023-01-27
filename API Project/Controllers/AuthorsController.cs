﻿using API_Models.Models;
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
        public async Task<ActionResult<Author>> Create(Author author)
        {
            if (author == null)
            {
                return NotFound();
            }
            await authorService.Create(author);
            return Ok(author);
        }
        [HttpPut]
        public async Task<ActionResult<Author>> Update(Author author)
        {
            if (author == null)
            {
                return NotFound();
            }
            await authorService.Update(author);
            return Ok(author);
        }
        [HttpDelete]
        public async Task<ActionResult<Author>> Delete (Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await authorService.Delete(id);
            return Ok();
        }
    }
}
