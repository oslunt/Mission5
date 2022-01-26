using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission4.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    movieId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    category = table.Column<string>(nullable: false),
                    title = table.Column<string>(nullable: false),
                    year = table.Column<int>(nullable: false),
                    director = table.Column<string>(nullable: false),
                    rating = table.Column<string>(nullable: false),
                    edited = table.Column<bool>(nullable: false),
                    lentTo = table.Column<string>(nullable: true),
                    note = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.movieId);
                });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "movieId", "category", "director", "edited", "lentTo", "note", "rating", "title", "year" },
                values: new object[] { 1, "Action/Adventure", "Christopher Nolan", false, null, null, "PG-13", "Inception", 2010 });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "movieId", "category", "director", "edited", "lentTo", "note", "rating", "title", "year" },
                values: new object[] { 2, "Fantasy/Action", "Haruo Sotozaki", false, null, "Watch TV show first", "R", "Demon Slayer: Kimetsu no Yaiba – The Movie: Mugen Train", 2020 });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "movieId", "category", "director", "edited", "lentTo", "note", "rating", "title", "year" },
                values: new object[] { 3, "Sci-fi", "George Lucas", false, "Mom", null, "PG", "Star Wars: Episode IV - A New Hope", 1977 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");
        }
    }
}
