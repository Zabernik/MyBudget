using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBudget.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDepositModelv30 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseHistory");

            migrationBuilder.DropTable(
                name: "IncomeHistory");

            migrationBuilder.DropTable(
                name: "IncomeCategories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpenseHistory",
                columns: table => new
                {
                    ExpenseHistoryID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DepositID = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseHistory", x => x.ExpenseHistoryID);
                    table.ForeignKey(
                        name: "FK_ExpenseHistory_Deposit_DepositID",
                        column: x => x.DepositID,
                        principalTable: "Deposit",
                        principalColumn: "DepositID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncomeCategories",
                columns: table => new
                {
                    IncomeCategoryID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeCategories", x => x.IncomeCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "IncomeHistory",
                columns: table => new
                {
                    IncomeHistoryID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DepositID = table.Column<int>(type: "INTEGER", nullable: false),
                    IncomeCategoryID = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeHistory", x => x.IncomeHistoryID);
                    table.ForeignKey(
                        name: "FK_IncomeHistory_Deposit_DepositID",
                        column: x => x.DepositID,
                        principalTable: "Deposit",
                        principalColumn: "DepositID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IncomeHistory_IncomeCategories_IncomeCategoryID",
                        column: x => x.IncomeCategoryID,
                        principalTable: "IncomeCategories",
                        principalColumn: "IncomeCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseHistory_DepositID",
                table: "ExpenseHistory",
                column: "DepositID");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeHistory_DepositID",
                table: "IncomeHistory",
                column: "DepositID");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeHistory_IncomeCategoryID",
                table: "IncomeHistory",
                column: "IncomeCategoryID");
        }
    }
}
