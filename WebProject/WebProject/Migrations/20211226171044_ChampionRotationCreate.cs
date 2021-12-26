using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProject.Migrations
{
    public partial class ChampionRotationCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChampionRotation",
                columns: table => new
                {
                    ChampionId = table.Column<string>(type: "nvarchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionRotation", x => x.ChampionId);
                    table.ForeignKey(
                        name: "FK_ChampionRotation_Champion_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "Champion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChampionRotation");
        }
    }
}
