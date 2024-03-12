using ASP.NET_Entity_Framework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ASP.NET_Entity_Framework.Data {
    public class DatabaseContext(DbContextOptions<DatabaseContext> options): DbContext(options) {
        #region DbSets
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameGenre> GameGenre { get; set; }
        public DbSet<Author> Authors { get; set; }
        #endregion //DbSets
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            Genre actionGenre = new Genre { GenreId = 1, Name = "Action" };
            Genre adventureGenre = new Genre { GenreId = 2, Name = "Adventure" };
            Genre rpgGenre = new Genre { GenreId = 3, Name = "RPG" };
            Genre simulationGenre = new Genre { GenreId = 4, Name = "Simulation" };
            Genre strategyGenre = new Genre { GenreId = 5, Name = "Strategy" };

            modelBuilder.Entity<GameGenre>()
                .HasKey(gg => new { gg.GameId, gg.GenreId });

            modelBuilder.Entity<GameGenre>()
                .HasOne(gg => gg.Game)
                .WithMany(g => g.GameGenres)
                .HasForeignKey(gg => gg.GameId);

            modelBuilder.Entity<GameGenre>()
                .HasOne(gg => gg.Genre)
                .WithMany(g => g.GameGenres)
                .HasForeignKey(gg => gg.GenreId);

            modelBuilder.Entity<Genre>().HasData(
                actionGenre,
                adventureGenre,
                rpgGenre,
                simulationGenre,
                strategyGenre
            );

            Game gtaV = new Game { GameId = 1, Name = "GTA V", AuthorId = 1 };
            Game theWitcher3 = new Game { GameId = 2, Name = "The Witcher 3", AuthorId = 2 };
            Game stardewValley = new Game { GameId = 3, Name = "Stardew Valley", AuthorId = 3 };
            Game civilizationVI = new Game { GameId = 4, Name = "Civilization VI", AuthorId = 4 };
            Game abyssRal = new Game { GameId = 5, Name = "Abyss Ral", AuthorId = 4 };

            modelBuilder.Entity<Game>().HasData(
                gtaV,
                theWitcher3,
                stardewValley,
                civilizationVI,
                abyssRal
            );

            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorId = 1, FirstName = "František", LastName = "Vomáčka" },
                new Author { AuthorId = 2, FirstName = "Janek", LastName = "Radeček" },
                new Author { AuthorId = 3, FirstName = "Petr", LastName = "Mucha" },
                new Author { AuthorId = 4, FirstName = "Brugi", LastName = "Kozlovský" }
            );

            modelBuilder.Entity<GameGenre>().HasData(
                new { GameId = 1, GenreId = 1 }, // GTA V - Action
                new { GameId = 1, GenreId = 2 }, // GTA V - Adventure
                new { GameId = 2, GenreId = 1 }, // The Witcher 3 - Action
                new { GameId = 2, GenreId = 2 }, // The Witcher 3 - Adventure
                new { GameId = 2, GenreId = 3 }, // The Witcher 3 - RPG
                new { GameId = 3, GenreId = 1 }, // Stardew Valley - Action
                new { GameId = 3, GenreId = 2 }, // Stardew Valley - Adventure
                new { GameId = 3, GenreId = 5 }, // Stardew Valley - Strategy
                new { GameId = 4, GenreId = 1 }, // Civilization VI - Action
                new { GameId = 4, GenreId = 2 }, // Civilization VI - Adventure
                new { GameId = 4, GenreId = 3 }, // Civilization VI - RPG
                new { GameId = 4, GenreId = 4 },  // Civilization VI - Simulation
                new { GameId = 5, GenreId = 4 }
            );
        }
    }
}
