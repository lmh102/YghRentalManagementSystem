using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YghRentalManagementSystem.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Longitude = table.Column<double>(type: "double", nullable: true),
                    Latitude = table.Column<double>(type: "double", nullable: true),
                    Nation = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Detail = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "amenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Amenity = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(3000)", maxLength: 3000, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amenities", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "detaillmedia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDelete = table.Column<sbyte>(type: "tinyint", nullable: false),
                    MediaType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detaillmedia", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "estatetypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EstateType = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyAt = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estatetypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "notifycation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    isRead = table.Column<sbyte>(type: "tinyint", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifycation", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "reasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reasons", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccommodationId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rate = table.Column<decimal>(type: "decimal(2,1)", precision: 2, scale: 1, nullable: false),
                    Comment = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "notifycation_review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NotifycatonId = table.Column<int>(type: "int", nullable: false),
                    ReviewId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifycation_review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifycation_Review_Notifycation",
                        column: x => x.NotifycatonId,
                        principalTable: "notifycation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifycation_Review_Review",
                        column: x => x.ReviewId,
                        principalTable: "reviews",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FullName = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Address = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AvatarId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                    table.ForeignKey(
                        name: "ForeignKey_Users_Role",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "accommondations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OwnerId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EstateTypesId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Description = table.Column<string>(type: "varchar(3000)", maxLength: 3000, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Quanlity = table.Column<decimal>(type: "decimal(2,1)", precision: 2, scale: 1, nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    Policies = table.Column<string>(type: "varchar(3000)", maxLength: 3000, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Expiration = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accommondations", x => x.Id);
                    table.ForeignKey(
                        name: "ForeignKey_Accommodations_EstateTypes",
                        column: x => x.EstateTypesId,
                        principalTable: "estatetypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "ForeignKey_Accommondations_User",
                        column: x => x.OwnerId,
                        principalTable: "users",
                        principalColumn: "UserId");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Emai = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.Id);
                    table.ForeignKey(
                        name: "ForeignKey_accounts_userer",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "ForignKey_accounts_users",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "chat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SendedId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReceivedId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chat_User",
                        column: x => x.SendedId,
                        principalTable: "users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Chat_User_Receiver",
                        column: x => x.ReceivedId,
                        principalTable: "users",
                        principalColumn: "UserId");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "accommodation_media",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    AccomondationId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accommodation_media", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accommodation_Media_Accommodation",
                        column: x => x.AccomondationId,
                        principalTable: "accommondations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Accomodation_Media_Media",
                        column: x => x.MediaId,
                        principalTable: "detaillmedia",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "apartments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    MaxOccupant = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "double", nullable: true),
                    Area = table.Column<float>(type: "float", nullable: true),
                    BedNumber = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "varchar(3000)", maxLength: 3000, nullable: true, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<sbyte>(type: "tinyint", nullable: false),
                    AccommondationId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OwnerId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartment_Accom",
                        column: x => x.AccommondationId,
                        principalTable: "accommondations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apartment_User",
                        column: x => x.OwnerId,
                        principalTable: "users",
                        principalColumn: "UserId");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "follow_user_accom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccomodationId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDelete = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_follow_user_accom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Follow_Accom",
                        column: x => x.AccomodationId,
                        principalTable: "accommondations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Follow_User",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "report",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccomodationId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_report", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Report_Accommondation",
                        column: x => x.AccomodationId,
                        principalTable: "accommondations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Report_user",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "apartment_media",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApartmentId = table.Column<int>(type: "int", nullable: false),
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apartment_media", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartment_Media_Apartment",
                        column: x => x.ApartmentId,
                        principalTable: "apartments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apartment_Media_Media",
                        column: x => x.MediaId,
                        principalTable: "detaillmedia",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "apartments_amenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApartmentId = table.Column<int>(type: "int", nullable: false),
                    AmenityId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apartments_amenities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amenity",
                        column: x => x.AmenityId,
                        principalTable: "amenities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apartment",
                        column: x => x.ApartmentId,
                        principalTable: "apartments",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApartmentId = table.Column<int>(type: "int", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<sbyte>(type: "tinyint", nullable: false),
                    OwnerId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumberRoom = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Apartment",
                        column: x => x.ApartmentId,
                        principalTable: "apartments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservation_User",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Reservation_User_Owner",
                        column: x => x.OwnerId,
                        principalTable: "users",
                        principalColumn: "UserId");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "unavailableapartmentdate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApartmentId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unavailableapartmentdate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aprartment",
                        column: x => x.ApartmentId,
                        principalTable: "apartments",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "notifycation_follow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NotifycationId = table.Column<int>(type: "int", nullable: false),
                    FollowId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifycation_follow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifycation_Follow_Follow",
                        column: x => x.NotifycationId,
                        principalTable: "follow_user_accom",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifycation_Follow_Notifycation",
                        column: x => x.NotifycationId,
                        principalTable: "notifycation",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "reason_report",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReasonId = table.Column<int>(type: "int", nullable: false),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reason_report", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reason_Report_Reason",
                        column: x => x.ReasonId,
                        principalTable: "reasons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reason_Report_Report",
                        column: x => x.ReportId,
                        principalTable: "report",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "notifycation_reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NotifycationId = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<sbyte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifycation_reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_notifycation_reservation_Notifycation",
                        column: x => x.NotifycationId,
                        principalTable: "notifycation_reservation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_notifycation_reservation_Reservation",
                        column: x => x.ReservationId,
                        principalTable: "reservation",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "FK_accommodation_media_Accommdation_idx",
                table: "accommodation_media",
                column: "AccomondationId");

            migrationBuilder.CreateIndex(
                name: "FK_Accomodation_Media_Media_idx",
                table: "accommodation_media",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "Id_UNIQUE",
                table: "accommodation_media",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ForeignKey_Accommodations_EstateTypes_idx",
                table: "accommondations",
                column: "EstateTypesId");

            migrationBuilder.CreateIndex(
                name: "ForeignKey_Accommondations_User_idx",
                table: "accommondations",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "accounts_userer_roleId_idx",
                table: "accounts",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "UserId_UNIQUE",
                table: "accounts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserName_UNIQUE",
                table: "accounts",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Id_UNIQUE1",
                table: "addresses",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Id_UNIQUE2",
                table: "amenities",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_Apartment_Media_Apartment_idx",
                table: "apartment_media",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "FK_Apartment_Media_Media_idx",
                table: "apartment_media",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "Id_UNIQUE4",
                table: "apartment_media",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_Apartment_Accom_idx",
                table: "apartments",
                column: "AccommondationId");

            migrationBuilder.CreateIndex(
                name: "FK_Apartment_User_idx",
                table: "apartments",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "Id_UNIQUE3",
                table: "apartments",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_Amenity_idx",
                table: "apartments_amenities",
                column: "AmenityId");

            migrationBuilder.CreateIndex(
                name: "FK_Apartment_idx",
                table: "apartments_amenities",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "Id_UNIQUE5",
                table: "apartments_amenities",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_Chat_Sender_idx",
                table: "chat",
                columns: new[] { "SendedId", "ReceivedId" });

            migrationBuilder.CreateIndex(
                name: "FK_Chat_User_Receiver_idx",
                table: "chat",
                column: "ReceivedId");

            migrationBuilder.CreateIndex(
                name: "id_UNIQUE",
                table: "chat",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Id_UNIQUE6",
                table: "detaillmedia",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EstateType_UNIQUE",
                table: "estatetypes",
                column: "EstateType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Id_UNIQUE7",
                table: "estatetypes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_Follow_Accom_idx",
                table: "follow_user_accom",
                column: "AccomodationId");

            migrationBuilder.CreateIndex(
                name: "FK_Follow_User_idx",
                table: "follow_user_accom",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "Id_UNIQUE8",
                table: "follow_user_accom",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Id_UNIQUE9",
                table: "notifycation",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_Notifycation_Follow_Notifycation_idx",
                table: "notifycation_follow",
                column: "NotifycationId");

            migrationBuilder.CreateIndex(
                name: "Id_UNIQUE10",
                table: "notifycation_follow",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_notifycation_reservation_Notifycation_idx",
                table: "notifycation_reservation",
                column: "NotifycationId");

            migrationBuilder.CreateIndex(
                name: "FK_notifycation_reservation_Reservation_idx",
                table: "notifycation_reservation",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "Id_UNIQUE11",
                table: "notifycation_reservation",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_Notifycation_Review_Notifycation_idx",
                table: "notifycation_review",
                column: "NotifycatonId");

            migrationBuilder.CreateIndex(
                name: "FK_Notifycation_Review_Review_idx",
                table: "notifycation_review",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "Id_UNIQUE12",
                table: "notifycation_review",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_Reason_Report_Reason_idx",
                table: "reason_report",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "FK_Reason_Report_Report_idx",
                table: "reason_report",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "FK_Report_Accommondation_idx",
                table: "report",
                column: "AccomodationId");

            migrationBuilder.CreateIndex(
                name: "FK_Report_user_idx",
                table: "report",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "Id_UNIQUE13",
                table: "report",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_Reservation_Apartment_idx",
                table: "reservation",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "FK_Reservation_User_Owner_idx",
                table: "reservation",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "FK_User_idx",
                table: "reservation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "idReservation_UNIQUE",
                table: "reservation",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Id_UNIQUE14",
                table: "reviews",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_Âprartment_idx",
                table: "unavailableapartmentdate",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "Id_UNIQUE15",
                table: "unavailableapartmentdate",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ForeignKey_Users_Role_idx",
                table: "users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accommodation_media");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "apartment_media");

            migrationBuilder.DropTable(
                name: "apartments_amenities");

            migrationBuilder.DropTable(
                name: "chat");

            migrationBuilder.DropTable(
                name: "notifycation_follow");

            migrationBuilder.DropTable(
                name: "notifycation_reservation");

            migrationBuilder.DropTable(
                name: "notifycation_review");

            migrationBuilder.DropTable(
                name: "reason_report");

            migrationBuilder.DropTable(
                name: "unavailableapartmentdate");

            migrationBuilder.DropTable(
                name: "detaillmedia");

            migrationBuilder.DropTable(
                name: "amenities");

            migrationBuilder.DropTable(
                name: "follow_user_accom");

            migrationBuilder.DropTable(
                name: "reservation");

            migrationBuilder.DropTable(
                name: "notifycation");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "reasons");

            migrationBuilder.DropTable(
                name: "report");

            migrationBuilder.DropTable(
                name: "apartments");

            migrationBuilder.DropTable(
                name: "accommondations");

            migrationBuilder.DropTable(
                name: "estatetypes");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
