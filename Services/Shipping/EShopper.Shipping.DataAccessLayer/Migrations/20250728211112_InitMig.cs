using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShopper.Shipping.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CargoCompanies",
                columns: table => new
                {
                    CargoCompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoCompanies", x => x.CargoCompanyId);
                });

            migrationBuilder.CreateTable(
                name: "CargoCustomers",
                columns: table => new
                {
                    CargoCustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoCustomerName = table.Column<int>(type: "int", nullable: false),
                    CargoCustomerSurname = table.Column<int>(type: "int", nullable: false),
                    CargoCustomerEmail = table.Column<int>(type: "int", nullable: false),
                    CargoCustomerPhone = table.Column<int>(type: "int", nullable: false),
                    CargoCustomerDistrict = table.Column<int>(type: "int", nullable: false),
                    CargoCustomerCity = table.Column<int>(type: "int", nullable: false),
                    CargoCustomerAddress = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoCustomers", x => x.CargoCustomerId);
                });

            migrationBuilder.CreateTable(
                name: "CargoOperations",
                columns: table => new
                {
                    CargoOperationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoOperations", x => x.CargoOperationId);
                });

            migrationBuilder.CreateTable(
                name: "CargoDetails",
                columns: table => new
                {
                    CargoDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoCustomerId = table.Column<int>(type: "int", nullable: false),
                    ReceiverCustomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Barcode = table.Column<int>(type: "int", nullable: false),
                    CargoCompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoDetails", x => x.CargoDetailId);
                    table.ForeignKey(
                        name: "FK_CargoDetails_CargoCompanies_CargoCompanyId",
                        column: x => x.CargoCompanyId,
                        principalTable: "CargoCompanies",
                        principalColumn: "CargoCompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CargoDetails_CargoCustomers_CargoCustomerId",
                        column: x => x.CargoCustomerId,
                        principalTable: "CargoCustomers",
                        principalColumn: "CargoCustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CargoDetails_CargoCompanyId",
                table: "CargoDetails",
                column: "CargoCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoDetails_CargoCustomerId",
                table: "CargoDetails",
                column: "CargoCustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CargoDetails");

            migrationBuilder.DropTable(
                name: "CargoOperations");

            migrationBuilder.DropTable(
                name: "CargoCompanies");

            migrationBuilder.DropTable(
                name: "CargoCustomers");
        }
    }
}
