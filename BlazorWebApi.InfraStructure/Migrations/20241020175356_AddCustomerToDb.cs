using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorWebApi.InfraStructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCustomers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FLName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PhNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    EmailAddres = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SighnUpDate = table.Column<DateTime>(type: "datetime2", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomers", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCustomers");
        }
    }
}
