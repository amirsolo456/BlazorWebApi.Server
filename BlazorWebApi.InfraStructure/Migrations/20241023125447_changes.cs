using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorWebApi.InfraStructure.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "tblVillas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblShoppingCart_CustomerID",
                table: "tblShoppingCart",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_tblShoppingCart_VillaID",
                table: "tblShoppingCart",
                column: "VillaID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblShoppingCart_tblCustomers_CustomerID",
                table: "tblShoppingCart",
                column: "CustomerID",
                principalTable: "tblCustomers",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_tblShoppingCart_tblVillas_VillaID",
                table: "tblShoppingCart",
                column: "VillaID",
                principalTable: "tblVillas",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblShoppingCart_tblCustomers_CustomerID",
                table: "tblShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_tblShoppingCart_tblVillas_VillaID",
                table: "tblShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_tblShoppingCart_CustomerID",
                table: "tblShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_tblShoppingCart_VillaID",
                table: "tblShoppingCart");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "tblVillas",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
