﻿// <auto-generated />
using System;
using Dateland.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dateland.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dateland.Core.City", b =>
                {
                    b.Property<int>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("CityID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Dateland.Core.Education", b =>
                {
                    b.Property<int>("EducationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EducationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("EducationID");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("Dateland.Core.Food", b =>
                {
                    b.Property<int>("FoodID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FoodName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("FoodID");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("Dateland.Core.Gender", b =>
                {
                    b.Property<int>("GenderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenderType")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("GenderID");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("Dateland.Core.GenderPreferation", b =>
                {
                    b.Property<int>("GenderPreferationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenderPreferationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("GenderPreferationID");

                    b.ToTable("GenderPreferations");
                });

            modelBuilder.Entity("Dateland.Core.Interest", b =>
                {
                    b.Property<int>("InterestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InterestName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InterestID");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("Dateland.Core.Movie", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MovieName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("MovieID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Dateland.Core.Music", b =>
                {
                    b.Property<int>("MusicID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MusicGenre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("MusicID");

                    b.ToTable("Music");
                });

            modelBuilder.Entity("Dateland.Core.Profession", b =>
                {
                    b.Property<int>("ProfessionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProfessionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ProfessionID");

                    b.ToTable("Professions");
                });

            modelBuilder.Entity("Dateland.Core.Relation", b =>
                {
                    b.Property<int>("RelationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RelationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("RelationID");

                    b.ToTable("Relations");
                });

            modelBuilder.Entity("Dateland.Core.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int?>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<int?>("EducationID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FoodID")
                        .HasColumnType("int");

                    b.Property<int?>("GenderID")
                        .HasColumnType("int");

                    b.Property<int?>("GenderPreferationID")
                        .HasColumnType("int");

                    b.Property<int?>("InterestID")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("MovieID")
                        .HasColumnType("int");

                    b.Property<int?>("MusicID")
                        .HasColumnType("int");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("ProfessionID")
                        .HasColumnType("int");

                    b.Property<string>("ProfilePictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RelationID")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("CityID");

                    b.HasIndex("EducationID");

                    b.HasIndex("FoodID");

                    b.HasIndex("GenderID");

                    b.HasIndex("GenderPreferationID");

                    b.HasIndex("InterestID");

                    b.HasIndex("MovieID");

                    b.HasIndex("MusicID");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("ProfessionID");

                    b.HasIndex("RelationID");

                    b.ToTable("Users","dbo");
                });

            modelBuilder.Entity("Dateland.Core.UserCityRelation", b =>
                {
                    b.Property<int>("UserCityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserCityID");

                    b.HasIndex("CityID");

                    b.HasIndex("Id");

                    b.ToTable("UserCityRelations");
                });

            modelBuilder.Entity("Dateland.Core.UserEducationRelation", b =>
                {
                    b.Property<int>("UserEducationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EducationID")
                        .HasColumnType("int");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserEducationID");

                    b.HasIndex("EducationID");

                    b.HasIndex("Id");

                    b.ToTable("UserEducationRelations");
                });

            modelBuilder.Entity("Dateland.Core.UserGenderPreferationRelation", b =>
                {
                    b.Property<int>("UserGenderPreferationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GenderPreferationID")
                        .HasColumnType("int");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserGenderPreferationID");

                    b.HasIndex("GenderPreferationID");

                    b.HasIndex("Id");

                    b.ToTable("UserGenderPreferationRelations");
                });

            modelBuilder.Entity("Dateland.Core.UserInterestRelation", b =>
                {
                    b.Property<int>("UserInterestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("InterestID")
                        .HasColumnType("int");

                    b.HasKey("UserInterestID");

                    b.HasIndex("Id");

                    b.HasIndex("InterestID");

                    b.ToTable("UserInterestRelations");
                });

            modelBuilder.Entity("Dateland.Core.UserProfessionRelation", b =>
                {
                    b.Property<int>("UserProfessionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ProfessionID")
                        .HasColumnType("int");

                    b.HasKey("UserProfessionID");

                    b.HasIndex("Id");

                    b.HasIndex("ProfessionID");

                    b.ToTable("UserProfessionRelations");
                });

            modelBuilder.Entity("Dateland.Core.UserRelationRelation", b =>
                {
                    b.Property<int>("UserRelationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RelationID")
                        .HasColumnType("int");

                    b.Property<string>("_FirstUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("_SecondUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserRelationID");

                    b.HasIndex("RelationID");

                    b.HasIndex("_FirstUserId");

                    b.HasIndex("_SecondUserId");

                    b.ToTable("UserRelationRelations");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Dateland.Core.User", b =>
                {
                    b.HasOne("Dateland.Core.City", "City")
                        .WithMany()
                        .HasForeignKey("CityID");

                    b.HasOne("Dateland.Core.Education", "Education")
                        .WithMany()
                        .HasForeignKey("EducationID");

                    b.HasOne("Dateland.Core.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodID");

                    b.HasOne("Dateland.Core.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderID");

                    b.HasOne("Dateland.Core.GenderPreferation", "GenderPreferation")
                        .WithMany()
                        .HasForeignKey("GenderPreferationID");

                    b.HasOne("Dateland.Core.Interest", "Interest")
                        .WithMany()
                        .HasForeignKey("InterestID");

                    b.HasOne("Dateland.Core.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieID");

                    b.HasOne("Dateland.Core.Music", "Music")
                        .WithMany()
                        .HasForeignKey("MusicID");

                    b.HasOne("Dateland.Core.Profession", "Profession")
                        .WithMany()
                        .HasForeignKey("ProfessionID");

                    b.HasOne("Dateland.Core.Relation", "Relation")
                        .WithMany()
                        .HasForeignKey("RelationID");
                });

            modelBuilder.Entity("Dateland.Core.UserCityRelation", b =>
                {
                    b.HasOne("Dateland.Core.City", "_City")
                        .WithMany()
                        .HasForeignKey("CityID");

                    b.HasOne("Dateland.Core.User", "_User")
                        .WithMany()
                        .HasForeignKey("Id");
                });

            modelBuilder.Entity("Dateland.Core.UserEducationRelation", b =>
                {
                    b.HasOne("Dateland.Core.Education", "_Education")
                        .WithMany()
                        .HasForeignKey("EducationID");

                    b.HasOne("Dateland.Core.User", "_User")
                        .WithMany()
                        .HasForeignKey("Id");
                });

            modelBuilder.Entity("Dateland.Core.UserGenderPreferationRelation", b =>
                {
                    b.HasOne("Dateland.Core.GenderPreferation", "_GenderPreferation")
                        .WithMany()
                        .HasForeignKey("GenderPreferationID");

                    b.HasOne("Dateland.Core.User", "_User")
                        .WithMany()
                        .HasForeignKey("Id");
                });

            modelBuilder.Entity("Dateland.Core.UserInterestRelation", b =>
                {
                    b.HasOne("Dateland.Core.User", "_User")
                        .WithMany()
                        .HasForeignKey("Id");

                    b.HasOne("Dateland.Core.Interest", "_Interest")
                        .WithMany()
                        .HasForeignKey("InterestID");
                });

            modelBuilder.Entity("Dateland.Core.UserProfessionRelation", b =>
                {
                    b.HasOne("Dateland.Core.User", "_User")
                        .WithMany()
                        .HasForeignKey("Id");

                    b.HasOne("Dateland.Core.Profession", "_Profession")
                        .WithMany()
                        .HasForeignKey("ProfessionID");
                });

            modelBuilder.Entity("Dateland.Core.UserRelationRelation", b =>
                {
                    b.HasOne("Dateland.Core.Relation", "_Relation")
                        .WithMany()
                        .HasForeignKey("RelationID");

                    b.HasOne("Dateland.Core.User", "_FirstUser")
                        .WithMany()
                        .HasForeignKey("_FirstUserId");

                    b.HasOne("Dateland.Core.User", "_SecondUser")
                        .WithMany()
                        .HasForeignKey("_SecondUserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Dateland.Core.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Dateland.Core.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dateland.Core.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Dateland.Core.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
