using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_Entity_Framework.Models {
    public class GameGenre {
        [ForeignKey(nameof(GameId))]
        public int GameId { get; set; }
        public Game? Game { get; set; }
        [ForeignKey(nameof(GenreId))]
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
    }
}
