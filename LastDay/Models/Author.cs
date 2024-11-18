using System.ComponentModel.DataAnnotations;

namespace LastDay.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string? EmailAddress { get; set; }
        public string? Phone { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
