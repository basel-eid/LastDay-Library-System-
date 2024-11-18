using LastDay.Dtos;
using LastDay.Dtos.BooksDto;

namespace LastDay.Repos.AuthorRepos
{
    public interface IAuthorRepo
    {
        IEnumerable<AuthorDtoForGet> GetBooks();
        AuthorDtoForGet GetBook(int id);
        void UpdateAuthor(AuthorDto authorDto, int id);
        void AddAuthor(AuthorDto authorDto);
        void DeleteAuthor(int id);
        void AddAuthorOnly(AuthorDto authorDto);
    }
}
