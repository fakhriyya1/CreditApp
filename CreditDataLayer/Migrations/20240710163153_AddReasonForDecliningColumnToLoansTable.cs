using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddReasonForDecliningColumnToLoansTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReasonForDeclining",
                table: "LoanDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReasonForDeclining",
                table: "LoanDetails");
        }
    }
}
