using Microsoft.EntityFrameworkCore.Migrations;

namespace Dateland.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Relations_RelationID",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RelationID",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RelationID",
                schema: "dbo",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RelationID",
                schema: "dbo",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RelationID",
                schema: "dbo",
                table: "Users",
                column: "RelationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Relations_RelationID",
                schema: "dbo",
                table: "Users",
                column: "RelationID",
                principalTable: "Relations",
                principalColumn: "RelationID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
