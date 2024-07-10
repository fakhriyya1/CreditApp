using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddCurrencyColumnToLoanDetailTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "LoanDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "LoanDetails");
        }
    }
}
