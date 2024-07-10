using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddLoanStatusAndIsConfirmedColumnsToLoanDetailsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                table: "LoanDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LoanStatus",
                table: "LoanDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "LoanDetails");

            migrationBuilder.DropColumn(
                name: "LoanStatus",
                table: "LoanDetails");
        }
    }
}
