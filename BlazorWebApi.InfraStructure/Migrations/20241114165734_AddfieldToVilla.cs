using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorWebApi.InfraStructure.Migrations
{
    /// <inheritdoc />
    public partial class AddfieldToVilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOffer",
                table: "tblVillas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "TakhfifPerAllNights",
                table: "tblVillas",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TakhfifPerNight",
                table: "tblVillas",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOffer",
                table: "tblVillas");

            migrationBuilder.DropColumn(
                name: "TakhfifPerAllNights",
                table: "tblVillas");

            migrationBuilder.DropColumn(
                name: "TakhfifPerNight",
                table: "tblVillas");
        }
    }
}
