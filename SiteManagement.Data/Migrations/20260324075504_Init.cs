using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteManagement.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sites_AspNetUsers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Announcements_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Announcements_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Blocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FloorCount = table.Column<int>(type: "int", nullable: false),
                    SiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blocks_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    SquareMeters = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    IsRented = table.Column<bool>(type: "bit", nullable: false),
                    RoomCount = table.Column<int>(type: "int", nullable: false),
                    BlockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartments_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Apartments_AspNetUsers_TenantId",
                        column: x => x.TenantId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Apartments_Blocks_BlockId",
                        column: x => x.BlockId,
                        principalTable: "Blocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Apartments_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Complaints_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Complaints_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dues_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExitTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisteredById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visitors_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visitors_AspNetUsers_RegisteredById",
                        column: x => x.RegisteredById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_AspNetUsers_PayerId",
                        column: x => x.PayerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Dues_DueId",
                        column: x => x.DueId,
                        principalTable: "Dues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("066247ba-ca2c-4554-9311-bd96d8658923"), "11988a2a-1908-4a35-8ea0-7f973e3ccfd5", "Employee", "EMPLOYEE" },
                    { new Guid("44a9b0b3-9df5-4b85-83ac-608abfe46207"), "1466cd6f-bbf0-4398-b35c-e5b1cc9dd215", "Owner", "OWNER" },
                    { new Guid("45f843cb-d1e5-4a6b-afa3-3ab105d3b159"), "cb82aa17-0fd4-469e-94ce-c2a51036dc96", "Tenant", "TENANT" },
                    { new Guid("813c1780-e84a-4992-9676-2da6e6bb38df"), "bf235a98-2cca-4f55-a07e-20a6a5f8dd2f", "Admin", "ADMIN" },
                    { new Guid("8407beb3-e2b8-483d-b7c5-f159327aa74b"), "fcff8cd1-7d46-4c75-8f56-48115fb2c0a9", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("44010978-e210-4db8-81e9-6f191695953b"), 0, "1115759e-e25e-4d1c-aa5a-cf1278c224b4", "mehmet@siteyonetim.com", true, "Mehmet", "Kaya", false, null, "MEHMET@SITEYONETIM.COM", "MEHMET.KAYA", "AQAAAAEAACcQAAAAEOYVTU9ancQKAX0aZxXqzwi5OGIZ3XEwiaYjXDW/ZcvhRvEMOJsFlKLJzR6wDvrrPA==", null, false, "a479fdbe-4388-4ad8-90b5-5b5b9f23dccb", false, "mehmet.kaya" },
                    { new Guid("589da78a-0fd1-4fdf-bdde-4bf626b0b2df"), 0, "bfb5d3b9-b6a3-4a44-8164-0df6049b89bb", "fatma@siteyonetim.com", true, "Fatma", "Şahin", false, null, "FATMA@SITEYONETIM.COM", "FATMA.SAHIN", "AQAAAAEAACcQAAAAECrlvYoWSjtzyx4XdjPUzed25zy7YDK1TxUP7Q5MxIyzCp/ADo0A1GNNA0Gfcp7BPQ==", null, false, "d76d6bcd-954d-4d11-80eb-3d9ee9d65d06", false, "fatma.sahin" },
                    { new Guid("c6b6ce5a-93ac-44d1-936b-ed80b6f9b04f"), 0, "c9c12ade-6ae0-4c6e-805f-ca6219cb14aa", "admin@siteyonetim.com", true, "System", "Admin", false, null, "ADMIN@SITEYONETIM.COM", "ADMIN", "AQAAAAEAACcQAAAAEOMOC85vP3wwCToVpHLBNbgxClAuIOlM2vbG9qe5MVpL4t4W1qIwPwIpoGVdmYvm+w==", null, false, "e2d8195a-a4d0-4b53-8eaf-78e39b56bdbe", false, "admin" },
                    { new Guid("c725e0e7-d8c1-4ac7-b9ac-d580cd22aa1d"), 0, "700c399b-c34f-43f1-a6a1-0248dbe6c11d", "ayse@siteyonetim.com", true, "Ayşe", "Demir", false, null, "AYSE@SITEYONETIM.COM", "AYSE.DEMIR", "AQAAAAEAACcQAAAAEMUsqZeNdr7v8z9F+SuSi3z6ksXb0yHziktneiW0Mw5hE7yyKN+rx8PCu28MqPxd9Q==", null, false, "463c7b08-4288-4629-809a-2a109cb39726", false, "ayse.demir" },
                    { new Guid("cc25344a-3173-4459-9ad4-d2c7d7a5ac13"), 0, "b5e6d88e-7ef1-42ff-9810-20fde393bfce", "ahmet@siteyonetim.com", true, "Ahmet", "Yılmaz", false, null, "AHMET@SITEYONETIM.COM", "AHMET.YILMAZ", "AQAAAAEAACcQAAAAEBrq/Y3IkPGLOxO8962rIzuBhCSRS2D8jaNacKqSxmJaV3EmClRbTl4yHl0mOMNKnw==", null, false, "7bbeca26-be39-45e2-baa0-765986486231", false, "ahmet.yilmaz" },
                    { new Guid("e60285cb-58df-4960-ba9f-d5bbd5116195"), 0, "09afc03b-6c71-4eeb-9608-f3d2af6d0bd2", "ali@siteyonetim.com", true, "Ali", "Çelik", false, null, "ALI@SITEYONETIM.COM", "ALI.CELIK", "AQAAAAEAACcQAAAAEJvQpiuE6Jwp9OvVRo3zoYevVsqlHPrnF50eK7kPWKbiVjy0XrGd72WELBs9Yiit+A==", null, false, "0eff50de-5620-43af-8fd3-36d7f9271f74", false, "ali.celik" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("44a9b0b3-9df5-4b85-83ac-608abfe46207"), new Guid("44010978-e210-4db8-81e9-6f191695953b") },
                    { new Guid("45f843cb-d1e5-4a6b-afa3-3ab105d3b159"), new Guid("589da78a-0fd1-4fdf-bdde-4bf626b0b2df") },
                    { new Guid("813c1780-e84a-4992-9676-2da6e6bb38df"), new Guid("c6b6ce5a-93ac-44d1-936b-ed80b6f9b04f") },
                    { new Guid("44a9b0b3-9df5-4b85-83ac-608abfe46207"), new Guid("c725e0e7-d8c1-4ac7-b9ac-d580cd22aa1d") },
                    { new Guid("8407beb3-e2b8-483d-b7c5-f159327aa74b"), new Guid("cc25344a-3173-4459-9ad4-d2c7d7a5ac13") },
                    { new Guid("45f843cb-d1e5-4a6b-afa3-3ab105d3b159"), new Guid("e60285cb-58df-4960-ba9f-d5bbd5116195") }
                });

            migrationBuilder.InsertData(
                table: "Sites",
                columns: new[] { "Id", "Address", "City", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ManagerId", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("ef55ed67-b6ae-4746-8b94-6e48a0f61a49"), "Cumhuriyet Bulvarı No:45", "Ankara", "seed", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("cc25344a-3173-4459-9ad4-d2c7d7a5ac13"), null, null, "Mavi Köşk Sitesi" },
                    { new Guid("f0bc1c34-dbd4-4bd7-9668-d8c6c66ed480"), "Atatürk Cad. No:12", "İstanbul", "seed", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, new Guid("cc25344a-3173-4459-9ad4-d2c7d7a5ac13"), null, null, "Yeşilvadi Sitesi" }
                });

            migrationBuilder.InsertData(
                table: "Announcements",
                columns: new[] { "Id", "AppUserId", "Content", "CreatedBy", "CreatedById", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "SiteId", "Title" },
                values: new object[,]
                {
                    { new Guid("126c039b-8731-439f-96c5-0f06b7eda003"), null, "Ocak 2024 dönemi aidat ödemeleri 31 Ocak'a kadar yapılmalıdır.", "seed", new Guid("cc25344a-3173-4459-9ad4-d2c7d7a5ac13"), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("f0bc1c34-dbd4-4bd7-9668-d8c6c66ed480"), "Ocak Ayı Aidat Bildirimi" },
                    { new Guid("275eadcc-2f61-41b7-82a6-80c7bb24a85d"), null, "15 Ocak 2024 tarihinde 09:00-17:00 saatleri arasında bakım nedeniyle su kesintisi yaşanacaktır.", "seed", new Guid("cc25344a-3173-4459-9ad4-d2c7d7a5ac13"), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("f0bc1c34-dbd4-4bd7-9668-d8c6c66ed480"), "Su Kesintisi Duyurusu" },
                    { new Guid("d4be6e28-d3cd-4f06-afc0-1e3afed68cff"), null, "20 Ocak 2024 Cumartesi saat 14:00'te site toplantı salonunda genel kurul yapılacaktır.", "seed", new Guid("cc25344a-3173-4459-9ad4-d2c7d7a5ac13"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, new Guid("ef55ed67-b6ae-4746-8b94-6e48a0f61a49"), "Genel Kurul Toplantısı" }
                });

            migrationBuilder.InsertData(
                table: "Blocks",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FloorCount", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "SiteId" },
                values: new object[,]
                {
                    { new Guid("41712748-f3e8-4540-9f19-200e5a1f095d"), "seed", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 6, false, null, null, "B Blok", new Guid("f0bc1c34-dbd4-4bd7-9668-d8c6c66ed480") },
                    { new Guid("448d9760-5b48-450d-8297-c25c88e7be2f"), "seed", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 8, false, null, null, "A Blok", new Guid("f0bc1c34-dbd4-4bd7-9668-d8c6c66ed480") },
                    { new Guid("accf19a5-b677-4e03-996e-ef32eb2c93d5"), "seed", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 10, false, null, null, "A Blok", new Guid("ef55ed67-b6ae-4746-8b94-6e48a0f61a49") }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "EndDate", "FirstName", "IsActive", "IsDeleted", "LastName", "ModifiedBy", "ModifiedDate", "Phone", "Position", "SiteId", "StartDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("1a153ea7-321a-4f30-ab2d-1bafd40d0b76"), "seed", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Hasan", true, false, "Güvenlik", null, null, "05551112233", "Security", new Guid("f0bc1c34-dbd4-4bd7-9668-d8c6c66ed480"), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("65470101-88dc-4ff4-ac60-6e9a02035f51"), "seed", new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Nurcan", true, false, "Temizlik", null, null, "05554445566", "Cleaning Staff", new Guid("f0bc1c34-dbd4-4bd7-9668-d8c6c66ed480"), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Id", "ApartmentNumber", "BlockId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Floor", "IsDeleted", "IsRented", "ModifiedBy", "ModifiedDate", "OwnerId", "RoomCount", "SiteId", "SquareMeters", "TenantId" },
                values: new object[,]
                {
                    { new Guid("825472e5-0820-46cd-9039-b1565befd726"), "3", new Guid("41712748-f3e8-4540-9f19-200e5a1f095d"), "seed", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, false, false, null, null, new Guid("c725e0e7-d8c1-4ac7-b9ac-d580cd22aa1d"), 4, new Guid("f0bc1c34-dbd4-4bd7-9668-d8c6c66ed480"), 150m, null },
                    { new Guid("8c38f383-b67d-4f6c-8a75-ff57c58621b5"), "1", new Guid("448d9760-5b48-450d-8297-c25c88e7be2f"), "seed", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, false, false, null, null, new Guid("44010978-e210-4db8-81e9-6f191695953b"), 3, new Guid("f0bc1c34-dbd4-4bd7-9668-d8c6c66ed480"), 120m, null },
                    { new Guid("b2823418-628c-4bce-848a-4032abb0feaf"), "2", new Guid("448d9760-5b48-450d-8297-c25c88e7be2f"), "seed", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, false, true, null, null, new Guid("44010978-e210-4db8-81e9-6f191695953b"), 2, new Guid("f0bc1c34-dbd4-4bd7-9668-d8c6c66ed480"), 90m, new Guid("e60285cb-58df-4960-ba9f-d5bbd5116195") },
                    { new Guid("e5739a46-573e-4252-b610-060e0a4ef016"), "1", new Guid("accf19a5-b677-4e03-996e-ef32eb2c93d5"), "seed", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, false, true, null, null, new Guid("c725e0e7-d8c1-4ac7-b9ac-d580cd22aa1d"), 3, new Guid("ef55ed67-b6ae-4746-8b94-6e48a0f61a49"), 110m, new Guid("589da78a-0fd1-4fdf-bdde-4bf626b0b2df") }
                });

            migrationBuilder.InsertData(
                table: "Complaints",
                columns: new[] { "Id", "ApartmentId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Description", "IsDeleted", "ModifiedBy", "ModifiedDate", "Status", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("617015b4-00b8-4bac-84ea-f1d64dcbfd15"), new Guid("8c38f383-b67d-4f6c-8a75-ff57c58621b5"), "seed", new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "A Blok asansörü 3 gündür çalışmıyor, lütfen en kısa sürede tamir edilsin.", false, null, null, 1, "Asansör Arızası", new Guid("44010978-e210-4db8-81e9-6f191695953b") },
                    { new Guid("a37349ef-cfce-4dd1-974b-39a6c673aab3"), new Guid("b2823418-628c-4bce-848a-4032abb0feaf"), "seed", new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Kapalı otoparkın giriş katındaki aydınlatmalar çalışmıyor.", false, null, null, 0, "Otopark Işıkları", new Guid("e60285cb-58df-4960-ba9f-d5bbd5116195") },
                    { new Guid("e4cf0eb7-9930-4a38-bcda-82936cb82cfa"), new Guid("825472e5-0820-46cd-9039-b1565befd726"), "seed", new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Üst daireden gece geç saatlerde gürültü gelmektedir.", false, null, null, 2, "Gürültü Şikayeti", new Guid("c725e0e7-d8c1-4ac7-b9ac-d580cd22aa1d") }
                });

            migrationBuilder.InsertData(
                table: "Dues",
                columns: new[] { "Id", "Amount", "ApartmentId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "DueDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Month", "Year" },
                values: new object[,]
                {
                    { new Guid("9873d671-211a-4c52-a98c-39e7f8afba30"), 750m, new Guid("b2823418-628c-4bce-848a-4032abb0feaf"), "seed", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, 1, 2024 },
                    { new Guid("b34e20b9-7f7c-49e4-964a-324fabb52f05"), 750m, new Guid("8c38f383-b67d-4f6c-8a75-ff57c58621b5"), "seed", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, 1, 2024 },
                    { new Guid("baa7a46e-8745-4525-abfa-512ceb5e20e6"), 850m, new Guid("825472e5-0820-46cd-9039-b1565befd726"), "seed", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, 1, 2024 }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "DueId", "IsDeleted", "ModifiedBy", "ModifiedDate", "PaidAmount", "PayerId", "PaymentDate", "PaymentMethod", "PaymentStatus" },
                values: new object[] { new Guid("3a231a48-7119-475a-8dcf-c62ec7cac700"), "seed", new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("9873d671-211a-4c52-a98c-39e7f8afba30"), false, null, null, 750m, new Guid("e60285cb-58df-4960-ba9f-d5bbd5116195"), new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash", 2 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "DueId", "IsDeleted", "ModifiedBy", "ModifiedDate", "PaidAmount", "PayerId", "PaymentDate", "PaymentMethod", "PaymentStatus" },
                values: new object[] { new Guid("8fa465d5-c762-43ee-b893-67e9e88f963e"), "seed", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b34e20b9-7f7c-49e4-964a-324fabb52f05"), false, null, null, 750m, new Guid("44010978-e210-4db8-81e9-6f191695953b"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bank Transfer", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_AppUserId",
                table: "Announcements",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_SiteId",
                table: "Announcements",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_BlockId",
                table: "Apartments",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_OwnerId",
                table: "Apartments",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_SiteId",
                table: "Apartments",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_TenantId",
                table: "Apartments",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_SiteId",
                table: "Blocks",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_ApartmentId",
                table: "Complaints",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_UserId",
                table: "Complaints",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Dues_ApartmentId",
                table: "Dues",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SiteId",
                table: "Employees",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_DueId",
                table: "Payments",
                column: "DueId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PayerId",
                table: "Payments",
                column: "PayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_ManagerId",
                table: "Sites",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ApartmentId",
                table: "Vehicles",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UserId",
                table: "Vehicles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_ApartmentId",
                table: "Visitors",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_RegisteredById",
                table: "Visitors",
                column: "RegisteredById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Complaints");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Dues");

            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "Blocks");

            migrationBuilder.DropTable(
                name: "Sites");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
