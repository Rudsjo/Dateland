using Microsoft.EntityFrameworkCore.Migrations;

namespace Dateland.Test2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    IntrestID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntrestName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.IntrestID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    EmailConfirmed = table.Column<int>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: false),
                    Salt = table.Column<string>(nullable: false),
                    ProfilePictureUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "UserIntrestRelations",
                columns: table => new
                {
                    UserIntrestID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: true),
                    IntrestID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserIntrestRelations", x => x.UserIntrestID);
                    table.ForeignKey(
                        name: "FK_UserIntrestRelations_Interests_IntrestID",
                        column: x => x.IntrestID,
                        principalTable: "Interests",
                        principalColumn: "IntrestID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserIntrestRelations_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserIntrestRelations_IntrestID",
                table: "UserIntrestRelations",
                column: "IntrestID");

            migrationBuilder.CreateIndex(
                name: "IX_UserIntrestRelations_UserID",
                table: "UserIntrestRelations",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserIntrestRelations");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
