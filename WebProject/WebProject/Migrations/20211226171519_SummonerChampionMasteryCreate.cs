using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProject.Migrations
{
    public partial class SummonerChampionMasteryCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SummonerChampionMastery",
                columns: table => new
                {
                    ChampionId = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ChampionLevel = table.Column<int>(type: "int", nullable: false),
                    ChampionPoint = table.Column<int>(type: "int", nullable: false),
                    LastPlayTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChestGranted = table.Column<bool>(type: "bit", nullable: false),
                    TokensEarned = table.Column<int>(type: "int", nullable: false),
                    SummonerId = table.Column<string>(type: "nvarchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummonerChampionMastery", x => x.ChampionId);
                    table.ForeignKey(
                        name: "FK_SummonerChampionMastery_Champion_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "Champion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SummonerChampionMastery_Summoner_SummonerId",
                        column: x => x.SummonerId,
                        principalTable: "Summoner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SummonerChampionMastery_SummonerId",
                table: "SummonerChampionMastery",
                column: "SummonerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SummonerChampionMastery");
        }
    }
}
