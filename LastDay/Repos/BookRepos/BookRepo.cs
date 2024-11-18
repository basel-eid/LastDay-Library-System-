using LastDay.Data;
using LastDay.Dtos;
using LastDay.Dtos.BooksDto;
using LastDay.Models;
using Microsoft.EntityFrameworkCore;

namespace LastDay.Repos.BookRepos
{
    public class BookRepo : IBookRepo
    {
        private readonly DataContext _context;
        public BookRepo(DataContext context)
        {
            _context = context;
        }
        public void AddBook(CreateBookDto bookDto)
        {
            var book = new Book
            {
                PublishedDate = bookDto.PublishedDate,
                Title = bookDto.Title,
                Genres = bookDto.Genres.Select(x => new Genre
                {
                    Name = x.Name,
                }).ToList(),
                Authors = bookDto.Authors.Select(x=> new Author { 
                    Name = x.Name,
                    EmailAddress = x.EmailAddress,
                    Phone = x.Phone,
                }).ToList(),
            };
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void AddBookOnly(CreateBookDto bookDto)
        {
            var book = new Book
            {
                Title = bookDto.Title,
                PublishedDate = bookDto.PublishedDate,
                Authors = _context.Authors.Where(x => bookDto.AuthorId.Contains(x.Id)).ToList(),
                Genres = _context.Genres.Where(x => bookDto.GenreId.Contains(x.Id)).ToList(),
            };
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var x = _context.Books.FirstOrDefault(x=>x.Id == id);
            if(x != null)
            {
                _context.Books.Remove(x);
                _context.SaveChanges();
            }
            return;
        }

        public BookDto GetBook(int id)
        {
            var b = _context.Books.Include(x=> x.Genres).Include(x=> x.Authors).FirstOrDefault(x=> x.Id == id);
            return new BookDto
            {
                Title = b.Title,
                PublishedDate = b.PublishedDate,
                Authors = b.Authors.Select(o => new AuthorDtoForGet
                {
                    Name = o.Name,
                    EmailAddress = o.EmailAddress,
                    Phone = o.Phone,
                }).ToList(),
                Genres = b.Genres.Select(x=> new GenreDto
                {
                    Name = x.Name
                }).ToList(),
            };
            
        }

        public IEnumerable<BookDto> GetBooks()
        {
            var books = _context.Books.Include(x => x.Genres).Include(x => x.Authors).Select(

                x => new BookDto
                {
                    Title = x.Title,
                    PublishedDate = x.PublishedDate,
                    Authors = x.Authors.Select(x => new AuthorDtoForGet
                    {
                        Name = x.Name,
                        EmailAddress = x.EmailAddress,
                        Phone = x.Phone,
                    }).ToList(),
                    Genres = x.Genres.Select(x => new GenreDto
                    {
                        Name = x.Name
                    }).ToList()
                }).ToList();
                return books;
        }

        public void UpdateBook(CreateBookDto bookDto, int id)
        {
            var book = _context.Books.Include(x=> x.Genres).Include(x=> x.Authors).FirstOrDefault(x=>x.Id == id);
            book.Title = bookDto.Title;
            book.PublishedDate = bookDto.PublishedDate;
            book.Authors = bookDto.Authors.Select(x => new Author
            {
                EmailAddress = x.EmailAddress,
                Phone = x.Phone,
                Name = x.Name,
            }).ToList();
            book.Genres = bookDto.Genres.Select(o => new Genre
            {
                Name = o.Name,
            }).ToList();
            _context.Books.Update(book);
            _context.SaveChanges();
        }
    }
}
