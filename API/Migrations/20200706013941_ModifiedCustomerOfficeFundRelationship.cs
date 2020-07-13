using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ModifiedCustomerOfficeFundRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OfficesAndFunds_OfficeId",
                table: "OfficesAndFunds");

            migrationBuilder.CreateIndex(
                name: "IX_OfficesAndFunds_OfficeId",
                table: "OfficesAndFunds",
                column: "OfficeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OfficesAndFunds_OfficeId",
                table: "OfficesAndFunds");

            migrationBuilder.CreateIndex(
                name: "IX_OfficesAndFunds_OfficeId",
                table: "OfficesAndFunds",
                column: "OfficeId");
        }
    }
}
