using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreCountries.Migrations
{
    /// <inheritdoc />
    public partial class fixseedmistakes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4,
                column: "Population",
                value: 1412400000);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "USA");

            migrationBuilder.UpdateData(
                table: "Leaders",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Joe Biden");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                table: "Countries",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Countries_Name",
                table: "Countries");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4,
                column: "Population",
                value: 5400000);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Norway");

            migrationBuilder.UpdateData(
                table: "Leaders",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "JoeBiden");
        }
    }
}
