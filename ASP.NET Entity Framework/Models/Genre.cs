using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Entity_Framework.Models {
    public class Genre {
        public int GenreId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public ICollection<GameGenre> GameGenres { get; set; } = new List<GameGenre>();
    }
}
