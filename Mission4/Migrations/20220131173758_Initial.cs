using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission4.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    categoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    category = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.categoryId);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    movieId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(nullable: false),
                    year = table.Column<int>(nullable: false),
                    director = table.Column<string>(nullable: false),
                    rating = table.Column<string>(nullable: false),
                    edited = table.Column<bool>(nullable: false),
                    lentTo = table.Column<string>(nullable: true),
                    note = table.Column<string>(maxLength: 25, nullable: true),
                    categoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.movieId);
                    table.ForeignKey(
                        name: "FK_Responses_categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "categories",
                        principalColumn: "categoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "categoryId", "category" },
                values: new object[] { 1, "Action/Adventure" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "categoryId", "category" },
                values: new object[] { 2, "Fantasy/Action" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "categoryId", "category" },
                values: new object[] { 3, "Sci-fi" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "movieId", "categoryId", "director", "edited", "lentTo", "note", "rating", "title", "year" },
                values: new object[] { 1, 1, "Christopher Nolan", false, null, null, "PG-13", "Inception", 2010 });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "movieId", "categoryId", "director", "edited", "lentTo", "note", "rating", "title", "year" },
                values: new object[] { 2, 2, "Haruo Sotozaki", false, null, "Watch TV show first", "R", "Demon Slayer: Kimetsu no Yaiba – The Movie: Mugen Train", 2020 });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "movieId", "categoryId", "director", "edited", "lentTo", "note", "rating", "title", "year" },
                values: new object[] { 3, 3, "George Lucas", false, "Mom", null, "PG", "Star Wars: Episode IV - A New Hope", 1977 });

            migrationBuilder.CreateIndex(
                name: "IX_Responses_categoryId",
                table: "Responses",
                column: "categoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
