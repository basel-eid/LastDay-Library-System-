using LastDay.Dtos;
using LastDay.Dtos.BooksDto;
using LastDay.Repos.AuthorRepos;
using LastDay.Repos.BookRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LastDay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepo _repo;
        public AuthorsController(IAuthorRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var s = _repo.GetBooks();
            if (s == null)
            {
                return NotFound();
            }
            return Ok(s);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var s = _repo.GetBook(id);
            if (s == null)
            {
                return NotFound();
            }
            return Ok(s);
        }
        [HttpPost]
        public IActionResult Post(AuthorDto bookDto)
        {
            _repo.AddAuthor(bookDto);
            return Created();
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(AuthorDto bookDto, int id)
        {
            _repo.UpdateAuthor(bookDto, id);
            return Accepted();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _repo.DeleteAuthor(id);
            return Accepted();
        }
    }
}
