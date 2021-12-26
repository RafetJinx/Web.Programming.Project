using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProject.Migrations
{
    public partial class SummonerCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Summoner",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PuuId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ProfileIconId = table.Column<int>(type: "int", nullable: false),
                    RevisionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SummonerLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Summoner", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Summoner");
        }
    }
}
