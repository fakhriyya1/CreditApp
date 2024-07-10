using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonthlyIncome = table.Column<float>(type: "real", nullable: false),
                    ExperienceYears = table.Column<int>(type: "int", nullable: true),
                    ExperienceMonths = table.Column<int>(type: "int", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guarantors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelationshipToApplicant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonthlyIncome = table.Column<float>(type: "real", nullable: false),
                    ExperienceYears = table.Column<int>(type: "int", nullable: true),
                    ExperienceMonths = table.Column<int>(type: "int", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guarantors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurposeOfLoan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoanAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    LoanTerm = table.Column<int>(type: "int", nullable: false),
                    InterestRate = table.Column<float>(type: "real", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanDetails_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanGuarantor",
                columns: table => new
                {
                    LoanDetailId = table.Column<int>(type: "int", nullable: false),
                    GuarantorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanGuarantor", x => new { x.GuarantorId, x.LoanDetailId });
                    table.ForeignKey(
                        name: "FK_LoanGuarantor_Guarantors_GuarantorId",
                        column: x => x.GuarantorId,
                        principalTable: "Guarantors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanGuarantor_LoanDetails_LoanDetailId",
                        column: x => x.LoanDetailId,
                        principalTable: "LoanDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanDetails_CustomerId",
                table: "LoanDetails",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanGuarantor_LoanDetailId",
                table: "LoanGuarantor",
                column: "LoanDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanGuarantor");

            migrationBuilder.DropTable(
                name: "Guarantors");

            migrationBuilder.DropTable(
                name: "LoanDetails");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
