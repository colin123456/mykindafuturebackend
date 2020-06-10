using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Starships",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    Starship_class = table.Column<string>(nullable: true),
                    Max_atmosphering_speed = table.Column<int>(nullable: false),
                    Cost_in_credits = table.Column<int>(nullable: false),
                    Passengers = table.Column<int>(nullable: false),
                    TotalFilms = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Starships", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Starships");
        }
    }
}
