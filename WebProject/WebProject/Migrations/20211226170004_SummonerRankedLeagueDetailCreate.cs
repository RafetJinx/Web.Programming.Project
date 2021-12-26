using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProject.Migrations
{
    public partial class SummonerRankedLeagueDetailCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SummonerRankedLeagueDetail",
                columns: table => new
                {
                    LeagueId = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    QueueType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tier = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    SummonerId = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    LeaguePoint = table.Column<int>(type: "int", nullable: false),
                    Win = table.Column<int>(type: "int", nullable: false),
                    Losses = table.Column<int>(type: "int", nullable: false),
                    Veteran = table.Column<bool>(type: "bit", nullable: false),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    FreshBlood = table.Column<bool>(type: "bit", nullable: false),
                    HotStreak = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummonerRankedLeagueDetail", x => x.LeagueId);
                    table.ForeignKey(
                        name: "FK_SummonerRankedLeagueDetail_Summoner_SummonerId",
                        column: x => x.SummonerId,
                        principalTable: "Summoner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SummonerRankedLeagueDetail_SummonerId",
                table: "SummonerRankedLeagueDetail",
                column: "SummonerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SummonerRankedLeagueDetail");
        }
    }
}
