using LastDay.Dtos;
using LastDay.Dtos.BooksDto;

namespace LastDay.Repos.BookRepos
{
    public interface IBookRepo
    {
        IEnumerable<BookDto> GetBooks();
        BookDto GetBook(int id);
        void UpdateBook(CreateBookDto bookDto, int id);
        void AddBook(CreateBookDto bookDto);
        void DeleteBook(int id);
        void AddBookOnly(CreateBookDto bookDto);
    }
}
