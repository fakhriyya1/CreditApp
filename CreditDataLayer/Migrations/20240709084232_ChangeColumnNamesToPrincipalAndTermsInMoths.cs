using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnNamesToPrincipalAndTermsInMoths : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LoanTerm",
                table: "LoanDetails",
                newName: "TermInMonths");

            migrationBuilder.RenameColumn(
                name: "LoanAmount",
                table: "LoanDetails",
                newName: "Principal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TermInMonths",
                table: "LoanDetails",
                newName: "LoanTerm");

            migrationBuilder.RenameColumn(
                name: "Principal",
                table: "LoanDetails",
                newName: "LoanAmount");
        }
    }
}
