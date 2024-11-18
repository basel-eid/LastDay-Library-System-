using LastDay.Dtos.BooksDto;
using System.ComponentModel.DataAnnotations;

namespace LastDay.Dtos
{
    public class GenreDto
    {
        [Required]
        public string? Name { get; set; }
        //public IList<BookDto>? Books { get; set; }
    }
}
