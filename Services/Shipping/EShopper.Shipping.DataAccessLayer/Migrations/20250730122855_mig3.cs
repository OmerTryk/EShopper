using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShopper.Shipping.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CargoDetails_CargoCustomers_CargoCustomerId",
                table: "CargoDetails");

            migrationBuilder.DropIndex(
                name: "IX_CargoDetails_CargoCustomerId",
                table: "CargoDetails");

            migrationBuilder.DropColumn(
                name: "CargoCustomerId",
                table: "CargoDetails");

            migrationBuilder.AddColumn<string>(
                name: "SenderCustomer",
                table: "CargoDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SenderCustomer",
                table: "CargoDetails");

            migrationBuilder.AddColumn<int>(
                name: "CargoCustomerId",
                table: "CargoDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CargoDetails_CargoCustomerId",
                table: "CargoDetails",
                column: "CargoCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CargoDetails_CargoCustomers_CargoCustomerId",
                table: "CargoDetails",
                column: "CargoCustomerId",
                principalTable: "CargoCustomers",
                principalColumn: "CargoCustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
