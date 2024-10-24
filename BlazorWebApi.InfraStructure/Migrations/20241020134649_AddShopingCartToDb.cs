using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorWebApi.InfraStructure.Migrations
{
    /// <inheritdoc />
    public partial class AddShopingCartToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblShoppingCart",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VillaID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", maxLength: 30, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblShoppingCart", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblShoppingCart");

            migrationBuilder.DropTable(
                name: "tblVillaNumbers");

            migrationBuilder.DropTable(
                name: "tblVillas");
        }
    }
}
