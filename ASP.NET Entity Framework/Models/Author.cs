using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Entity_Framework.Models {
    public class Author {
        public int AuthorId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
    }
}
