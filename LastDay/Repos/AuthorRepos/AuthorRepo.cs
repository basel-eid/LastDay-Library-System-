using LastDay.Data;
using LastDay.Dtos;
using LastDay.Dtos.BooksDto;
using LastDay.Models;
using Microsoft.EntityFrameworkCore;

namespace LastDay.Repos.AuthorRepos
{
    public class AuthorRepo : IAuthorRepo
    {
        private readonly DataContext _context;
        public AuthorRepo(DataContext context)
        {
            _context = context;
        }
        public void AddAuthor(AuthorDto authorDto)
        {
            var a = new Author
            {
                EmailAddress = authorDto.EmailAddress,
                Name = authorDto.Name,
                Phone = authorDto.Phone,
                
                
                Books = authorDto.BooksDtoForAuthor.Select(y => new Book
                {

                    Title = y.Title,
                    PublishedDate = y.PublishedDate,
                    Genres = y.GenresDto.Select(y => new Genre
                    { 
                        Name = y.Name
                    }).ToList()
                }).ToList(),
            };
            _context.Authors.Add(a);
            _context.SaveChanges();
        }

        public void AddAuthorOnly(AuthorDto authorDto)
        {
            var a = new Author
            {
                EmailAddress = authorDto.EmailAddress,
                Name = authorDto.Name,
                Phone = authorDto.Phone,

            };
            _context.Authors.Add(a);
            _context.SaveChanges();
        }

        public void DeleteAuthor(int id)
        {
            var x = _context.Authors.Include(x=> x.Books).FirstOrDefault(x=>x.Id == id);
            if (x != null)
            {
                _context.Authors.Remove(x);
                _context.SaveChanges();
            }
            return;
        }

        public AuthorDtoForGet GetBook(int id)
        {
            var b = _context.Authors.Include(x => x.Books).FirstOrDefault(x => x.Id == id);
            return new AuthorDtoForGet
            {
                Name = b.Name,
                Phone = b.Phone,
                EmailAddress = b.EmailAddress,
                BooksDto = b.Books.Select(o => new BookDto
                {
                    Title = o.Title,
                    PublishedDate = o.PublishedDate,
                    Genres = o.Genres.Select(x=> new GenreDto
                    {
                        Name=x.Name,
                    }).ToList(),
                }).ToList(),
              
            };
        }

        public IEnumerable<AuthorDtoForGet> GetBooks()
        {
            var auth = _context.Authors.
                Include(x => x.Books).
                ThenInclude(x => x.Genres)
                .Select(y => new AuthorDtoForGet
                {
                                Name = y.Name,
                                Phone = y.Phone,
                                EmailAddress = y.EmailAddress,
                                
                                BooksDto = y.Books.Select(x => new BookDto
                                {
                                    Title = x.Title,
                                    PublishedDate = x.PublishedDate,
                                    Genres = x.Genres.Select(x=>new GenreDto { Name=x.Name}).ToList(),
                                }).ToList(),
                            }).ToList();
            return auth;
        }

        public void UpdateAuthor(AuthorDto authorDto, int id)
        {
            var book = _context.Authors.Include(x => x.Books).ThenInclude(x => x.Genres).FirstOrDefault(x => x.Id == id);
            book.Name = authorDto.Name;
            book.Phone = authorDto.Phone;
            book.EmailAddress = authorDto.EmailAddress;
            book.Books = authorDto.BooksDtoForAuthor.Select(x => new Book
            {
                Title = x.Title,
                PublishedDate = x.PublishedDate,
                Genres = x.GenresDto.Select(y => new Genre
                {
                    Name = y.Name
                }).ToList()
            }).ToList();
            
            _context.Authors.Update(book);
            _context.SaveChanges();
        }


    }
}

