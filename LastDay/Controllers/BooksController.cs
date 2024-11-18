using LastDay.Dtos.BooksDto;
using LastDay.Repos.BookRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LastDay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepo _repo;
        public BooksController(IBookRepo repo)
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
        public IActionResult Post(CreateBookDto bookDto)
        {
            _repo.AddBook(bookDto);
            return Created();
        }
        [HttpPost("bookonly")]
        public IActionResult AddBookOnly(CreateBookDto bookDto)
        {
            _repo.AddBookOnly(bookDto);
            return Created();
        }
        [HttpPut("{id}")]
        public IActionResult Put(CreateBookDto bookDto, int id)
        {
            _repo.UpdateBook(bookDto, id);
            return Accepted();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _repo.DeleteBook(id);
            return Accepted();
        }
    }
}
