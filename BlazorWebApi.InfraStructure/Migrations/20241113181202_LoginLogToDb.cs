using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorWebApi.InfraStructure.Migrations
{
    /// <inheritdoc />
    public partial class LoginLogToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblAdminLog");

            //migrationBuilder.AddColumn<string>(
            //    name: "Password",
            //    table: "tblAdmin",
            //    type: "nvarchar(50)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "UserName",
            //    table: "tblAdmin",
            //    type: "nvarchar(50)",
            //    nullable: false,
            //    defaultValue: "");

            migrationBuilder.CreateTable(
                name: "tblLoginLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsCustomer = table.Column<bool>(type: "bit", nullable: false),
                    IsOwner = table.Column<bool>(type: "bit", nullable: false),
                    LoginTime = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    LogoutTime = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLoginLog", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblLoginLog");

            //migrationBuilder.DropColumn(
            //    name: "Password",
            //    table: "tblAdmin");

            //migrationBuilder.DropColumn(
            //    name: "UserName",
            //    table: "tblAdmin");

            migrationBuilder.CreateTable(
                name: "tblAdminLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    LoginTime = table.Column<DateTime>(type: "nvarchar(40)", nullable: false),
                    LogoutTime = table.Column<DateTime>(type: "nvarchar(40)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAdminLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblAdminLog_tblAdmin_AdminId",
                        column: x => x.AdminId,
                        principalTable: "tblAdmin",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblAdminLog_AdminId",
                table: "tblAdminLog",
                column: "AdminId");
        }
    }
}
