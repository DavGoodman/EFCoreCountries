using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreCountries.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Systems_SystemId",
                table: "Countries");

            migrationBuilder.DropTable(
                name: "Systems");

            migrationBuilder.DropIndex(
                name: "IX_Countries_SystemId",
                table: "Countries");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Leaders",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Party",
                table: "Leaders",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "LanguageName",
                table: "Languages",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "GovernmentId",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Governments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SystemDescription = table.Column<string>(type: "varchar(max)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "GovernmentId", "Name", "Population", "GovernmentId" },
                values: new object[,]
                {
                    { 1, null, "Norway", 5400000, 4 },
                    { 2, null, "Iceland", 370000, 2 },
                    { 3, null, "Hungary", 9700000, 2 },
                    { 4, null, "China", 5400000, 5 },
                    { 5, null, "Norway", 332000000, 1 }
                });

            migrationBuilder.InsertData(
                table: "Governments",
                columns: new[] { "Id", "SystemDescription", "SystemName" },
                values: new object[,]
                {
                    { 1, "A presidential system, or single executive system, is a form of government in which a head of government, typically with the title of president, leads an executive branch that is separate from the legislative branch in systems that use separation of powers.", "Presidential Republic" },
                    { 2, "A parliamentary republic is a republic that operates under a parliamentary system of government where the executive branch derives its legitimacy from and is accountable to the legislature.", "Parliamentary Republic" },
                    { 3, "Absolute monarchy is a form of monarchy in which the monarch rules in their own right or power. In an absolute monarchy, the king or queen is by no means limited and has absolute power.", "Absolute Monarchy" },
                    { 4, "A constitutional monarchy, parliamentary monarchy, or democratic monarchy is a form of monarchy in which the monarch exercises their authority in accordance with a constitution and is not alone in decision making.", "Constitutional Monarchy" },
                    { 5, "A one-party state, single-party state, one-party system,de-facto one-party state or single-party system is a type of sovereign state in which only one political party has the right to form the government, usually based on the existing constitution.", "One Party State" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "LanguageName" },
                values: new object[,]
                {
                    { 1, "English" },
                    { 2, "Norwegian" },
                    { 3, "Icelandic" },
                    { 4, "Sami" },
                    { 5, "Mandarin" },
                    { 6, "Hungarian" },
                    { 7, "Cantonese" }
                });

            migrationBuilder.InsertData(
                table: "CountriesLanguages",
                columns: new[] { "CountryId", "LanguageId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 4 },
                    { 2, 3 },
                    { 3, 6 },
                    { 4, 5 },
                    { 4, 7 },
                    { 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "Leaders",
                columns: new[] { "Id", "CountryId", "Name", "Party" },
                values: new object[,]
                {
                    { 1, 4, "Xi Jinping", "Chinese Communist Party" },
                    { 2, 1, "Jonas Gahr Støre", "Labour Party" },
                    { 3, 2, "Katrín Jakobsdóttir", "Left Green" },
                    { 4, 5, "JoeBiden", "Democratic Party" },
                    { 5, 3, "Orban Viktor", "Fidesz" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_GovernmentId",
                table: "Countries",
                column: "GovernmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Governments_GovernmentId",
                table: "Countries",
                column: "GovernmentId",
                principalTable: "Governments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Governments_GovernmentId",
                table: "Countries");

            migrationBuilder.DropTable(
                name: "Governments");

            migrationBuilder.DropIndex(
                name: "IX_Countries_GovernmentId",
                table: "Countries");

            migrationBuilder.DeleteData(
                table: "CountriesLanguages",
                keyColumns: new[] { "CountryId", "LanguageId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CountriesLanguages",
                keyColumns: new[] { "CountryId", "LanguageId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "CountriesLanguages",
                keyColumns: new[] { "CountryId", "LanguageId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "CountriesLanguages",
                keyColumns: new[] { "CountryId", "LanguageId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "CountriesLanguages",
                keyColumns: new[] { "CountryId", "LanguageId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "CountriesLanguages",
                keyColumns: new[] { "CountryId", "LanguageId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "CountriesLanguages",
                keyColumns: new[] { "CountryId", "LanguageId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "Leaders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Leaders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Leaders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Leaders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Leaders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "Party",
                table: "Leaders");

            migrationBuilder.DropColumn(
                name: "GovernmentId",
                table: "Countries");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Leaders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "LanguageName",
                table: "Languages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

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
                name: "IX_Countries_SystemId",
                table: "Countries",
                column: "GovernmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Systems_SystemId",
                table: "Countries",
                column: "GovernmentId",
                principalTable: "Systems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
