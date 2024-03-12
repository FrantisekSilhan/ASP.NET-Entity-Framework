using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASP.NET_Entity_Framework.Migrations
{
    /// <inheritdoc />
    public partial class _02Author : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Games",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "František", "Vomáčka" },
                    { 2, "Janek", "Radeček" },
                    { 3, "Petr", "Mucha" },
                    { 4, "Brugi", "Kozlovský" }
                });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 1,
                column: "AuthorId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 2,
                column: "AuthorId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 3,
                column: "AuthorId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 4,
                column: "AuthorId",
                value: 4);

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "AuthorId", "Name" },
                values: new object[] { 5, 4, "Abyss Ral" });

            migrationBuilder.InsertData(
                table: "GameGenre",
                columns: new[] { "GameId", "GenreId" },
                values: new object[] { 5, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Games_AuthorId",
                table: "Games",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Authors_AuthorId",
                table: "Games",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Authors_AuthorId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Games_AuthorId",
                table: "Games");

            migrationBuilder.DeleteData(
                table: "GameGenre",
                keyColumns: new[] { "GameId", "GenreId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Games");
        }
    }
}
