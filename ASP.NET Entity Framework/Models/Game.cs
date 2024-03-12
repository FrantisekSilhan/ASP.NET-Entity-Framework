using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Entity_Framework.Models {
    public class Game {
        public int GameId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public ICollection<GameGenre> GameGenres { get; set; } = new List<GameGenre>();
    }
}
