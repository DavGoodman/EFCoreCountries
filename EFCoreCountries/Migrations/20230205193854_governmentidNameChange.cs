using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreCountries.Migrations
{
    /// <inheritdoc />
    public partial class governmentidNameChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Governments_GovernmentId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "SystemId",
                table: "Countries");

            migrationBuilder.AlterColumn<int>(
                name: "GovernmentId",
                table: "Countries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "GovernmentId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2,
                column: "GovernmentId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3,
                column: "GovernmentId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4,
                column: "GovernmentId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 5,
                column: "GovernmentId",
                value: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Governments_GovernmentId",
                table: "Countries",
                column: "GovernmentId",
                principalTable: "Governments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Governments_GovernmentId",
                table: "Countries");

            migrationBuilder.AlterColumn<int>(
                name: "GovernmentId",
                table: "Countries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SystemId",
                table: "Countries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GovernmentId", "SystemId" },
                values: new object[] { null, 4 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "GovernmentId", "SystemId" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "GovernmentId", "SystemId" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "GovernmentId", "SystemId" },
                values: new object[] { null, 5 });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "GovernmentId", "SystemId" },
                values: new object[] { null, 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Governments_GovernmentId",
                table: "Countries",
                column: "GovernmentId",
                principalTable: "Governments",
                principalColumn: "Id");
        }
    }
}
