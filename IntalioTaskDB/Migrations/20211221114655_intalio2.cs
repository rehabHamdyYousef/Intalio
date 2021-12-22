using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IntalioTaskDB.Migrations
{
    public partial class intalio2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "countryCurrencyRates",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    USDRate = table.Column<string>(type: "text", nullable: true),
                    EURRate = table.Column<string>(type: "text", nullable: true),
                    country_code = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countryCurrencyRates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_countryCurrencyRates_Countries_country_code",
                        column: x => x.country_code,
                        principalTable: "Countries",
                        principalColumn: "country_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_countryCurrencyRates_country_code",
                table: "countryCurrencyRates",
                column: "country_code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "countryCurrencyRates");
        }
    }
}
