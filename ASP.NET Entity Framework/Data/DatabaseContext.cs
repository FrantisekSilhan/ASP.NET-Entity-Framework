using ASP.NET_Entity_Framework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ASP.NET_Entity_Framework.Data {
    public class DatabaseContext(DbContextOptions<DatabaseContext> options): DbContext(options) {
        #region DbSets
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameGenre> GameGenre { get; set; }
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

            modelBuilder.Entity<Game>().HasData(
                new Game { GameId = 1, Name = "GTA V" },
                new Game { GameId = 2, Name = "The Witcher 3" },
                new Game { GameId = 3, Name = "Stardew Valley" },
                new Game { GameId = 4, Name = "Civilization VI" }
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
                new { GameId = 4, GenreId = 4 }  // Civilization VI - Simulation
            );
        }
    }
}
