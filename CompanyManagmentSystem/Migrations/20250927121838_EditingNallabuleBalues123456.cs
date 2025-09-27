using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyManagmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class EditingNallabuleBalues123456 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contracts_EmployeeId",
                table: "Contracts");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Contracts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_EmployeeId",
                table: "Contracts",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contracts_EmployeeId",
                table: "Contracts");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_EmployeeId",
                table: "Contracts",
                column: "EmployeeId",
                unique: true);
        }
    }
}
