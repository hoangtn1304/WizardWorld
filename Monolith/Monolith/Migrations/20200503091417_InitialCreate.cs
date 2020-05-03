using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monolith.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Birthdate = table.Column<string>(nullable: true),
                    Bio = table.Column<string>(nullable: true),
                    Sex = table.Column<int>(nullable: false),
                    Race = table.Column<int>(nullable: false),
                    Descent = table.Column<int>(nullable: false),
                    MaritalStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
