using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorWebApi.InfraStructure.Migrations
{
    /// <inheritdoc />
    public partial class Changes02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VillaCategory1",
                table: "tblVillas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VillaCategory2",
                table: "tblVillas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VillaCategory3",
                table: "tblVillas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VillaCategory4",
                table: "tblVillas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VillaCategory5",
                table: "tblVillas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VillaType1",
                table: "tblVillas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VillaType2",
                table: "tblVillas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VillaType3",
                table: "tblVillas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VillaType4",
                table: "tblVillas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VillaType5",
                table: "tblVillas",
                type: "int",
                nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "TypeName",
            //    table: "tblVillaCategory",
            //    type: "nvarchar(50)",
            //    maxLength: 50,
            //    nullable: false,
            //    defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VillaCategory1",
                table: "tblVillas");

            migrationBuilder.DropColumn(
                name: "VillaCategory2",
                table: "tblVillas");

            migrationBuilder.DropColumn(
                name: "VillaCategory3",
                table: "tblVillas");

            migrationBuilder.DropColumn(
                name: "VillaCategory4",
                table: "tblVillas");

            migrationBuilder.DropColumn(
                name: "VillaCategory5",
                table: "tblVillas");

            migrationBuilder.DropColumn(
                name: "VillaType1",
                table: "tblVillas");

            migrationBuilder.DropColumn(
                name: "VillaType2",
                table: "tblVillas");

            migrationBuilder.DropColumn(
                name: "VillaType3",
                table: "tblVillas");

            migrationBuilder.DropColumn(
                name: "VillaType4",
                table: "tblVillas");

            migrationBuilder.DropColumn(
                name: "VillaType5",
                table: "tblVillas");

            //migrationBuilder.DropColumn(
            //    name: "TypeName",
            //    table: "tblVillaCategory");
        }
    }
}
