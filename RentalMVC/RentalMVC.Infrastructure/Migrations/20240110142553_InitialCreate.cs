using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentalMVC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressPartOne = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressPartTwo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainContactDataId = table.Column<int>(type: "int", nullable: false),
                    UserDetailId = table.Column<int>(type: "int", nullable: false),
                    RentalId = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamePart1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamePart2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    LessorId = table.Column<int>(type: "int", nullable: true),
                    RentalId = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactDatas_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactDatas_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    SerialNr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IndividualPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DeviceTypeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    LessorId = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    RentalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BorrowedDevices = table.Column<int>(type: "int", nullable: false),
                    TotalDevices = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HasDevices = table.Column<bool>(type: "bit", nullable: false),
                    NodeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    LessorId = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    RentalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDetailId = table.Column<int>(type: "int", nullable: false),
                    MainContactDataId = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    RentalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_ContactDatas_MainContactDataId",
                        column: x => x.MainContactDataId,
                        principalTable: "ContactDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lessors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CanLaunchRental = table.Column<bool>(type: "bit", nullable: false),
                    RentalId = table.Column<int>(type: "int", nullable: true),
                    MainContactDataId = table.Column<int>(type: "int", nullable: true),
                    UserDetailId = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessors_ContactDatas_MainContactDataId",
                        column: x => x.MainContactDataId,
                        principalTable: "ContactDatas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessorId = table.Column<int>(type: "int", nullable: false),
                    MainContactDataId = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rentals_ContactDatas_MainContactDataId",
                        column: x => x.MainContactDataId,
                        principalTable: "ContactDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Lessors_LessorId",
                        column: x => x.LessorId,
                        principalTable: "Lessors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    LessorId = table.Column<int>(type: "int", nullable: true),
                    LessorId1 = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId1 = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDetails_Employees_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserDetails_Lessors_LessorId1",
                        column: x => x.LessorId1,
                        principalTable: "Lessors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Nodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasSubNodes = table.Column<bool>(type: "bit", nullable: false),
                    DeviceTypeId = table.Column<int>(type: "int", nullable: true),
                    ParentNodeId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    LessorId = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    RentalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nodes_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nodes_Lessors_LessorId",
                        column: x => x.LessorId,
                        principalTable: "Lessors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nodes_Nodes_ParentNodeId",
                        column: x => x.ParentNodeId,
                        principalTable: "Nodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nodes_Rentals_RentalId",
                        column: x => x.RentalId,
                        principalTable: "Rentals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DuringExecution = table.Column<bool>(type: "bit", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    RentalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Rentals_RentalId",
                        column: x => x.RentalId,
                        principalTable: "Rentals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReservationPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SequenceNumber = table.Column<int>(type: "int", nullable: false),
                    EquipmentQuantity = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    DeviceTypeId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    RentalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationPositions_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReservationPositions_DeviceTypes_DeviceTypeId",
                        column: x => x.DeviceTypeId,
                        principalTable: "DeviceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReservationPositions_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReservationPositions_Rentals_RentalId",
                        column: x => x.RentalId,
                        principalTable: "Rentals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReservationPositions_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "Admin", null, "Admin", "ADMIN" },
                    { "Client", null, "Client", "CLIENT" },
                    { "Employee", null, "Employee", "EMPLOYEE" },
                    { "Lessor", null, "Lessor", "LESSOR" },
                    { "SuperEmployee", null, "SuperEmployee", "SUPEREMPLOYEE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CreatorId",
                table: "Addresses",
                column: "CreatorId");

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
                name: "IX_Clients_CreatorId",
                table: "Clients",
                column: "CreatorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_MainContactDataId",
                table: "Clients",
                column: "MainContactDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_RentalId",
                table: "Clients",
                column: "RentalId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserDetailId",
                table: "Clients",
                column: "UserDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactDatas_AddressId",
                table: "ContactDatas",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDatas_ClientId",
                table: "ContactDatas",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDatas_CreatorId",
                table: "ContactDatas",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDatas_LessorId",
                table: "ContactDatas",
                column: "LessorId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDatas_RentalId",
                table: "ContactDatas",
                column: "RentalId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_CreatorId",
                table: "Devices",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_DeviceTypeId",
                table: "Devices",
                column: "DeviceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_EmployeeId",
                table: "Devices",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_LessorId",
                table: "Devices",
                column: "LessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_RentalId",
                table: "Devices",
                column: "RentalId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceTypes_CreatorId",
                table: "DeviceTypes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceTypes_EmployeeId",
                table: "DeviceTypes",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceTypes_LessorId",
                table: "DeviceTypes",
                column: "LessorId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceTypes_NodeId",
                table: "DeviceTypes",
                column: "NodeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceTypes_RentalId",
                table: "DeviceTypes",
                column: "RentalId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CreatorId",
                table: "Employees",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_MainContactDataId",
                table: "Employees",
                column: "MainContactDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RentalId",
                table: "Employees",
                column: "RentalId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserDetailId",
                table: "Employees",
                column: "UserDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessors_CreatorId",
                table: "Lessors",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessors_MainContactDataId",
                table: "Lessors",
                column: "MainContactDataId",
                unique: true,
                filter: "[MainContactDataId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Lessors_RentalId",
                table: "Lessors",
                column: "RentalId",
                unique: true,
                filter: "[RentalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Lessors_UserDetailId",
                table: "Lessors",
                column: "UserDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessors_UserId",
                table: "Lessors",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_CreatorId",
                table: "Nodes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_DeviceTypeId",
                table: "Nodes",
                column: "DeviceTypeId",
                unique: true,
                filter: "[DeviceTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_EmployeeId",
                table: "Nodes",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_LessorId",
                table: "Nodes",
                column: "LessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_ParentNodeId",
                table: "Nodes",
                column: "ParentNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_RentalId",
                table: "Nodes",
                column: "RentalId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CreatedAt",
                table: "Rentals",
                column: "CreatedAt",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_LessorId",
                table: "Rentals",
                column: "LessorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_MainContactDataId",
                table: "Rentals",
                column: "MainContactDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReservationPositions_ClientId",
                table: "ReservationPositions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationPositions_CreatorId",
                table: "ReservationPositions",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationPositions_DeviceId",
                table: "ReservationPositions",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationPositions_DeviceTypeId",
                table: "ReservationPositions",
                column: "DeviceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationPositions_RentalId",
                table: "ReservationPositions",
                column: "RentalId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationPositions_ReservationId",
                table: "ReservationPositions",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientId",
                table: "Reservations",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CreatorId",
                table: "Reservations",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RentalId",
                table: "Reservations",
                column: "RentalId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_ClientId",
                table: "UserDetails",
                column: "ClientId",
                unique: true,
                filter: "[ClientId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_CreatorId",
                table: "UserDetails",
                column: "CreatorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_EmployeeId",
                table: "UserDetails",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_EmployeeId1",
                table: "UserDetails",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_LessorId",
                table: "UserDetails",
                column: "LessorId",
                unique: true,
                filter: "[LessorId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_LessorId1",
                table: "UserDetails",
                column: "LessorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_ContactDatas_MainContactDataId",
                table: "Clients",
                column: "MainContactDataId",
                principalTable: "ContactDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Rentals_RentalId",
                table: "Clients",
                column: "RentalId",
                principalTable: "Rentals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_UserDetails_UserDetailId",
                table: "Clients",
                column: "UserDetailId",
                principalTable: "UserDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDatas_Lessors_LessorId",
                table: "ContactDatas",
                column: "LessorId",
                principalTable: "Lessors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDatas_Rentals_RentalId",
                table: "ContactDatas",
                column: "RentalId",
                principalTable: "Rentals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_DeviceTypes_DeviceTypeId",
                table: "Devices",
                column: "DeviceTypeId",
                principalTable: "DeviceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Employees_EmployeeId",
                table: "Devices",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Lessors_LessorId",
                table: "Devices",
                column: "LessorId",
                principalTable: "Lessors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Rentals_RentalId",
                table: "Devices",
                column: "RentalId",
                principalTable: "Rentals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceTypes_Employees_EmployeeId",
                table: "DeviceTypes",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceTypes_Lessors_LessorId",
                table: "DeviceTypes",
                column: "LessorId",
                principalTable: "Lessors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceTypes_Nodes_NodeId",
                table: "DeviceTypes",
                column: "NodeId",
                principalTable: "Nodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceTypes_Rentals_RentalId",
                table: "DeviceTypes",
                column: "RentalId",
                principalTable: "Rentals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Rentals_RentalId",
                table: "Employees",
                column: "RentalId",
                principalTable: "Rentals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_UserDetails_UserDetailId",
                table: "Employees",
                column: "UserDetailId",
                principalTable: "UserDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessors_UserDetails_UserDetailId",
                table: "Lessors",
                column: "UserDetailId",
                principalTable: "UserDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_ContactDatas_MainContactDataId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ContactDatas_MainContactDataId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessors_ContactDatas_MainContactDataId",
                table: "Lessors");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_ContactDatas_MainContactDataId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Rentals_RentalId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_UserDetails_UserDetailId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessors_UserDetails_UserDetailId",
                table: "Lessors");

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
                name: "ReservationPositions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "DeviceTypes");

            migrationBuilder.DropTable(
                name: "Nodes");

            migrationBuilder.DropTable(
                name: "ContactDatas");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Lessors");
        }
    }
}
