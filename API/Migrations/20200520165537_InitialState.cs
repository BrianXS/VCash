using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class InitialState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Names = table.Column<string>(nullable: true),
                    Surnames = table.Column<string>(nullable: true),
                    RefreshToken = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AtmBatteries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtmBatteries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Lat = table.Column<double>(nullable: false),
                    Lng = table.Column<double>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DenominationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Currency = table.Column<int>(nullable: false),
                    BankNote = table.Column<bool>(nullable: false),
                    NewSeries = table.Column<bool>(nullable: false),
                    UnitsPerContainer = table.Column<int>(nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DenominationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Failures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    ClientFault = table.Column<bool>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Failures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Names = table.Column<string>(nullable: true),
                    FirstLastName = table.Column<string>(nullable: true),
                    SecondLastName = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    Sign = table.Column<string>(nullable: true),
                    Title = table.Column<int>(nullable: false),
                    DocumentType = table.Column<int>(nullable: false),
                    DocumentDetails = table.Column<string>(nullable: true),
                    Document = table.Column<string>(nullable: true),
                    EmployeeStatus = table.Column<int>(nullable: false),
                    Rhesus = table.Column<int>(nullable: false),
                    From = table.Column<DateTime>(nullable: false),
                    Until = table.Column<DateTime>(nullable: false),
                    Unit = table.Column<int>(nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(nullable: true),
                    Plate = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    GpsCode = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    BusinessUnit = table.Column<int>(nullable: false),
                    VehicleType = table.Column<int>(nullable: false),
                    AllowedAmmount = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    StateId = table.Column<int>(nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CorporateName = table.Column<string>(nullable: true),
                    DocumentType = table.Column<int>(nullable: false),
                    Document = table.Column<string>(nullable: true),
                    HeadquartersId = table.Column<int>(nullable: false),
                    InvoicingCityId = table.Column<int>(nullable: false),
                    FirstKeyPerson = table.Column<string>(nullable: true),
                    FirstKeyPersonTitle = table.Column<string>(nullable: true),
                    SecondKeyPerson = table.Column<string>(nullable: true),
                    SecondKeyPersonTitle = table.Column<string>(nullable: true),
                    SubClient = table.Column<bool>(nullable: false),
                    ParentClient = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Cities_HeadquartersId",
                        column: x => x.HeadquartersId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Customers_Cities_InvoicingCityId",
                        column: x => x.InvoicingCityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Cashiers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    DocumentType = table.Column<int>(nullable: false),
                    Document = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cashiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cashiers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DrawerRanges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Currency = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawerRanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrawerRanges_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    VatcoCode = table.Column<string>(nullable: true),
                    ClientCode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Prefix = table.Column<string>(nullable: true),
                    Coverage = table.Column<int>(nullable: false),
                    Manager = table.Column<string>(nullable: true),
                    ManagerDetails = table.Column<string>(nullable: true),
                    ManagerEmail = table.Column<string>(nullable: true),
                    OfficeType = table.Column<int>(nullable: false),
                    Lat = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    Lng = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    From = table.Column<DateTime>(nullable: false),
                    Until = table.Column<DateTime>(nullable: false),
                    HasKits = table.Column<bool>(nullable: false),
                    HasKeys = table.Column<bool>(nullable: false),
                    HasEnvelopes = table.Column<bool>(nullable: false),
                    HasCheques = table.Column<bool>(nullable: false),
                    HasDocuments = table.Column<bool>(nullable: false),
                    IsFund = table.Column<bool>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    BusinessTypeId = table.Column<int>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offices_BusinessTypes_BusinessTypeId",
                        column: x => x.BusinessTypeId,
                        principalTable: "BusinessTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offices_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Offices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Drawers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxValue = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DefaultQuantity = table.Column<int>(nullable: false),
                    DrawerType = table.Column<int>(nullable: false),
                    DrawerFunction = table.Column<int>(nullable: false),
                    DrawerRangeId = table.Column<int>(nullable: false),
                    DenominationTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drawers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drawers_DenominationTypes_DenominationTypeId",
                        column: x => x.DenominationTypeId,
                        principalTable: "DenominationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Drawers_DrawerRanges_DrawerRangeId",
                        column: x => x.DrawerRangeId,
                        principalTable: "DrawerRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ATMs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalizationCode = table.Column<bool>(nullable: false),
                    Emergency = table.Column<bool>(nullable: false),
                    MaxValue = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Brand = table.Column<int>(nullable: false),
                    Mode = table.Column<int>(nullable: false),
                    From = table.Column<DateTime>(nullable: false),
                    OfficeId = table.Column<int>(nullable: false),
                    AtmBatteryId = table.Column<int>(nullable: true),
                    DrawerRangeId = table.Column<int>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATMs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ATMs_AtmBatteries_AtmBatteryId",
                        column: x => x.AtmBatteryId,
                        principalTable: "AtmBatteries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ATMs_DrawerRanges_DrawerRangeId",
                        column: x => x.DrawerRangeId,
                        principalTable: "DrawerRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ATMs_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OfficeMovements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayrollNumber = table.Column<string>(nullable: true),
                    ServiceNumber = table.Column<string>(nullable: true),
                    Currency = table.Column<int>(nullable: false),
                    ServiceDate = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false),
                    GeneralNotification = table.Column<string>(nullable: true),
                    ServiceType = table.Column<int>(nullable: false),
                    ServiceStatus = table.Column<int>(nullable: false),
                    MovementType = table.Column<int>(nullable: false),
                    BusinessUnit = table.Column<int>(nullable: false),
                    ValueType = table.Column<int>(nullable: false),
                    AmmountOfContainers = table.Column<int>(nullable: false),
                    AmmountOfBanknoteKits = table.Column<int>(nullable: false),
                    AmmountOfCoinKits = table.Column<int>(nullable: false),
                    DeclaredBankNotes = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CountedBanknotes = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DeclaredCoins = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CountedCoins = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DeclaredCash = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CountedCash = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TotalDifference = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DeclaredCashInWords = table.Column<string>(nullable: true),
                    CountedCashInWords = table.Column<string>(nullable: true),
                    Failed = table.Column<bool>(nullable: false),
                    Custody = table.Column<bool>(nullable: false),
                    OfficeToOffice = table.Column<bool>(nullable: false),
                    OriginId = table.Column<int>(nullable: false),
                    DestinationId = table.Column<int>(nullable: false),
                    FailureId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    MainVehicleId = table.Column<int>(nullable: false),
                    SecondaryVehicleId = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeMovements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficeMovements_Offices_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OfficeMovements_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OfficeMovements_Failures_FailureId",
                        column: x => x.FailureId,
                        principalTable: "Failures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OfficeMovements_Vehicles_MainVehicleId",
                        column: x => x.MainVehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OfficeMovements_Offices_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OfficeMovements_Vehicles_SecondaryVehicleId",
                        column: x => x.SecondaryVehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OfficesAndFunds",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false),
                    OfficeId = table.Column<int>(nullable: false),
                    ClosedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficesAndFunds", x => new { x.CustomerId, x.OfficeId });
                    table.ForeignKey(
                        name: "FK_OfficesAndFunds_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OfficesAndFunds_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Bags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BagSerial = table.Column<string>(nullable: true),
                    SealSerial = table.Column<string>(nullable: true),
                    ArrivalDate = table.Column<DateTime>(nullable: false),
                    DeclaredCash = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CountedCash = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    MovementId = table.Column<int>(nullable: false),
                    OfficeMovementId = table.Column<int>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bags_OfficeMovements_OfficeMovementId",
                        column: x => x.OfficeMovementId,
                        principalTable: "OfficeMovements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cheques",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChequeSerial = table.Column<string>(nullable: true),
                    BagSerial = table.Column<string>(nullable: true),
                    SealSerial = table.Column<string>(nullable: true),
                    DeclaredDocumentValue = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Bank = table.Column<int>(nullable: false),
                    ArrivalDate = table.Column<DateTime>(nullable: false),
                    MovementId = table.Column<int>(nullable: false),
                    OfficeMovementId = table.Column<int>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cheques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cheques_OfficeMovements_OfficeMovementId",
                        column: x => x.OfficeMovementId,
                        principalTable: "OfficeMovements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Envelopes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnvelopeSerial = table.Column<string>(nullable: true),
                    BagSerial = table.Column<string>(nullable: true),
                    SealSerial = table.Column<string>(nullable: true),
                    ClientSerial = table.Column<string>(nullable: true),
                    ArrivalDate = table.Column<DateTime>(nullable: false),
                    DeclaredCash = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CountedCash = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DeclaredDocumentValue = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CountedDocumentValue = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CashierId = table.Column<int>(nullable: false),
                    MovementId = table.Column<int>(nullable: false),
                    OfficeMovementId = table.Column<int>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envelopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Envelopes_Cashiers_CashierId",
                        column: x => x.CashierId,
                        principalTable: "Cashiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Envelopes_OfficeMovements_OfficeMovementId",
                        column: x => x.OfficeMovementId,
                        principalTable: "OfficeMovements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BagDenominations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    DenominationTypeId = table.Column<int>(nullable: false),
                    Bundle = table.Column<int>(nullable: false),
                    Singles = table.Column<int>(nullable: false),
                    TotalCountedCash = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    BagId = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BagDenominations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BagDenominations_Bags_BagId",
                        column: x => x.BagId,
                        principalTable: "Bags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BagDenominations_DenominationTypes_DenominationTypeId",
                        column: x => x.DenominationTypeId,
                        principalTable: "DenominationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "BagNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Total = table.Column<int>(nullable: false),
                    DenominationTypeId = table.Column<int>(nullable: false),
                    NotificationTypeId = table.Column<int>(nullable: false),
                    BagId = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BagNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BagNotifications_Bags_BagId",
                        column: x => x.BagId,
                        principalTable: "Bags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BagNotifications_DenominationTypes_DenominationTypeId",
                        column: x => x.DenominationTypeId,
                        principalTable: "DenominationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BagNotifications_NotificationTypes_NotificationTypeId",
                        column: x => x.NotificationTypeId,
                        principalTable: "NotificationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EnvelopeDenominations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    DenominationTypeId = table.Column<int>(nullable: false),
                    Bundle = table.Column<int>(nullable: false),
                    Singles = table.Column<int>(nullable: false),
                    TotalCountedCash = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    EnvelopeId = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvelopeDenominations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnvelopeDenominations_DenominationTypes_DenominationTypeId",
                        column: x => x.DenominationTypeId,
                        principalTable: "DenominationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EnvelopeDenominations_Envelopes_EnvelopeId",
                        column: x => x.EnvelopeId,
                        principalTable: "Envelopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EnvelopeNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Total = table.Column<int>(nullable: false),
                    DenominationTypeId = table.Column<int>(nullable: false),
                    NotificationTypeId = table.Column<int>(nullable: false),
                    EnvelopeId = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvelopeNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnvelopeNotifications_DenominationTypes_DenominationTypeId",
                        column: x => x.DenominationTypeId,
                        principalTable: "DenominationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EnvelopeNotifications_Envelopes_EnvelopeId",
                        column: x => x.EnvelopeId,
                        principalTable: "Envelopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EnvelopeNotifications_NotificationTypes_NotificationTypeId",
                        column: x => x.NotificationTypeId,
                        principalTable: "NotificationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

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
                name: "IX_ATMs_AtmBatteryId",
                table: "ATMs",
                column: "AtmBatteryId");

            migrationBuilder.CreateIndex(
                name: "IX_ATMs_DrawerRangeId",
                table: "ATMs",
                column: "DrawerRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_ATMs_OfficeId",
                table: "ATMs",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_BagDenominations_BagId",
                table: "BagDenominations",
                column: "BagId");

            migrationBuilder.CreateIndex(
                name: "IX_BagDenominations_DenominationTypeId",
                table: "BagDenominations",
                column: "DenominationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BagNotifications_BagId",
                table: "BagNotifications",
                column: "BagId");

            migrationBuilder.CreateIndex(
                name: "IX_BagNotifications_DenominationTypeId",
                table: "BagNotifications",
                column: "DenominationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BagNotifications_NotificationTypeId",
                table: "BagNotifications",
                column: "NotificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bags_OfficeMovementId",
                table: "Bags",
                column: "OfficeMovementId");

            migrationBuilder.CreateIndex(
                name: "IX_Cashiers_CustomerId",
                table: "Cashiers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cheques_OfficeMovementId",
                table: "Cheques",
                column: "OfficeMovementId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_BranchId",
                table: "Cities",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_HeadquartersId",
                table: "Customers",
                column: "HeadquartersId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_InvoicingCityId",
                table: "Customers",
                column: "InvoicingCityId");

            migrationBuilder.CreateIndex(
                name: "IX_DrawerRanges_CustomerId",
                table: "DrawerRanges",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Drawers_DenominationTypeId",
                table: "Drawers",
                column: "DenominationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Drawers_DrawerRangeId",
                table: "Drawers",
                column: "DrawerRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BranchId",
                table: "Employees",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_EnvelopeDenominations_DenominationTypeId",
                table: "EnvelopeDenominations",
                column: "DenominationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EnvelopeDenominations_EnvelopeId",
                table: "EnvelopeDenominations",
                column: "EnvelopeId");

            migrationBuilder.CreateIndex(
                name: "IX_EnvelopeNotifications_DenominationTypeId",
                table: "EnvelopeNotifications",
                column: "DenominationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EnvelopeNotifications_EnvelopeId",
                table: "EnvelopeNotifications",
                column: "EnvelopeId");

            migrationBuilder.CreateIndex(
                name: "IX_EnvelopeNotifications_NotificationTypeId",
                table: "EnvelopeNotifications",
                column: "NotificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Envelopes_CashierId",
                table: "Envelopes",
                column: "CashierId");

            migrationBuilder.CreateIndex(
                name: "IX_Envelopes_OfficeMovementId",
                table: "Envelopes",
                column: "OfficeMovementId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeMovements_DestinationId",
                table: "OfficeMovements",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeMovements_EmployeeId",
                table: "OfficeMovements",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeMovements_FailureId",
                table: "OfficeMovements",
                column: "FailureId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeMovements_MainVehicleId",
                table: "OfficeMovements",
                column: "MainVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeMovements_OriginId",
                table: "OfficeMovements",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeMovements_SecondaryVehicleId",
                table: "OfficeMovements",
                column: "SecondaryVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_BusinessTypeId",
                table: "Offices",
                column: "BusinessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_CityId",
                table: "Offices",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_CustomerId",
                table: "Offices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficesAndFunds_OfficeId",
                table: "OfficesAndFunds",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_BranchId",
                table: "Vehicles",
                column: "BranchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "ATMs");

            migrationBuilder.DropTable(
                name: "BagDenominations");

            migrationBuilder.DropTable(
                name: "BagNotifications");

            migrationBuilder.DropTable(
                name: "Cheques");

            migrationBuilder.DropTable(
                name: "Drawers");

            migrationBuilder.DropTable(
                name: "EnvelopeDenominations");

            migrationBuilder.DropTable(
                name: "EnvelopeNotifications");

            migrationBuilder.DropTable(
                name: "OfficesAndFunds");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AtmBatteries");

            migrationBuilder.DropTable(
                name: "Bags");

            migrationBuilder.DropTable(
                name: "DrawerRanges");

            migrationBuilder.DropTable(
                name: "DenominationTypes");

            migrationBuilder.DropTable(
                name: "Envelopes");

            migrationBuilder.DropTable(
                name: "NotificationTypes");

            migrationBuilder.DropTable(
                name: "Cashiers");

            migrationBuilder.DropTable(
                name: "OfficeMovements");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Failures");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "BusinessTypes");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
