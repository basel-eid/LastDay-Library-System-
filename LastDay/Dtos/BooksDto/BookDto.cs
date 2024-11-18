using System.ComponentModel.DataAnnotations;

namespace LastDay.Dtos.BooksDto
{
    public class BookDto
    {
        [Required(ErrorMessage = "The Title is required")]
        public string? Title { get; set; }
        public DateTime? PublishedDate { get; set; }
        public List<AuthorDtoForGet> Authors { get; set; }
        public List<GenreDto>? Genres { get; set; }
    }
}
