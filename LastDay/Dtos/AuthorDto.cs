using LastDay.Dtos.BooksDto;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LastDay.Dtos
{
    //For Add ,Update
    public class AuthorDto
    {
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string? EmailAddress { get; set; }
        public string? Phone { get; set; }

        public List<BookDTOFORAuthor> BooksDtoForAuthor { get; set; }
        //public List <GenreDto> GenresDtoForAuthor { get; set; }
        

    }
    //For Update and Add
    public class AuthorDtoForGet
    {
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string? EmailAddress { get; set; }
        public string? Phone { get; set; }

        public List<BookDto> BooksDto { get; set; }
        //public List<GenreDto> GenresDtoForAuthor { get; set; }




    }
}
