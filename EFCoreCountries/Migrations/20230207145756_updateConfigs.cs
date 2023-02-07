using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreCountries.Migrations
{
    /// <inheritdoc />
    public partial class updateConfigs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Countries_Name",
                table: "Countries");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_LanguageName",
                table: "Languages",
                column: "LanguageName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Governments_SystemName",
                table: "Governments",
                column: "SystemName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                table: "Countries",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Languages_LanguageName",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Governments_SystemName",
                table: "Governments");

            migrationBuilder.DropIndex(
                name: "IX_Countries_Name",
                table: "Countries");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                table: "Countries",
                column: "Name");
        }
    }
}
