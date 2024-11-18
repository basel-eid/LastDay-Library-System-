using System.ComponentModel.DataAnnotations;

namespace LastDay.Dtos.BooksDto
{
    public class BookDTOFORAuthor
    {
        [Required(ErrorMessage = "The Title is required")]
        public string? Title { get; set; }
        public DateTime? PublishedDate { get; set; }
        public List<GenreDto> GenresDto { get; set; }
    }
}
