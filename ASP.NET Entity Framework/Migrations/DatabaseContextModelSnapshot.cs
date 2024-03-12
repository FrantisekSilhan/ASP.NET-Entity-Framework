﻿// <auto-generated />
using ASP.NET_Entity_Framework.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASP.NET_Entity_Framework.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("ASP.NET_Entity_Framework.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GameId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            GameId = 1,
                            Name = "GTA V"
                        },
                        new
                        {
                            GameId = 2,
                            Name = "The Witcher 3"
                        },
                        new
                        {
                            GameId = 3,
                            Name = "Stardew Valley"
                        },
                        new
                        {
                            GameId = 4,
                            Name = "Civilization VI"
                        });
                });

            modelBuilder.Entity("ASP.NET_Entity_Framework.Models.GameGenre", b =>
                {
                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenreId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GameId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("GameGenre");

                    b.HasData(
                        new
                        {
                            GameId = 1,
                            GenreId = 1
                        },
                        new
                        {
                            GameId = 1,
                            GenreId = 2
                        },
                        new
                        {
                            GameId = 2,
                            GenreId = 1
                        },
                        new
                        {
                            GameId = 2,
                            GenreId = 2
                        },
                        new
                        {
                            GameId = 2,
                            GenreId = 3
                        },
                        new
                        {
                            GameId = 3,
                            GenreId = 1
                        },
                        new
                        {
                            GameId = 3,
                            GenreId = 2
                        },
                        new
                        {
                            GameId = 3,
                            GenreId = 5
                        },
                        new
                        {
                            GameId = 4,
                            GenreId = 1
                        },
                        new
                        {
                            GameId = 4,
                            GenreId = 2
                        },
                        new
                        {
                            GameId = 4,
                            GenreId = 3
                        },
                        new
                        {
                            GameId = 4,
                            GenreId = 4
                        });
                });

            modelBuilder.Entity("ASP.NET_Entity_Framework.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            Name = "Action"
                        },
                        new
                        {
                            GenreId = 2,
                            Name = "Adventure"
                        },
                        new
                        {
                            GenreId = 3,
                            Name = "RPG"
                        },
                        new
                        {
                            GenreId = 4,
                            Name = "Simulation"
                        },
                        new
                        {
                            GenreId = 5,
                            Name = "Strategy"
                        });
                });

            modelBuilder.Entity("ASP.NET_Entity_Framework.Models.GameGenre", b =>
                {
                    b.HasOne("ASP.NET_Entity_Framework.Models.Game", "Game")
                        .WithMany("GameGenres")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASP.NET_Entity_Framework.Models.Genre", "Genre")
                        .WithMany("GameGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("ASP.NET_Entity_Framework.Models.Game", b =>
                {
                    b.Navigation("GameGenres");
                });

            modelBuilder.Entity("ASP.NET_Entity_Framework.Models.Genre", b =>
                {
                    b.Navigation("GameGenres");
                });
#pragma warning restore 612, 618
        }
    }
}