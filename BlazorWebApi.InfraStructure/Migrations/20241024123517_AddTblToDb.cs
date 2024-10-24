using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorWebApi.InfraStructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTblToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblAdmin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FLName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Access = table.Column<int>(type: "int", nullable: false),
                    OwnerManage = table.Column<bool>(type: "bit", nullable: false),
                    CustomerManage = table.Column<bool>(type: "bit", nullable: false),
                    SabtDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAdmin", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblBokking",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID = table.Column<int>(type: "int", nullable: false),
                    VillaID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MabKol = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    NumberGuests = table.Column<int>(type: "int", nullable: false),
                    IsReserved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBokking", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "tblMessages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IDSend = table.Column<int>(type: "int", nullable: false),
                    IDRecieve = table.Column<int>(type: "int", nullable: true),
                    VillaID = table.Column<int>(type: "int", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    SabtDate = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMessages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblOwners",
                columns: table => new
                {
                    OwneriD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PhNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SabtDate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Score = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOwners", x => x.OwneriD);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblAdmin");

            migrationBuilder.DropTable(
                name: "tblBokking");

            migrationBuilder.DropTable(
                name: "tblMessages");

            migrationBuilder.DropTable(
                name: "tblOwners");
        }
    }
}
