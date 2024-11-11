using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorWebApi.InfraStructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminLogTblToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_tblOwners",
            //    table: "tblOwners");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_tblBokking",
            //    table: "tblBokking");

            //migrationBuilder.DropColumn(
            //    name: "OwneriD",
            //    table: "tblOwners");

            //migrationBuilder.AlterColumn<int>(
            //    name: "ID",
            //    table: "tblOwners",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AddColumn<int>(
            //    name: "IDGroup",
            //    table: "tblMessages",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<bool>(
            //    name: "OnRead",
            //    table: "tblMessages",
            //    type: "bit",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<int>(
            //    name: "TypeRecieve",
            //    table: "tblMessages",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.AlterColumn<int>(
            //    name: "ID",
            //    table: "tblBokking",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AlterColumn<int>(
            //    name: "CustomerID",
            //    table: "tblBokking",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_tblOwners",
            //    table: "tblOwners",
            //    column: "ID");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_tblBokking",
            //    table: "tblBokking",
            //    column: "ID");

            migrationBuilder.CreateTable(
                name: "tblAdminLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    LoginTime = table.Column<DateTime>(type: "nvarchar(20)", nullable: false),
                    LogoutTime = table.Column<DateTime>(type: "nvarchar(20)", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
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

            migrationBuilder.CreateTable(
                name: "tblOnvanList",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    IDType = table.Column<int>(type: "int", nullable: false),
                    Onvan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOnvanList", x => x.ID);
                });

            //migrationBuilder.InsertData(
            //    table: "tblOnvanList",
            //    columns: new[] { "ID", "IDType", "Onvan" },
            //    values: new object[,]
            //    {
            //        { 0, 1, "مشتری" },
            //        { 1, 1, "مالک" },
            //        { 2, 1, "ادمین" }
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_tblAdminLog_AdminId",
                table: "tblAdminLog",
                column: "AdminId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblAdminLog");

            migrationBuilder.DropTable(
                name: "tblOnvanList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblOwners",
                table: "tblOwners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblBokking",
                table: "tblBokking");

            migrationBuilder.DropColumn(
                name: "IDGroup",
                table: "tblMessages");

            migrationBuilder.DropColumn(
                name: "OnRead",
                table: "tblMessages");

            migrationBuilder.DropColumn(
                name: "TypeRecieve",
                table: "tblMessages");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "tblOwners",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "OwneriD",
                table: "tblOwners",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "tblBokking",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "tblBokking",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblOwners",
                table: "tblOwners",
                column: "OwneriD");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblBokking",
                table: "tblBokking",
                column: "CustomerID");
        }
    }
}
