using System.ComponentModel.DataAnnotations;

namespace LastDay.Dtos.BooksDto
{
    public class CreateBookDto
    {
        [Required(ErrorMessage = "The Title is required")]
        public string? Title { get; set; }
        public DateTime? PublishedDate { get; set; }
        public List<int>? GenreId { get; set; }
        public List<int>? AuthorId { get; set; }
        public List<AuthorDto>? Authors { get; set; }
        public List<GenreDto>? Genres { get; set; }
    }
}
