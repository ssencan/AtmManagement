using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtmManagement.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PlateNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.ID);
                    table.ForeignKey(
                        name: "FK_District_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Atm",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AtmName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false),
                    DistrictID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atm", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Atm_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Atm_District_DistrictID",
                        column: x => x.DistrictID,
                        principalTable: "District",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atm_CityID",
                table: "Atm",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Atm_DistrictID",
                table: "Atm",
                column: "DistrictID");

            migrationBuilder.CreateIndex(
                name: "IX_District_CityID",
                table: "District",
                column: "CityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atm");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
