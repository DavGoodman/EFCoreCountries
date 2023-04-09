using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreCountries.Migrations
{
    /// <inheritdoc />
    public partial class Person : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Governments_GovernmentId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Leaders_Countries_CountryId",
                table: "Leaders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Leaders",
                table: "Leaders");

            migrationBuilder.DropIndex(
                name: "IX_Leaders_CountryId",
                table: "Leaders");

            migrationBuilder.RenameTable(
                name: "Leaders",
                newName: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "Population",
                table: "Countries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GovernmentId",
                table: "Countries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Party",
                table: "Persons",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Persons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HostCountryId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonType",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Age", "PersonType" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Age", "PersonType" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Age", "PersonType" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Age", "PersonType" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Age", "PersonType" },
                values: new object[] { null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CountryId",
                table: "Persons",
                column: "CountryId",
                unique: true,
                filter: "[CountryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CountryId1",
                table: "Persons",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_HostCountryId",
                table: "Persons",
                column: "HostCountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Governments_GovernmentId",
                table: "Countries",
                column: "GovernmentId",
                principalTable: "Governments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Countries_CountryId",
                table: "Persons",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Countries_HostCountryId",
                table: "Persons",
                column: "HostCountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Governments_GovernmentId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Countries_CountryId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Countries_CountryId1",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Countries_HostCountryId",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_CountryId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_CountryId1",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_HostCountryId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "HostCountryId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PersonType",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Leaders");

            migrationBuilder.AlterColumn<int>(
                name: "Population",
                table: "Countries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GovernmentId",
                table: "Countries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Party",
                table: "Leaders",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Leaders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Leaders",
                table: "Leaders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Leaders_CountryId",
                table: "Leaders",
                column: "CountryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Governments_GovernmentId",
                table: "Countries",
                column: "GovernmentId",
                principalTable: "Governments",
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
    }
}
