using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_Entity_Framework.Models {
    public class Game {
        public int GameId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public ICollection<GameGenre> GameGenres { get; set; } = new List<GameGenre>();
        [ForeignKey(nameof(AuthorId))]
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
