using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AddedMovementRelatedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Value = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DenominationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movements",
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
                    Counted = table.Column<bool>(nullable: false),
                    OriginId = table.Column<int>(nullable: false),
                    DestinationId = table.Column<int>(nullable: false),
                    FailureId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    MainVehicleId = table.Column<int>(nullable: false),
                    SecondaryVehicleId = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movements_Offices_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Movements_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Movements_Failures_FailureId",
                        column: x => x.FailureId,
                        principalTable: "Failures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Movements_Vehicles_MainVehicleId",
                        column: x => x.MainVehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Movements_Offices_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Movements_Vehicles_SecondaryVehicleId",
                        column: x => x.SecondaryVehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "NotificationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTypes", x => x.Id);
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
                    MovementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bags_Movements_MovementId",
                        column: x => x.MovementId,
                        principalTable: "Movements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cheque",
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
                    MovementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cheque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cheque_Movements_MovementId",
                        column: x => x.MovementId,
                        principalTable: "Movements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    MovementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envelopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Envelopes_Cashiers_CashierId",
                        column: x => x.CashierId,
                        principalTable: "Cashiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Envelopes_Movements_MovementId",
                        column: x => x.MovementId,
                        principalTable: "Movements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    BagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BagDenominations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BagDenominations_Bags_BagId",
                        column: x => x.BagId,
                        principalTable: "Bags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BagDenominations_DenominationTypes_DenominationTypeId",
                        column: x => x.DenominationTypeId,
                        principalTable: "DenominationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    BagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BagNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BagNotifications_Bags_BagId",
                        column: x => x.BagId,
                        principalTable: "Bags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BagNotifications_DenominationTypes_DenominationTypeId",
                        column: x => x.DenominationTypeId,
                        principalTable: "DenominationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BagNotifications_NotificationTypes_NotificationTypeId",
                        column: x => x.NotificationTypeId,
                        principalTable: "NotificationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    EnvelopeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvelopeDenominations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnvelopeDenominations_DenominationTypes_DenominationTypeId",
                        column: x => x.DenominationTypeId,
                        principalTable: "DenominationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnvelopeDenominations_Envelopes_EnvelopeId",
                        column: x => x.EnvelopeId,
                        principalTable: "Envelopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    EnvelopeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvelopeNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnvelopeNotifications_DenominationTypes_DenominationTypeId",
                        column: x => x.DenominationTypeId,
                        principalTable: "DenominationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnvelopeNotifications_Envelopes_EnvelopeId",
                        column: x => x.EnvelopeId,
                        principalTable: "Envelopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnvelopeNotifications_NotificationTypes_NotificationTypeId",
                        column: x => x.NotificationTypeId,
                        principalTable: "NotificationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Bags_MovementId",
                table: "Bags",
                column: "MovementId");

            migrationBuilder.CreateIndex(
                name: "IX_Cheque_MovementId",
                table: "Cheque",
                column: "MovementId");

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
                name: "IX_Envelopes_MovementId",
                table: "Envelopes",
                column: "MovementId");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_DestinationId",
                table: "Movements",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_EmployeeId",
                table: "Movements",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_FailureId",
                table: "Movements",
                column: "FailureId");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_MainVehicleId",
                table: "Movements",
                column: "MainVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_OriginId",
                table: "Movements",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_SecondaryVehicleId",
                table: "Movements",
                column: "SecondaryVehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BagDenominations");

            migrationBuilder.DropTable(
                name: "BagNotifications");

            migrationBuilder.DropTable(
                name: "Cheque");

            migrationBuilder.DropTable(
                name: "EnvelopeDenominations");

            migrationBuilder.DropTable(
                name: "EnvelopeNotifications");

            migrationBuilder.DropTable(
                name: "Bags");

            migrationBuilder.DropTable(
                name: "DenominationTypes");

            migrationBuilder.DropTable(
                name: "Envelopes");

            migrationBuilder.DropTable(
                name: "NotificationTypes");

            migrationBuilder.DropTable(
                name: "Movements");
        }
    }
}
