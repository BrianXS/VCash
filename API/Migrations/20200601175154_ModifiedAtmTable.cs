using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ModifiedAtmTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ATMs_DrawerRanges_DrawerRangeId",
                table: "ATMs");

            migrationBuilder.AlterColumn<int>(
                name: "DrawerRangeId",
                table: "ATMs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ATMs_DrawerRanges_DrawerRangeId",
                table: "ATMs",
                column: "DrawerRangeId",
                principalTable: "DrawerRanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ATMs_DrawerRanges_DrawerRangeId",
                table: "ATMs");

            migrationBuilder.AlterColumn<int>(
                name: "DrawerRangeId",
                table: "ATMs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ATMs_DrawerRanges_DrawerRangeId",
                table: "ATMs",
                column: "DrawerRangeId",
                principalTable: "DrawerRanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
