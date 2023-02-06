using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreCountries.Migrations
{
    /// <inheritdoc />
    public partial class CountriesLanguages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Leaders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GovernmentId",
                table: "Countries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CountriesLanguages",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountriesLanguages", x => new { x.CountryId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_CountriesLanguages_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountriesLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Systems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Systems", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leaders_CountryId",
                table: "Leaders",
                column: "CountryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_SystemId",
                table: "Countries",
                column: "GovernmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CountriesLanguages_LanguageId",
                table: "CountriesLanguages",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Systems_SystemId",
                table: "Countries",
                column: "GovernmentId",
                principalTable: "Systems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Leaders_Countries_CountryId",
                table: "Leaders",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Systems_SystemId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Leaders_Countries_CountryId",
                table: "Leaders");

            migrationBuilder.DropTable(
                name: "CountriesLanguages");

            migrationBuilder.DropTable(
                name: "Systems");

            migrationBuilder.DropIndex(
                name: "IX_Leaders_CountryId",
                table: "Leaders");

            migrationBuilder.DropIndex(
                name: "IX_Countries_SystemId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Leaders");

            migrationBuilder.DropColumn(
                name: "GovernmentId",
                table: "Countries");
        }
    }
}
