using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dateland.Test2.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityID);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    EducationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.EducationID);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    FoodID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.FoodID);
                });

            migrationBuilder.CreateTable(
                name: "GenderPreferations",
                columns: table => new
                {
                    GenderPreferationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderPreferationType = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderPreferations", x => x.GenderPreferationID);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    GenderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderType = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderID);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestID);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieID);
                });

            migrationBuilder.CreateTable(
                name: "Music",
                columns: table => new
                {
                    MusicID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusicGenre = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Music", x => x.MusicID);
                });

            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    ProfessionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessionName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.ProfessionID);
                });

            migrationBuilder.CreateTable(
                name: "Relations",
                columns: table => new
                {
                    RelationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelationType = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relations", x => x.RelationID);
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
                    ProfilePictureUrl = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    GenderID = table.Column<int>(nullable: false),
                    FoodID = table.Column<int>(nullable: false),
                    MovieID = table.Column<int>(nullable: false),
                    MusicID = table.Column<int>(nullable: false),
                    EducationID = table.Column<int>(nullable: false),
                    InterestID = table.Column<int>(nullable: false),
                    CityID = table.Column<int>(nullable: false),
                    GenderPreferationID = table.Column<int>(nullable: false),
                    RelationID = table.Column<int>(nullable: false),
                    ProfessionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Educations_EducationID",
                        column: x => x.EducationID,
                        principalTable: "Educations",
                        principalColumn: "EducationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Foods_FoodID",
                        column: x => x.FoodID,
                        principalTable: "Foods",
                        principalColumn: "FoodID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Genders_GenderID",
                        column: x => x.GenderID,
                        principalTable: "Genders",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_GenderPreferations_GenderPreferationID",
                        column: x => x.GenderPreferationID,
                        principalTable: "GenderPreferations",
                        principalColumn: "GenderPreferationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Interests_InterestID",
                        column: x => x.InterestID,
                        principalTable: "Interests",
                        principalColumn: "InterestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Music_MusicID",
                        column: x => x.MusicID,
                        principalTable: "Music",
                        principalColumn: "MusicID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Professions_ProfessionID",
                        column: x => x.ProfessionID,
                        principalTable: "Professions",
                        principalColumn: "ProfessionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Relations_RelationID",
                        column: x => x.RelationID,
                        principalTable: "Relations",
                        principalColumn: "RelationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCityRelations",
                columns: table => new
                {
                    UserCityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: true),
                    CityID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCityRelations", x => x.UserCityID);
                    table.ForeignKey(
                        name: "FK_UserCityRelations_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCityRelations_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserEducationRelations",
                columns: table => new
                {
                    UserEducationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: true),
                    EducationID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEducationRelations", x => x.UserEducationID);
                    table.ForeignKey(
                        name: "FK_UserEducationRelations_Educations_EducationID",
                        column: x => x.EducationID,
                        principalTable: "Educations",
                        principalColumn: "EducationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserEducationRelations_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserGenderPreferationRelations",
                columns: table => new
                {
                    UserGenderPreferationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: true),
                    GenderPreferationID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGenderPreferationRelations", x => x.UserGenderPreferationID);
                    table.ForeignKey(
                        name: "FK_UserGenderPreferationRelations_GenderPreferations_GenderPreferationID",
                        column: x => x.GenderPreferationID,
                        principalTable: "GenderPreferations",
                        principalColumn: "GenderPreferationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserGenderPreferationRelations_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserInterestRelations",
                columns: table => new
                {
                    UserInterestID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: true),
                    InterestID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterestRelations", x => x.UserInterestID);
                    table.ForeignKey(
                        name: "FK_UserInterestRelations_Interests_InterestID",
                        column: x => x.InterestID,
                        principalTable: "Interests",
                        principalColumn: "InterestID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserInterestRelations_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserProfessionRelations",
                columns: table => new
                {
                    UserProfessionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: true),
                    ProfessionID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfessionRelations", x => x.UserProfessionID);
                    table.ForeignKey(
                        name: "FK_UserProfessionRelations_Professions_ProfessionID",
                        column: x => x.ProfessionID,
                        principalTable: "Professions",
                        principalColumn: "ProfessionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfessionRelations_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRelationRelations",
                columns: table => new
                {
                    UserRelationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _FirstUserIDUserID = table.Column<int>(nullable: true),
                    _SecondUserIDUserID = table.Column<int>(nullable: true),
                    RelationID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRelationRelations", x => x.UserRelationID);
                    table.ForeignKey(
                        name: "FK_UserRelationRelations_Relations_RelationID",
                        column: x => x.RelationID,
                        principalTable: "Relations",
                        principalColumn: "RelationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRelationRelations_Users__FirstUserIDUserID",
                        column: x => x._FirstUserIDUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRelationRelations_Users__SecondUserIDUserID",
                        column: x => x._SecondUserIDUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCityRelations_CityID",
                table: "UserCityRelations",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_UserCityRelations_UserID",
                table: "UserCityRelations",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserEducationRelations_EducationID",
                table: "UserEducationRelations",
                column: "EducationID");

            migrationBuilder.CreateIndex(
                name: "IX_UserEducationRelations_UserID",
                table: "UserEducationRelations",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserGenderPreferationRelations_GenderPreferationID",
                table: "UserGenderPreferationRelations",
                column: "GenderPreferationID");

            migrationBuilder.CreateIndex(
                name: "IX_UserGenderPreferationRelations_UserID",
                table: "UserGenderPreferationRelations",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterestRelations_InterestID",
                table: "UserInterestRelations",
                column: "InterestID");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterestRelations_UserID",
                table: "UserInterestRelations",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfessionRelations_ProfessionID",
                table: "UserProfessionRelations",
                column: "ProfessionID");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfessionRelations_UserID",
                table: "UserProfessionRelations",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRelationRelations_RelationID",
                table: "UserRelationRelations",
                column: "RelationID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRelationRelations__FirstUserIDUserID",
                table: "UserRelationRelations",
                column: "_FirstUserIDUserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRelationRelations__SecondUserIDUserID",
                table: "UserRelationRelations",
                column: "_SecondUserIDUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityID",
                table: "Users",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EducationID",
                table: "Users",
                column: "EducationID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FoodID",
                table: "Users",
                column: "FoodID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GenderID",
                table: "Users",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GenderPreferationID",
                table: "Users",
                column: "GenderPreferationID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_InterestID",
                table: "Users",
                column: "InterestID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MovieID",
                table: "Users",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MusicID",
                table: "Users",
                column: "MusicID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfessionID",
                table: "Users",
                column: "ProfessionID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RelationID",
                table: "Users",
                column: "RelationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCityRelations");

            migrationBuilder.DropTable(
                name: "UserEducationRelations");

            migrationBuilder.DropTable(
                name: "UserGenderPreferationRelations");

            migrationBuilder.DropTable(
                name: "UserInterestRelations");

            migrationBuilder.DropTable(
                name: "UserProfessionRelations");

            migrationBuilder.DropTable(
                name: "UserRelationRelations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "GenderPreferations");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Music");

            migrationBuilder.DropTable(
                name: "Professions");

            migrationBuilder.DropTable(
                name: "Relations");
        }
    }
}
